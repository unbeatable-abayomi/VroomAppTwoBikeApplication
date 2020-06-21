﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VroomAppTwo.Models
{
    public class Make
    {
        public int Id { get; set; }
        [Required]
        [StringLength(225)]
        public string Name { get; set; }
    }
}
