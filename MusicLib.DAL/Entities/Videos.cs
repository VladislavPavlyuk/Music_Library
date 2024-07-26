﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLib.DAL.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string? FileName { get; set; }

        public string? Path { get; set; }

        public ICollection<Player>? Players { get; set; }
    }
}
