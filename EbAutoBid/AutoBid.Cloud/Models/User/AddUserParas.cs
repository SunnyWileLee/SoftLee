using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Models.User
{
    public class AddUserParas
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}