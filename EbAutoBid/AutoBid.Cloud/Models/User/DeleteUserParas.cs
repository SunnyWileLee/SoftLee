﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoBid.Cloud.Models.User
{
    public class DeleteUserParas
    {
        [Required]
        public Guid Id { get; set; }
    }
}