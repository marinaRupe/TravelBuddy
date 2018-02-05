using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelBuddy.BaseLib;
using TravelBuddy.BaseLib.Factories;
using TravelBuddy.DesktopApp.ViewModels;
using TravelBuddy.Models;

namespace TravelBuddy.DesktopApp.Controllers
{
    public class TravelController : ITravelController
    {
        private readonly IMainController _mainController;
        private readonly IWindowFormsFactory _formsFactory;
        public TravelController(IMainController mainController, IWindowFormsFactory formsFactory)
        {
            _mainController = mainController;
            _formsFactory = formsFactory;
        }

        public void OpenAddTravelWindow()
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var currencyRepository = RepositoriesFactory.CreateCurrencyRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var currencyList = new List<Currency>(currencyRepository.GetAll());

                var addTravelView = _formsFactory.CreateAddTravelView(this, currencyList);
                addTravelView.ShowModaless();

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void EditTravel(EditTravelViewModel travelModel)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var currencyRepository = RepositoriesFactory.CreateCurrencyRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var currencyList = new List<Currency>(currencyRepository.GetAll());

                var editTravelView = _formsFactory.CreateEditTravelView(this, travelModel, currencyList);
                editTravelView.ShowModaless();

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void SaveEditedTravel(EditTravelViewModel travelModel)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var travel = travelRepository.GetTravel(travelModel.Id);

                travel.Name = travelModel.Name;
                travel.Description = travelModel.Description;
                travel.DateStart = travelModel.DateStart;
                travel.DateEnd = travelModel.DateEnd;
                travel.Budget = travelModel.Budget;

                travelRepository.UpdateTravel(travel);

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void AddTravel(AddTravelViewModel model)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var userRepository = RepositoriesFactory.CreateUserRepository(unitOfWork);
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var user = userRepository.GetUser(_mainController.LoggedInUserId);

                var travel = new Travel
                {
                    Name = model.Name,
                    Description = model.Description,
                    DateStart = model.DateStart,
                    DateEnd = model.DateEnd,
                    Budget = model.Budget,
                    Traveller = user
                };
                
                travelRepository.AddTravel(travel);

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                
                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }
    }
}
