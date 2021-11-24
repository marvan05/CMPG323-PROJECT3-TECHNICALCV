using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TECHNICALCV.Models
{
    public class SendMailDto
    {
        [Required]
        public string Name;
        [Required]
        public string Subject;
        [Required]
        public string Message;
    }
}
