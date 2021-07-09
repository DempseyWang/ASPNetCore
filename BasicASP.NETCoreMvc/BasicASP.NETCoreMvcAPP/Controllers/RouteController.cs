﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicASP.NETMvc.Controllers
{
    [AllowAnonymous]
    //basic points 12 Please change "api" to made this controller root path is "api/route"
    //[Route("api")]
    [Route("api/route")]
    public class RouteController : ControllerBase
    {
        // Get
        //basic points 13 Change "xxx" and requet "/api/route/index" by Get
        //[Route("xxx")]
        [HttpGet]
        [Route("index")]
        public string Get()
        {
            return "hello world";
        }

        [Route("index2")]
        public string Post()
        {
            return "hello world";
        }
    }
}