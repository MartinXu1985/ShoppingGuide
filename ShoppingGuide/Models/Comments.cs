using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingGuide.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }

        public string Username { get; set; }

        public string Comment { get; set; }

        //attributes;
    }
}