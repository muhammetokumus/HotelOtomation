using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Hotel : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public bool IsFull { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string DetailImage { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
