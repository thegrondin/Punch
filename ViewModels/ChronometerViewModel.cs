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

        public enum ChronometerStates { Playing, Paused, Cancelled, Done}

        private Visibility _chronometerVisibility;
        private Visibility _playBtnVisibility;
        private Visibility _pauseBtnVisibility;
        private Visibility _cancelBtnVisibility;
        private Visibility _doneBtnVisibility;

        public Visibility ChronometerVisibility
        {
            get { return _chronometerVisibility; }
            set { Set(ref _chronometerVisibility, value); }
        }

        public Visibility PlayBtnVisibility
        {
            get { return _playBtnVisibility; }
            set { Set(ref _playBtnVisibility, value); }
        }

        public Visibility PauseBtnVisibility
        {
            get { return _pauseBtnVisibility; }
            set { Set(ref _pauseBtnVisibility, value); }
        }

        public Visibility CancelBtnVisibility
        {
            get { return _cancelBtnVisibility; }
            set { Set(ref _cancelBtnVisibility, value); }
        }

        public Visibility DoneBtnVisibility
        {
            get { return _doneBtnVisibility; }
            set { Set(ref _doneBtnVisibility, value); }
        }

        public ChronometerViewModel()
        {

            StartChronometerCommand = new RelayCommand(StartChronometer, CanStartChronometer);
            PauseChronometerCommand = new RelayCommand(PauseChronometer, CanPauseChronometer);
            CancelChronometerCommand = new RelayCommand(CancelChronometer, CanCancelChronometer);
            DoneChronometerCommand = new RelayCommand(DoneChronometer, CanDoneChronometer);

            ChronometerVisibility = Visibility.Collapsed;
            PlayBtnVisibility = Visibility.Visible;
            PauseBtnVisibility = Visibility.Collapsed;
            CancelBtnVisibility = Visibility.Collapsed;
            DoneBtnVisibility = Visibility.Collapsed;
        }

        public RelayCommand StartChronometerCommand { get; private set; }
        public RelayCommand PauseChronometerCommand { get; private set; }
        public RelayCommand CancelChronometerCommand { get; private set; }
        public RelayCommand DoneChronometerCommand { get; private set; }

        private void StartChronometer()
        {
            ChronometerVisibility = Visibility.Visible;
            PlayBtnVisibility = Visibility.Collapsed;
            PauseBtnVisibility = Visibility.Visible;
            CancelBtnVisibility = Visibility.Visible;
            DoneBtnVisibility = Visibility.Collapsed;
        }

        private bool CanStartChronometer()
        {
            return true;
        }

        private void PauseChronometer()
        {
            ChronometerVisibility = Visibility.Visible;
            PlayBtnVisibility = Visibility.Visible;
            PauseBtnVisibility = Visibility.Collapsed;
            CancelBtnVisibility = Visibility.Collapsed;
            DoneBtnVisibility = Visibility.Visible;
        }

        private bool CanPauseChronometer()
        {
            return true;
        }

        private void CancelChronometer()
        {
            HideChronometer();
        }

        private bool CanCancelChronometer()
        {
            return true;
        }

        private void DoneChronometer()
        {
            HideChronometer();
        }

        private bool CanDoneChronometer()
        {
            return true;
        }

        private void HideChronometer()
        {
            ChronometerVisibility = Visibility.Collapsed;
            PlayBtnVisibility = Visibility.Visible;
            PauseBtnVisibility = Visibility.Collapsed;
            CancelBtnVisibility = Visibility.Collapsed;
            DoneBtnVisibility = Visibility.Collapsed;
        }

       
    }
}
