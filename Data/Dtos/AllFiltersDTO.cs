﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class AllFiltersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }
}
