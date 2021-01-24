using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Punch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punch.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IUserTaskService, UserTaskService>();
            SimpleIoc.Default.Register<UserTasksViewModel>();
            SimpleIoc.Default.Register<ChronometerViewModel>();
        }

        public UserTasksViewModel UserTask => ServiceLocator.Current.GetInstance<UserTasksViewModel>();
        public ChronometerViewModel Chronometer => ServiceLocator.Current.GetInstance<ChronometerViewModel>();
    }
}
