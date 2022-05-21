using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBook
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public DateTime DoB { get; set; }
    }
}
