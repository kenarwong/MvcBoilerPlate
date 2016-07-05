using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcBoilerPlate.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Domain { get; set; }
        public string Email { get; set; }
    }
}