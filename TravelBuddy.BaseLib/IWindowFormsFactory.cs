using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.Models.Repositories;

namespace TravelBuddy.BaseLib
{
    public interface IWindowFormsFactory
    {
        ILoginView CreateLoginView(IMainController mainController);
        IRegisterView CreateRegisterView(IMainController mainController);
        IMainView CreateMainView(IMainController mainController);
    }
}
