﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSmart.Core.DTOs
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Url { get; set; }
    }
}
