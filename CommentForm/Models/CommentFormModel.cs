using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommentForm.Models
{
    public class CommentFormModel
    {
        //Our ID keeps track of each instance
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Comment { get; set; }

        [Display(Name= "How soon do I need to get this task done?")]
        public int Priority { get; set; }
    }
}