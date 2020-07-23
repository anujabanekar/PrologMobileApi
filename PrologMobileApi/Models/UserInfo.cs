using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrologMobileApi.Models
{
    public class UserInfo : BaseModel
    {
        public string OrganizationId { get; }

        public string Name { get; }

        public string Email { get; }
    }
}
