using System;
using System.Collections.Generic;
using System.Text;

namespace ProductModels.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Is_active { get; set; }
    }
}
