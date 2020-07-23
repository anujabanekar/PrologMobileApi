using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrologMobileApi.Models
{
    public class UserDetail
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public List<UserPhone> UserPhoneData {get; set;}
    }
}
