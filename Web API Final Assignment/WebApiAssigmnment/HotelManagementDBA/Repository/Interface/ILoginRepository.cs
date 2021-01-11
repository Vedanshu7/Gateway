using HotelManagementModels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementDBA.Repository.Interface
{
    public interface ILoginRepository
    {
        int Login(string email, string password);

        int Update(Login login);

        int Delete(string email);

        int Create(Login login);


    }
}
