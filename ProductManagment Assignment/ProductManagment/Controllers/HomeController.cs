using Newtonsoft.Json;
using ProductManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProductManagment.Controllers
{
    public class ExceptionHandler : HandleErrorAttribute
    {
       
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
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
        private static string WebAPIURL = "https://localhost:44327/";
        private static List<Product> product_main;
        private static List<Product> use;
       
        [HttpPost]
        public ActionResult Search(string search)
        {
            if (Session["token"] != null)
            {

                if (search == "")
                {
                    use = product_main;
                    return View("Index", product_main);
                }
                else
                {
                    List<Product> p = new List<Product>();
                    string pattern = search;
                    // Create a Regex  
                    Regex rg = new Regex(pattern);
                    string authors = string.Empty;
                    for (int i = 0; i < use.Count; i++)
                    {
                        authors += " " + use[i].Name + " " + use[i].Short_Description + " " + use[i].Long_Description + " " + use[i].Category;
                        MatchCollection matchedAuthors = rg.Matches(authors);
                        string value = string.Empty;
                        for (int count = 0; count < matchedAuthors.Count; count++)
                        {
                            value += "  " + matchedAuthors[count].Value;
                        }
                        if (value != "")
                        {
                            p.Add(use[i]);
                        }
                        authors = "";
                    }
                    use = p;
                    return View("Index", p);


                }

            }
            else
            {
                return View("Login");
            }

        }

        [HttpGet]
        public ActionResult Sort(string submit)
        {
            if (Session["token"] != null)
            {
                switch (submit)
                {
                    case "Name":
                        use = use.OrderBy(i => i.Name).ToList();
                        return View("Index", use);
                        break;
                    case "Category":
                        use = use.OrderBy(i => i.Category).ToList();
                        return View("Index", use);
                        break;
                    case "Price":
                        use = use.OrderBy(i => i.Price).ToList();
                        return View("Index", use);
                        break;
                    default:
                        use = product_main;
                        return View("Index", product_main);
                        break;
                }
            }
            else
            {
                return View("Login");
            }
        }




        public async Task<ActionResult> Remove(string id)
        {

            string ReturnMessage = string.Empty;
            string value = Convert.ToString(Session["token"]) + ':' + Session["Email"].ToString();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.BaseAddress = new Uri(WebAPIURL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
                var resposeMessage = await client.DeleteAsync("api/Product/RemoveMany/" + id);
                if (resposeMessage.IsSuccessStatusCode)
                {
                    var resultMessage = resposeMessage.Content.ReadAsStringAsync().Result;
                    string l = JsonConvert.DeserializeObject<string>(resultMessage);

                    if (l == "1")
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    return View("Login");
                }
            }
        }


        public async Task<ActionResult> Index()
        {
            if (Session["token"] != null)
            {
                string ReturnMessage = string.Empty;
                string value = Convert.ToString(Session["token"]) + ':' + Session["Email"].ToString();
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.BaseAddress = new Uri(WebAPIURL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
                    var resposeMessage = await client.GetAsync("api/Product");
                    if (resposeMessage.IsSuccessStatusCode)
                    {
                        var resultMessage = resposeMessage.Content.ReadAsStringAsync().Result;
                        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(resultMessage);
                        product_main = products;
                        use = products;
                        return View("Index", products);
                    }
                    else
                    {
                        return View("Login");
                    }
                }
            }
            else
            {
                return View("Login");
            }

        }
        public ActionResult GoToRegister()
        {
            return View("Register");
        }
        public async Task<ActionResult> Register(Register r)
        {
            if (ModelState.IsValid)
            {
                
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.BaseAddress = new Uri(WebAPIURL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var stringContent = new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
                    var resposeMessage = await client.PostAsync("api/Register", stringContent);
                    if (resposeMessage.IsSuccessStatusCode)
                    {
                        var resultMessage = resposeMessage.Content.ReadAsStringAsync().Result;
                        string l = JsonConvert.DeserializeObject<string>(resultMessage);

                        if (l == "1")
                        {
                            return View("Login");
                        }
                        else if(l=="0")
                        {
                            ModelState.AddModelError("Email", "Email Already Exists");
                            return View("Register",r);
                        }
                        else
                        {
                            return View("Login");
                        }
                    }
                    else
                    {
                        return View("Register");
                    }
                }
            }
            else
            {
                return View("Register", r);
            }
        }
        public async Task<ActionResult> Login(Login l)
        {
            if (ModelState.IsValid)
            {
                var token = string.Empty;
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    client.BaseAddress = new Uri(WebAPIURL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var stringContent = new StringContent(JsonConvert.SerializeObject(l), Encoding.UTF8, "application/json");
                    var resposeMessage = await client.PostAsync("api/Login/GetLogin", stringContent);
                    if (resposeMessage.IsSuccessStatusCode)
                    {
                        var resultMessage = resposeMessage.Content.ReadAsStringAsync().Result;
                        token = resultMessage;
                        Session["token"] = token;
                        Session["Email"] = l.Email;
                    }
                    else
                    {
                        token = "nothing";
                    }
                }
                if (Session["token"] != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Login");
                }
            }
            else
            {
                return View("Login", l);
            }

        }
        public async Task<ActionResult> Edit(int id)
        {
            if (Session["token"] != null)
            {
                if (id > 0)
                {
                    string ReturnMessage = string.Empty;
                    string value = Convert.ToString(Session["token"]) + ':' + Session["Email"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Clear();
                        client.BaseAddress = new Uri(WebAPIURL);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
                        var resposeMessage = await client.GetAsync("api/Product/GetOneProduct?id=" + id);
                        if (resposeMessage.IsSuccessStatusCode)
                        {
                            var resultMessage = resposeMessage.Content.ReadAsStringAsync().Result;
                            Product products = JsonConvert.DeserializeObject<Product>(resultMessage);
                            List<Product> products1 = new List<Product>();
                            products1.Add(products);
                            return View("Edit", products1);
                        }
                        else
                        {
                            return View("Index");
                        }
                    }
                }
                else
                {
                    return View("Edit", product_main);
                }

            }
            else
            {
                return View("Login");
            }

        }

        public ActionResult Logout()
        {
            Session["token"] = null;
            Session["Email"] = null;
            return View("Login");
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (Session["token"] != null)
            {
                if (id > 0)
                {
                    string ReturnMessage = string.Empty;
                    string value = Convert.ToString(Session["token"]) + ':' + Session["Email"].ToString();
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Clear();
                        client.BaseAddress = new Uri(WebAPIURL);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
                        var resposeMessage = await client.DeleteAsync("api/Product/" + id);
                        if (resposeMessage.IsSuccessStatusCode)
                        {
                            var resultMessage = resposeMessage.Content.ReadAsStringAsync().Result;
                            string l = JsonConvert.DeserializeObject<string>(resultMessage);

                            if (l == "1")
                            {
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                return RedirectToAction("Index");
                            }

                        }
                        else
                        {
                            return View("Index");
                        }
                    }
                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                return View("Login");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Update(Product p)
        {

            if (Session["token"] != null)
            {
                if (p != null)
                {
                    if (ModelState.IsValid)
                    {
                        string ReturnMessage = string.Empty;
                        string value = Convert.ToString(Session["token"]) + ':' + Session["Email"].ToString();
                        using (var client = new HttpClient())
                        {
                            client.DefaultRequestHeaders.Clear();
                            client.BaseAddress = new Uri(WebAPIURL);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
                            var stringContent = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                            var resposeMessage = await client.PutAsync("api/Product/", stringContent);
                            if (resposeMessage.IsSuccessStatusCode)
                            {
                                var resultMessage = resposeMessage.Content.ReadAsStringAsync().Result;
                                string l = JsonConvert.DeserializeObject<string>(resultMessage);

                                if (l == "1")
                                {
                                    return RedirectToAction("Index");
                                }
                                else
                                {
                                    return RedirectToAction("Index");
                                }

                            }
                            else
                            {
                                return View("Index");
                            }
                        }

                    }
                    else
                    {
                        return View("Edit", p);
                    }
                }
                else
                {
                    return View("Index");
                }

            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult GoToInsert()
        {
            return View("Insert");
        }


        public async Task<ActionResult> Insert(Product p)
        {



            if (Session["token"] != null)
            {
                if (p != null)
                {
                    if (ModelState.IsValid)
                    {
                        int size = 1000;
                        if (p.S_Image != null && p.L_Image != null)
                        {
                            if (p.S_Image.ContentLength > size * 1024)
                            {
                                ModelState.AddModelError("Image", "Image Should be less than 1000kb .");
                                return View("Insert", p);
                            }
                            else
                            {
                                p.L_Image.SaveAs(Server.MapPath("~/image/") + p.L_Image.FileName);
                                p.S_Image.SaveAs(Server.MapPath("~/image/") + p.S_Image.FileName);
                                p.Small_Image = "~/image/" + p.S_Image.FileName;
                                p.Large_Image = "~/image/" + p.L_Image.FileName;
                                p.L_Image = null;
                                p.S_Image = null;
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("S_Image", "AnyImage is not Seleted.");
                            return View("Insert", p);
                        }


                        string ReturnMessage = string.Empty;
                        string value = Convert.ToString(Session["token"]) + ':' + Session["Email"].ToString();
                        using (var client = new HttpClient())
                        {
                            client.DefaultRequestHeaders.Clear();
                            client.BaseAddress = new Uri(WebAPIURL);
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
                            var stringContent = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                            var resposeMessage = await client.PostAsync("api/Product/", stringContent);
                            if (resposeMessage.IsSuccessStatusCode)
                            {
                                var resultMessage = resposeMessage.Content.ReadAsStringAsync().Result;
                                string l = JsonConvert.DeserializeObject<string>(resultMessage);

                                if (l == "1")
                                {
                                    return RedirectToAction("Index");
                                }
                                else
                                {
                                    return RedirectToAction("Index");
                                }

                            }
                            else
                            {
                                return View("Index");
                            }
                        }
                    }
                    else
                    {
                        return View("Insert", p);
                    }

                }
                else
                {
                    return View("Insert");
                }
            }
            else
            {
                return View("Login");
            }

        }


    }
}