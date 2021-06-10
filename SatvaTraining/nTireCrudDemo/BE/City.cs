using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public string  StateName { get; set; }
        public string CountryName { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
    }
}
