using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrologMobileApi.Models
{
    public class OrgSummaryDomainModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int BlackListTotal { get; set; }
        public int TotalCount { get; set; }
        public List<UserSummary> Users { get; set; }
    }
}
