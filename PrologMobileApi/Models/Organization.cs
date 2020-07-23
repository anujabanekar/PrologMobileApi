﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrologMobileApi.Models
{
    public class Organization
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }
    }
}
