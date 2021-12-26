using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class People :BaseEntity
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
        public virtual  TypePeople TypePeople { get; set; }
    }
}
