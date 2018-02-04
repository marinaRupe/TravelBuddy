using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBuddy.WebApp.Controllers
{
    // [Authorize]
    [Route("[controller]/[action]")]
    public class TravelsController : Controller
    {
    }
}
