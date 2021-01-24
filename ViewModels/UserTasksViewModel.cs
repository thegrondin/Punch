using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Punch.Models;
using Punch.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace Punch.ViewModels
{
    public class UserTasksViewModel : ViewModelBase
    {
        private readonly IUserTaskService _userTaskService;

        private bool _chronoStarted;

        public bool ChronoStarted { 
            get { return _chronoStarted; } 
            set { Set(ref _chronoStarted, value); } 
        }

        public UserTasksViewModel(IUserTaskService userTaskService)
        {

            DisplayAddTaskBoxCommand = new RelayCommand(DisplayAddTaskBox, CanDisplayAddTaskBox);
            AddUserTaskCommand = new RelayCommand(AddUserTask, CanAddUserTask);

            _userTaskService = userTaskService;

            var asyncTask = _userTaskService.GetAll();

            asyncTask.Wait();
            UserTasks = new ObservableCollection<UserTask>(asyncTask.Result);
            CurrentUserTask = new UserTask();
        }

        private ObservableCollection<UserTask> _userTasks;

        public ObservableCollection<UserTask> UserTasks
        {
            get { return _userTasks; }
            set {
                Set(ref _userTasks, value);
            }
        }

        private UserTask _currentUserTask;

        public UserTask CurrentUserTask
        {
            get { return _currentUserTask; }
            set
            {
                Set(ref _currentUserTask, value);
            }
        }

        public RelayCommand AddUserTaskCommand { get; private set; }

        private bool CanAddUserTask()
        {
            return true;
        }

        private void AddUserTask()
        {
            UserTasks.Add(CurrentUserTask);
        }

        public RelayCommand DisplayAddTaskBoxCommand { get; private set; }

        private bool CanDisplayAddTaskBox()
        {
            return true;
        }

        private async void DisplayAddTaskBox()
        {

            AppWindow appWindow = await AppWindow.TryCreateAsync();

            Frame appWindowContentFrame = new Frame();
        
            appWindowContentFrame.Navigate(typeof(AddUserTask));

            ElementCompositionPreview.SetAppWindowContent(appWindow, appWindowContentFrame);
            await appWindow.TryShowAsync();

        }
    }
}
