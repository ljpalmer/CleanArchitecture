﻿using CleanArchitecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class VideosVm
    {
        public string Nombre { get; set; } = string.Empty;
        public int StreamerId { get; set; }
    }
}
