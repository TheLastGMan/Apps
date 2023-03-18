﻿using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiChessAPI.Core.Model
{
    public class UserRatingPoint
    {
        public int before { get; set; }
        public int after { get; set; }

        [JsonIgnore]
        public int RatingChange { get { return after - before; } }
    }
}
