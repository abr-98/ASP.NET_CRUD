using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Data
{
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public String FirstName { get; set; }
        [MaxLength(50)]
        public String LastName { get; set; }
        public int Age { get; set; }
        public bool IsPlayer { get; set; }
    }
}
