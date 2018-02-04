using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelBuddy.BaseLib;
using TravelBuddy.DAL;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.DesktopApp.Controllers
{
    public class MainFormController
    {
        private bool _defaultModelLoaded = false;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWindowFormsFactory _formsFactory;
        private readonly IUserRepository _userRepository;
        private readonly ICurrencyRepository _currencyRepository;
        public MainFormController(IWindowFormsFactory formsFactory, IUnitOfWork unitOfWork, IUserRepository userRepo, ICurrencyRepository currencyRepo)
        {
            _formsFactory = formsFactory;
            _unitOfWork = unitOfWork;
            _userRepository = userRepo;
            _currencyRepository = currencyRepo;
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
                MessageBox.Show("EXCEPTION: ", ex.Message);
            }
                
            _defaultModelLoaded = true;
        }
    }
}
