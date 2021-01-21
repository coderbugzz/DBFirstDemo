using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirstDemo.Models
{
    public class UserViewModel
    {
        public user user_data { get; set; }
        public List<user> user_list { get; set; }
    }
}