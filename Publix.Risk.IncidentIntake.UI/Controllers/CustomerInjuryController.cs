using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publix.Risk.IncidentIntake.UI.Controllers
{
    public class CustomerInjuryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
