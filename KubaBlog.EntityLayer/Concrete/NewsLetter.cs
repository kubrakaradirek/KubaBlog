﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaBlog.EntityLayer.Concrete
{
    public class NewsLetter
    {
        [Key]
        public int MailID { get; set; }
        public string Email { get; set; }
        public bool EmailStatus { get; set; }
    }
}
