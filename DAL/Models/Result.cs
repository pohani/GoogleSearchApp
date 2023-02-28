﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public KeyWord KeyWord { get; set; }
    }
}
