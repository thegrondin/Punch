﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Punch.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Windows.UI.Xaml;

namespace Punch.ViewModels
{
    public class ChronometerViewModel : ViewModelBase
    {

        public enum ChronometerStates { Playing, Paused, Cancelled, Done}

        private ChronometerStates CurrentState { get; set; }

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

        private DispatcherTimer _timer;
        private DateTime _startTime;
        private DateTime _pauseStartTime;

        private TimeSpan _elapsedTime;
        public TimeSpan ElapsedTime {
            get { return _elapsedTime; }
            set { Set(ref _elapsedTime, value); }
        }


        private TimeSpan _currentPausedTime;
        private TimeSpan _accumulatedPauseTime;


        private string _elapsedTimeString;
        public string ElapsedTimeString
        {
            get { return _elapsedTimeString; }
            set { Set(ref _elapsedTimeString, value); }
        }

        public ChronometerViewModel()
        {

            StartChronometerCommand = new RelayCommand(StartChronometer, CanStartChronometer);
            PauseChronometerCommand = new RelayCommand(PauseChronometer, CanPauseChronometer);
            CancelChronometerCommand = new RelayCommand(CancelChronometer, CanCancelChronometer);
            DoneChronometerCommand = new RelayCommand(DoneChronometer, CanDoneChronometer);

            _timer = new DispatcherTimer();

           

            _timer.Tick += new EventHandler<object>(UpdateTimeEvent);
            _timer.Interval = new TimeSpan(0, 0, 1);           
            
            ChronometerVisibility = Visibility.Collapsed;
            PlayBtnVisibility = Visibility.Visible;
            PauseBtnVisibility = Visibility.Collapsed;
            CancelBtnVisibility = Visibility.Collapsed;
            DoneBtnVisibility = Visibility.Collapsed;
        }

        public  void UpdateTimeEvent(object source, object e)
        {

            if (CurrentState == ChronometerStates.Paused)
            {
                _currentPausedTime = (DateTime.Now - _pauseStartTime);
            }

            ElapsedTime = (DateTime.Now - _startTime) - (_currentPausedTime + _accumulatedPauseTime);
            ElapsedTimeString = ElapsedTime.ToString();
        }

        public RelayCommand StartChronometerCommand { get; private set; }
        public RelayCommand PauseChronometerCommand { get; private set; }
        public RelayCommand CancelChronometerCommand { get; private set; }
        public RelayCommand DoneChronometerCommand { get; private set; }

        private void StartChronometer()
        {

            if (CurrentState != ChronometerStates.Paused)
            {
                _startTime = DateTime.Now;
            }

            CurrentState = ChronometerStates.Playing;

            _timer.Start();

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

            CurrentState = ChronometerStates.Paused;

            _pauseStartTime = DateTime.Now;
            _accumulatedPauseTime += _currentPausedTime;

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
            CurrentState = ChronometerStates.Cancelled;
            ResetChronometer();
            HideChronometer();
        }

        private bool CanCancelChronometer()
        {
            return true;
        }

        private void DoneChronometer()
        {
            CurrentState = ChronometerStates.Done;
            ResetChronometer();
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

        private void ResetChronometer()
        {
            _timer.Stop();
            ElapsedTime = new TimeSpan();
            ElapsedTimeString = "00:00:00";
        }

       
    }
}
