using Core.Entities;
using Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
