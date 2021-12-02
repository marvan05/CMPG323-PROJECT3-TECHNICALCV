﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALCV.Models
{
    public class SendMailDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
