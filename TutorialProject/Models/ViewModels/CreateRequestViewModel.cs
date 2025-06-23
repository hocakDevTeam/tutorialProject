using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TutorialProject.Models.ViewModels
{
    public class CreateRequestViewModel
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        public int Quantity { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }

        public SelectList LocationOption
        {
            get
            {
                return new SelectList(new List<string> { "Break Room", "Conference Room", "Bathroom" });
            }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }

        public bool Archived { get; set; }


    }
}