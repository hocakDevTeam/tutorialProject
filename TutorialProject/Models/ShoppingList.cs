using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorialProject.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string CompletedBy { get; set; }
        public DateTime CompletedOn { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}