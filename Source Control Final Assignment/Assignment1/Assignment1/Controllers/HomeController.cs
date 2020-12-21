using Assignment1.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class ExceptionHandler : HandleErrorAttribute
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
            logger.Error("Exception Occurred");
            Exception e = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error404"
            };
        }
    }
    [ExceptionHandler]
    public class HomeController : Controller
    {
        private SqlConnection con;
        private static Logger logger = LogManager.GetCurrentClassLogger();
       
        private void connection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public ActionResult Index()
        {
            
            if (System.Web.HttpContext.Current.Session["Email"] != null)
            {
                String Email = Convert.ToString(System.Web.HttpContext.Current.Session["Email"]);
                connection();
                SqlCommand cmd = new SqlCommand("getdetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", Email);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();
                String FirstName = "";
                String LastName = "";
                String Emailadd = "";
                String Phone = "";
                String Age = "";
                String Country = "";
                String State = "";
                String City = "";
                String Town = "";
                String PinCode = "";
                String Image = "";
                String Gender = "";
                dict model = new dict();
                model.Users = new Dictionary<string, string>();
                foreach (DataRow dr in dt.Rows)
                {
                    FirstName = Convert.ToString(dr["FirstName"]);
                    LastName = Convert.ToString(dr["LastName"]);
                    Emailadd = Convert.ToString(dr["Email"]);
                    Phone = Convert.ToString(dr["Phone"]);
                    Age = Convert.ToString(dr["Age"]);
                    Country = Convert.ToString(dr["Country"]);
                    State = Convert.ToString(dr["State"]);
                    City = Convert.ToString(dr["City"]);
                    Town = Convert.ToString(dr["Town"]);
                    PinCode = Convert.ToString(dr["PinCode"]);
                    Image = Convert.ToString(dr["ImagePath"]);
                    Gender = Convert.ToString(dr["Gender"]);
                }

                model.Users.Add("FirstName", FirstName);
                model.Users.Add("LastName", LastName);
                model.Users.Add("Email", Email);
                model.Users.Add("Phone", Phone);
                model.Users.Add("Age", Age);
                model.Users.Add("Country", Country);
                model.Users.Add("State", State);
                model.Users.Add("City", City);
                model.Users.Add("Town", Town);
                model.Users.Add("PinCode", PinCode);
                model.Users.Add("ImagePath", Image);
                model.Users.Add("Gender", Gender);
                model.Users.Add("Active", Convert.ToString(System.Web.HttpContext.Current.Session["active"]));
                logger.Info("Index Page Appear for User:"+Emailadd);
                return View("Index", model);
            }
            else
            {
               
                return View("Login");
            }
            
        }
        public ActionResult Log()
        {
            if (System.Web.HttpContext.Current.Session["Email"] != null)
            {
                connection();
                SqlCommand cmd = new SqlCommand("getlog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();
                dict model = new dict();
                model.Logs = new Dictionary<int, Dictionary<string, string>>();
                foreach (DataRow dr in dt.Rows)
                {
                    var onerow = new Dictionary<string, string>(){
                { "Id",Convert.ToString(dr["Id"])},
                { "DateTime", Convert.ToString(dr["EventDateTime"])},
                { "Level", Convert.ToString(dr["EventLevel"]) },
                {"Message", Convert.ToString(dr["EventMessage"]) }
                };

                    model.Logs.Add(Convert.ToInt32(dr["Id"]), onerow);

                }
                return View("Log", model);
            }
            else
            {
                return View("Login");
            }
        }
        public ActionResult Register()
        {
            logger.Info("Register Page Appear");
            return View();
        }
        [HttpPost]
        public ActionResult RegisterYourSelf(Register r)
        {
            if (ModelState.IsValid)
            {
                connection();
                SqlCommand cmd = new SqlCommand("checkemail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@param1", r.Email);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();
                String Emailadd = "";
                foreach (DataRow dr in dt.Rows)
                {
                    Emailadd = Convert.ToString(dr["Email"]);
                }
                bool nameAlreadyExists = true;
                if (Emailadd != r.Email)
                {
                    nameAlreadyExists = false;
                }

                if (nameAlreadyExists)
                {
                    ModelState.AddModelError("Email", "Email Already Exists.");
                    return View("Register",r);
                }
                int size = 1000;
                if (r.Image != null)
                {
                    if(r.Image.ContentLength > size * 1024)
                    {
                        ModelState.AddModelError("Image", "Image Should be less than 1000kb .");
                        return View("Register", r);
                    }
                    r.Image.SaveAs(Server.MapPath("~/image/") + r.Image.FileName);
                }
                else
                {
                    ModelState.AddModelError("Image", "Image Not Found.");
                    return View("Register", r);
                }
                ViewBag.FileStatus = "File uploaded successfully.";
                DateTime dateTime = Convert.ToDateTime(r.Age);
                int age = DateTime.Today.Year - dateTime.Year;
                string passhash = ComputeSha256Hash(r.Password);
                string validationhash = ComputeSha256Hash(r.FirstName + r.Email + r.Password);

                SqlCommand cmd1 = new SqlCommand("insertuser", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@FirstName", r.FirstName);
                cmd1.Parameters.AddWithValue("@LastName", r.LastName);
                cmd1.Parameters.AddWithValue("@Email", r.Email);
                cmd1.Parameters.AddWithValue("@Password", passhash);
                cmd1.Parameters.AddWithValue("@Phone", r.PhoneNumber);
                cmd1.Parameters.AddWithValue("@Age", age);
                cmd1.Parameters.AddWithValue("@Country", r.Conntry);
                cmd1.Parameters.AddWithValue("@State", r.State);
                cmd1.Parameters.AddWithValue("@City", r.City);
                cmd1.Parameters.AddWithValue("@Town", r.Town);
                cmd1.Parameters.AddWithValue("@PinCode", r.Pincode);
                cmd1.Parameters.AddWithValue("@ImagePath","~/image/"+r.image_path);
                cmd1.Parameters.AddWithValue("@Gender", r.Gender);
                cmd1.Parameters.AddWithValue("@Validation", validationhash);


                con.Open();
                int i = cmd1.ExecuteNonQuery();
                con.Close();
                logger.Info("Registration of User is Successfull:" + Emailadd);

                SqlCommand cmd2 = new SqlCommand("insertlogin", con);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@Email", r.Email);
                cmd2.Parameters.AddWithValue("@Password", passhash);
                cmd2.Parameters.AddWithValue("@active", "inactive");
                logger.Info("Login Credentials are Set for User:" + Emailadd);


                con.Open();
                int j = cmd2.ExecuteNonQuery();
                con.Close();
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(r.Email);
                    mail.From = new MailAddress("mailid");
                    mail.Subject = "Activate the Mail";
                    string link = "https://localhost:44317/Home/val?validation=" + validationhash;
                    string Body = "<a href='" + link + "'>Activation Link</a>";
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("mailid", "yourpassword"); // Enter seders User name and password   
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    logger.Info("Activation Mail is Sent to User:" + Emailadd);
                }
                catch(Exception e)
                {
                    logger.Error("Error Occure while Sending Mailto: " + Emailadd+" Exception Was about"+e.Message);
                    
                }


                if (i >= 1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View("Register", r);
                }
            }
            return View("Register");
        }
        public ActionResult Login()
        {
            logger.Info("Login Appear.");
            return View();
        }
        [HttpPost]
        [Route("/Home/Loginme")]
        public ActionResult Loginme(Login l)
        {
            if (ModelState.IsValid)
            {
                connection();
                SqlCommand cmd = new SqlCommand("checklogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", l.Email);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();
                String Emailadd = "";
                String pass = "";
                String active = "";
                foreach (DataRow dr in dt.Rows)
                {
                    Emailadd = Convert.ToString(dr["Email"]);
                    pass = Convert.ToString(dr["Password"]);
                    active = Convert.ToString(dr["is_active"]);
                }

                String panelpass = ComputeSha256Hash(l.Password);
                if (Emailadd == "")
                {
                    ModelState.AddModelError("Email", "Email doesn't exsits.");
                    return View("Login", l);
                }
                if (panelpass != pass)
                {
                    ModelState.AddModelError("Password", "Password doesn't match.");
                    throw new Exception();
                    return View("Login", l);
                }
                ViewBag.Email = Emailadd;
                ViewBag.active = active;
                System.Web.HttpContext.Current.Session["Email"] = Emailadd;
                System.Web.HttpContext.Current.Session["active"] = active;
                logger.Info("Login Successful of User: " + Emailadd);
                
                return Redirect("Index");
            }
            else
            {

                logger.Info("Login Faliure of User: " + l.Email);
                
                return View("Login",l);
            }
        }
        
        [Route("/val/{validation}")]
        public ActionResult val(string validation)
        {
            connection();
            SqlCommand cmd2 = new SqlCommand("activeuser", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@Validation", validation);

            con.Open();
            int j = cmd2.ExecuteNonQuery();
            con.Close();
            logger.Info("Activation of User:" + validation);
            return View("Login");
            
        }
        public ActionResult Logout()
        {
            logger.Info("Logout Successfully of User:" + System.Web.HttpContext.Current.Session["Email"]);
            System.Web.HttpContext.Current.Session["Email"] = null;
            System.Web.HttpContext.Current.Session["active"] = null;
            return Redirect("Index");
        }
        public ActionResult Contact()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            con.Open();
            String s = "select * from Nametable";
            SqlCommand cmd = new SqlCommand(s, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            String Id="", Name="";
            foreach (DataRow dr in dt.Rows)
            {

                Id = Convert.ToString(dr["Id"]);
                Name = Convert.ToString(dr["Name"]);
                        
            }
            return View();
        }
    }
}
