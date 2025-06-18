using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TutorialProject.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }
        [DisplayName("Action")]
        public string Action { get; set; }
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }
    }
}