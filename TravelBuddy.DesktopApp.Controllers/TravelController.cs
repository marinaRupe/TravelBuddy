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

        public void OpenTravelDetails(Guid travelId)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var travel = travelRepository.GetTravel(travelId);

                var travelModal = new TravelViewModel
                {
                    Id = travel.Id,
                    Name = travel.Name,
                    Description = travel.Description,
                    DateStart = travel.DateStart,
                    DateEnd = travel.DateEnd,
                    Budget = travel.Budget
                };

                unitOfWork.Commit();

                var travelDetailsView = _formsFactory.CreateTravelDetailsView(this, travelModal);
                travelDetailsView.ShowModaless();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                MessageBox.Show(ex.Message, "TravelBuddy");
            }
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

        public void OpenTravelItemListWindow(Guid travelId)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var travel = travelRepository.GetTravel(travelId);
                var travelItemList = new List<TravelItem>(travel.ItemList);

                _formsFactory.CreateTravelItemListView(this, travelItemList, travel.Id).ShowModaless();

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void OpenPreliminaryListWindow(Guid travelId)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var travel = travelRepository.GetTravel(travelId);
                var preliminaryList = new List<PreliminaryActivity>(travel.PreliminaryActivityList);

                _formsFactory.CreatePreliminaryActivityListView(this, preliminaryList, travel.Id).ShowModaless();

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void OpenCostListWindow(Guid travelId)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var travel = travelRepository.GetTravel(travelId);
                var costList = new List<TravelActivityWithCost>(travel.CostList);

                _formsFactory.CreateCostListView(this, costList, travel.Id).ShowModaless();

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void OpenTravelActivityListWindow(Guid travelId)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var travel = travelRepository.GetTravel(travelId);
                var travelActivityList = new List<TravelActivity>(travel.ActivityList);

                _formsFactory.CreateTravelActivityListView(this, travelActivityList, travel.Id).ShowModaless();

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void OpenAddTravelItemWindow(Guid travelId)
        {
            _formsFactory.CreateAddTravelItemView(this, travelId).ShowModaless();
        }

        public void OpenAddPreliminaryActivityWindow(Guid travelId)
        {
            _formsFactory.CreateAddPreliminaryItemView(this, travelId).ShowModaless();
        }

        public void AddTravelItem (AddTravelItemViewModel travelItemViewModel, Guid travelId)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var travel = travelRepository.GetTravel(travelId);
                travel.ItemList.Add(new TravelItem
                {
                    Name = travelItemViewModel.Name,
                    Description = travelItemViewModel.Description,
                    IsTaken = travelItemViewModel.IsTaken
                });

                travelRepository.UpdateTravel(travel);

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void AddPreliminaryActivity(AddPreliminaryActivityViewModel travelItemViewModel, Guid travelId)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var travel = travelRepository.GetTravel(travelId);
                travel.PreliminaryActivityList.Add(new PreliminaryActivity
                {
                    Name = travelItemViewModel.Name,
                    Description = travelItemViewModel.Description,
                    IsCompleted = travelItemViewModel.IsCompleted
                });

                travelRepository.UpdateTravel(travel);

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

        public void DeleteTravel(Guid travelId)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var travelRepository = RepositoriesFactory.CreateTravelRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                travelRepository.DeleteTravel(travelId);

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
