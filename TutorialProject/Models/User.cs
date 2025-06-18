using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorialProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Department { get; set; }
        public string Facility { get; set; }
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public bool Active { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}