﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logopédia_WebAPI.Models
{
    public partial class Ovodak
    {
        public int letszam => gyerekek.Count;
    }
}
