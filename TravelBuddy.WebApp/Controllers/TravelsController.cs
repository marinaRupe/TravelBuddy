using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBuddy.BaseLib.Factories;
using TravelBuddy.Models;
using TravelBuddy.WebApp.Models;

namespace TravelBuddy.WebApp.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class TravelsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public TravelsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<User> GetCurrentDomainUserAsync()
        {
            var appUser = await GetCurrentApplicationUserAsync();
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var userRepository = RepositoriesFactory.CreateUserRepository(unitOfWork);
            unitOfWork.BeginTransaction();
            var domainUser = userRepository.GetUserByEmail(appUser.Email);
            unitOfWork.Commit();
            return domainUser;
        }

        private Task<ApplicationUser> GetCurrentApplicationUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
