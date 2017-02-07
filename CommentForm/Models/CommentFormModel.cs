using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommentForm.Models
{
    public class CommentFormModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}