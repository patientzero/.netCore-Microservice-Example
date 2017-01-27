using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactService.Models
{
    public class Contact
    {
        public string Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
    }
}
