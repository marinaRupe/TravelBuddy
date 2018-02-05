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
            var userRepository = RepositoriesFactory.CreateUserRepository(unitOfWork);

            unitOfWork.BeginTransaction();
            user = userRepository.GetUser(user.Id);
            var travels = user.Travels.ToList().Select(t => new IndexTravelViewModel(t));
            unitOfWork.Commit();

            return View(travels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new AddTravelViewModel();
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var currencyRepository = RepositoriesFactory.CreateCurrencyRepository(unitOfWork);

            unitOfWork.BeginTransaction();
            currencyRepository.CreateCurrenciesIfNoneExist();
            viewModel.CurrencyOptions = currencyRepository.GetAll();
            unitOfWork.Commit();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddTravelViewModel viewModel)
        {
            var travel = viewModel.ToTravel();
            var user = await GetCurrentDomainUserAsync();
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var userRepository = RepositoriesFactory.CreateUserRepository(unitOfWork);
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);
            var currencyRepository = RepositoriesFactory.CreateCurrencyRepository(unitOfWork);

            unitOfWork.BeginTransaction();
            travel.Traveller = userRepository.GetUser(user.Id);
            var currency = currencyRepository.GetById(viewModel.BudgetCurrencyId);
            if (viewModel.BudgetValue > 0 && currency != null)
            {
                travel.Budget = new MoneyValue
                {
                    Value = viewModel.BudgetValue,
                    Currency = currency
                };
            }
            travelRepository.AddTravel(travel);
            unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);
            var currencyRepository = RepositoriesFactory.CreateCurrencyRepository(unitOfWork);

            unitOfWork.BeginTransaction();
            var viewModel = new EditTravelViewModel(travelRepository.GetTravel(id));
            currencyRepository.CreateCurrenciesIfNoneExist();
            viewModel.CurrencyOptions = currencyRepository.GetAll();
            unitOfWork.Commit();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTravelViewModel viewModel)
        {
            var travel = viewModel.ToTravel();
            var user = await GetCurrentDomainUserAsync();
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var userRepository = RepositoriesFactory.CreateUserRepository(unitOfWork);
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);
            var currencyRepository = RepositoriesFactory.CreateCurrencyRepository(unitOfWork);

            unitOfWork.BeginTransaction();
            var currency = currencyRepository.GetById(viewModel.BudgetCurrencyId);
            if (viewModel.BudgetValue > 0 && currency != null)
            {
                travel.Budget = new MoneyValue
                {
                    Value = viewModel.BudgetValue,
                    Currency = currency
                };
            }
            travelRepository.UpdateTravel(travel);
            unitOfWork.Commit();

            return RedirectToAction("Index");
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
