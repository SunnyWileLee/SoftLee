﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Models.User
{
    public class EditUserParas
    {
        [Required]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}