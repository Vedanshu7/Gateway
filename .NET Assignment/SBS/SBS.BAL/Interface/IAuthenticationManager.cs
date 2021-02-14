using SBS.Common.CommonModels;
using SBS.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BAL.Interface
{
    public interface IAuthenticationManager
    {
        LoginResult Login(LoginViewModel login);
        bool Register(RegisterViewModel register, VehicleViewModel vehicle);
    }
}
