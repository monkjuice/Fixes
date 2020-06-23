using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FixesAPI.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Model;
using Service;
using Service.Interfaces;
using FixesAPI.Validators;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace FixesAPI.Controllers
{
    public class FixesController : ControllerBase
    {
        public enum ResponseCode
        {
            Ok = 0,
            BadRequest = 400,
            ServerError = 500
        }

    }
}



