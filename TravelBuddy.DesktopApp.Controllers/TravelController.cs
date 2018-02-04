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
            var addTravelView =_formsFactory.CreateAddTravelView(this);
            addTravelView.ShowModaless();
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
