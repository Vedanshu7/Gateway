using ProductModel.Models;
using ProductModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductInterface.Interface
{
    public interface ILoginManager
    {
        Login GetUser(string email);

        int Register(Register r);
    }
}
