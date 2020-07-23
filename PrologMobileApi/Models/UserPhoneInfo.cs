using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrologMobileApi.Models
{
    public class UserPhoneInfo : BaseModel
    {
        public string UserId { get; }

        public string IMEI { get; }

        public bool Blacklist { get; }
    }
}
