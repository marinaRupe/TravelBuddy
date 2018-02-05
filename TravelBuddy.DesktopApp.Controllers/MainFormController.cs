using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelBuddy.BaseLib;
using TravelBuddy.BaseLib.Factories;
using TravelBuddy.DAL;
using TravelBuddy.DAL.Repositories;
using TravelBuddy.Models;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.DesktopApp.Controllers
{
    public class MainFormController : IMainController
    {
        private bool _defaultModelLoaded = false;
        private readonly IWindowFormsFactory _formsFactory;
        public Guid LoggedInUserId { get; private set; }
        private bool _isUserLoggedIn = false;

        public MainFormController(IWindowFormsFactory formsFactory)
        {
            _formsFactory = formsFactory;

            LoadDefaultModel();
        }

        public void LoadDefaultModel()
        {
            if (_defaultModelLoaded != false) return;

            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var currencyRepository = RepositoriesFactory.CreateCurrencyRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();
                currencyRepository.CreateCurrenciesIfNoneExist();
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                MessageBox.Show(ex.Message, "TravelBuddy");
            }
                
            _defaultModelLoaded = true;
        }

        public bool IsUserLoggedIn()
        {
            return _isUserLoggedIn;
        }

        public void Login(string username, string password)
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var userRepository = RepositoriesFactory.CreateUserRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var user = userRepository.GetUserByUsername(username);
                if (user.IsSamePassword(password))
                {
                    LoggedInUserId = user.Id;
                    _isUserLoggedIn = true;
                    unitOfWork.Commit();

                    ShowMainWindow();
                }
                else
                {
                    throw new Exception("Username or password is not correct!");
                }
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                _isUserLoggedIn = false;
                ShowLoginWindow();
                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void Logout()
        {
            _isUserLoggedIn = false;
            ShowLoginWindow();
        }

        public void Register(string username, string email, string password)
        {

            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var userRepository = RepositoriesFactory.CreateUserRepository(unitOfWork);

            try
            { 
                unitOfWork.BeginTransaction();

                var user = new User
                {
                    Username = username,
                    Email = email,
                };

                user.SetPassword(password);

                userRepository.AddUser(user);
                LoggedInUserId = user.Id;
                _isUserLoggedIn = true;

                unitOfWork.Commit();

                ShowMainWindow();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                _isUserLoggedIn = false;
                ShowRegisterWindow();
                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void OpenTravelListWindow()
        {
            var unitOfWork = UnitOfWorkFactory.CreateUnitOfWork();
            var userRepository = RepositoriesFactory.CreateUserRepository(unitOfWork);

            var travelController = new TravelController(this, _formsFactory);

            try
            {
                unitOfWork.BeginTransaction();

                var user = userRepository.GetUser(LoggedInUserId);
                var travels = user.Travels;

                unitOfWork.Commit();

                var travelListView = _formsFactory.CreateTravelListView(travelController, travels);
                travelListView.ShowModaless();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                ShowRegisterWindow();
                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        private void ShowLoginWindow()
        {
            var loginView = _formsFactory.CreateLoginView(this);
            loginView.ShowModaless();
        }

        public void ShowRegisterWindow()
        {
            var registerView = _formsFactory.CreateRegisterView(this);
            registerView.ShowModaless();
        }

        private void ShowMainWindow()
        {
            var mainView = _formsFactory.CreateMainView(this);
            mainView.ShowModaless();
        }
    }
}
