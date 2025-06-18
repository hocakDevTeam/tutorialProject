using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorialProject.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }

    }
}