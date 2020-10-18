using System;
using System.Collections.Generic;
using System.Text;

namespace L01_Domain.Usuarios
{
    public class GoogleUserOutputData
    {

        public string id { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string email { get; set; }
        public string picture { get; set; }

        public GoogleUserOutputData()
        {

        }
    }
}
