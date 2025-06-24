using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TutorialProject.Models
{
    public class Document
    {
        public int Id { get; set; }
        //This is the Foreign Key
        public int ShoppingListId { get; set; }

        //File Props
        [DisplayName("File Name")]
        public string FileName { get; set; }
        [DisplayName("Mime Type")]
        public string MimeType { get; set; }
        public byte[] Content { get; set; }
        [DisplayName("File Extension")]
        public string FileExtension { get; set; }

        //Blame fields
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
        [DisplayName("Created")]
        public DateTime CreatedAt { get; set; }
   
        //reference to ShoppingList Model
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}