using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrologMobileApi.Models
{
    public class UserPhone 
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }

        public string IMEI { get; set; }

        public bool Blacklist { get; set; }
    }
}
