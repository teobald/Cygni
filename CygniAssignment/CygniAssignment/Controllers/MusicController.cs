﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CygniAssignment.Controllers
{
    public class MusicController : ApiController
    {
        //GET api/music
        public string[] Get()
        {
            return new string[]
            {
             "Hello",
             "World"
            };
        }
    }
}
