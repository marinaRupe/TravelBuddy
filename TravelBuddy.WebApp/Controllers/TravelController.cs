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
using TravelBuddy.WebApp.Models.TravelViewModels;

namespace TravelBuddy.WebApp.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class TravelController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public TravelController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentDomainUserAsync();
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            unitOfWork.BeginTransaction();
            var travels = user.Travels.Select(t => new TravelViewModel(t));
            unitOfWork.Commit();
            return View(travels);
        }

        public IActionResult Create()
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
