using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class State
    {
        public int Id { get; set; }
        public string  StateName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
