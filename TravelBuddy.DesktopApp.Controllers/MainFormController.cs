using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelBuddy.BaseLib;
using TravelBuddy.DAL;
using TravelBuddy.DAL.Repositories;
using TravelBuddy.Models;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.DesktopApp.Controllers
{
    public class MainFormController : IMainController
    {
        private bool _defaultModelLoaded = false;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWindowFormsFactory _formsFactory;
        private readonly IUserRepository _userRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private User _loggedInUser;

        public MainFormController(IWindowFormsFactory formsFactory, IUnitOfWork unitOfWork, IUserRepository userRepo, ICurrencyRepository currencyRepo)
        {
            _formsFactory = formsFactory;
            _unitOfWork = unitOfWork;
            _userRepository = userRepo;
            _currencyRepository = currencyRepo;

            LoadDefaultModel();
        }

        public void LoadDefaultModel()
        {
            if (_defaultModelLoaded != false) return;
            try
            {
                _unitOfWork.BeginTransaction();
                _currencyRepository.CreateCurrenciesIfNoneExist();
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                MessageBox.Show(ex.Message, "TravelBuddy");
            }
                
            _defaultModelLoaded = true;
        }

        public bool IsUserLoggedIn()
        {
            return _loggedInUser == null;
        }

        public void Login(string username, string password)
        {
            var unitOfWork = new UnitOfWork();
            var userRepository = new UserRepository(unitOfWork);

            try
            {
                unitOfWork.BeginTransaction();

                var user = userRepository.GetUserByUsername(username);
                if (user.IsSamePassword(password))
                {
                    _loggedInUser = user;
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

                _loggedInUser = null;
                ShowLoginWindow();
                MessageBox.Show(ex.Message, "TravelBuddy");
            }
        }

        public void Logout()
        {
            _loggedInUser = null;
            ShowLoginWindow();
        }

        public void Register(string username, string email, string password)
        {
            var unitOfWork = new UnitOfWork();
            var userRepository = new UserRepository(unitOfWork);

            try
            { 
                unitOfWork.BeginTransaction();

                var user = new User
                {
                    Username = username,
                    Email = email,
                    Password = password
                };

                userRepository.AddUser(user);
                _loggedInUser = user;

                unitOfWork.Commit();

                ShowMainWindow();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                _loggedInUser = null;
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
