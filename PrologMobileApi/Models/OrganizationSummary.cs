using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrologMobileApi.Models
{
    public class OrganizationSummary 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<UserDetail> Users { get; set; }
    }
}
