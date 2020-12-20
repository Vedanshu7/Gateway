using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class dict
    {
      public  Dictionary<string, string> Users { get; set; }

      
      public Dictionary<int,Dictionary<string,string>> Logs { get; set; }
    }
}