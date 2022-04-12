﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatterDapter.Models
{
    internal class ElasticSettings
    {
        public string Url { get; set; }
        public string? Username { get; init; }
        public string? Password { get; init; }
    }
}
