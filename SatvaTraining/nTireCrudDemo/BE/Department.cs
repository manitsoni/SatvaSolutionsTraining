﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int? CompanyId { get; set; }
    }
}
