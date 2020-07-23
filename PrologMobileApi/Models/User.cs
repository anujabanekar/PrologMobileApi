using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrologMobileApi.Models
{
    public class User 
    {
        public string Id { get; set; }

        public string CreatedAt { get; set; }

        public string OrganizationId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
