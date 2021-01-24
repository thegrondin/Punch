using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Punch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Punch.ViewModels
{
    public class ChronometerViewModel : ViewModelBase
    {


        private Visibility _started;
        private Visibility _stopped;

        public Visibility Started
        {
            get { return _started; }
            set { Set(ref _started, value); }
        }

        public Visibility Stopped
        {
            get { return _stopped; }
            set { Set(ref _stopped, value); }
        }

        public ChronometerViewModel()
        {

            StartChronometerCommand = new RelayCommand(StartChronometer, CanStartChronometer);
            StopChronometerCommand = new RelayCommand(StopChronometer, CanStopChronometer);

            Started = Visibility.Collapsed;
            Stopped = Visibility.Visible;
        }

        public RelayCommand StartChronometerCommand { get; private set; }
        public RelayCommand StopChronometerCommand { get; private set; }

        private bool CanStartChronometer ()
        {
            return true;
        }

        private void StartChronometer()
        {
            Started = Visibility.Visible;
            Stopped = Visibility.Collapsed;
        }

        private bool CanStopChronometer()
        {
            return true;
        }

        private void StopChronometer()
        {
            Stopped = Visibility.Visible;
            Started = Visibility.Collapsed;
        }
    }
}
