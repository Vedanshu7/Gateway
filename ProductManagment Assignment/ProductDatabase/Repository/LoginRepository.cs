using ProductModels.Models;
using ProductDBA;
using ProductModel.Models;

namespace ProductDBA.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ProductDatabase.Database.ProductManagementEntities _db;

        public LoginRepository()
        {
            _db = new ProductDatabase.Database.ProductManagementEntities();
        }
        public Login GetUser(string email)
        {
            var User = _db.Logins.Find(email);
            if (User != null)
            {
                Login login = new Login();
                login.Email = User.Email;
                login.Is_active = User.Is_active;
                login.Password = User.Password;
                return login;
            }
            else
            {
                return null;
            }
        }

        public int Register(Register r)
        {
            var pre= _db.Logins.Find(r.Email);
            if (pre == null)
            {
                ProductDatabase.Database.Login register = new ProductDatabase.Database.Login();
                register.Email = r.Email;
                register.Password = r.Password;
                _db.Logins.Add(register);
                _db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
            
        }
    }
}
