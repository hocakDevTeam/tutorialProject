using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TutorialProject.Models.ViewModels
{
    public class CreateDocViewModel
    {
        public int ShoppingListId { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}