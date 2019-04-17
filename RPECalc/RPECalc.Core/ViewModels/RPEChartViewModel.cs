using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RPECalc.Core.Models;
using RPECalc.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RPECalc.Core.ViewModels
{
    public class RPEChartViewModel : MvxViewModel
    {
        readonly IRPECalculationService _rpeCalculationService;
        readonly IMvxNavigationService _navigationService;

        public RPEChartViewModel(IRPECalculationService rpeCalculation, IMvxNavigationService navigationService)
        {
            _rpeCalculationService = rpeCalculation;
            _navigationService = navigationService;

            CalculateMaxCommand = new MvxCommand(CalculateMax);

            ShowSettingsViewModelCommand = new MvxAsyncCommand(ShowSettingsViewModel);
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _lsreps = 6;
            _lsrpe = 8;
            _lsweight = 135;
            CalculateMax();

            _chartReps = 1;
        }

        

        //ls = last set
        private double _lsrpe;
        public double LSRpe
        {
            get => _lsrpe;
            set
            {
                SetProperty(ref _lsrpe, value);
            }
        }

        private int _lsreps;
        public int LSReps
        {
            get => _lsreps;
            set
            {
                SetProperty(ref _lsreps, value);
            }
        }

        private double _lsweight;
        public double LSWeight
        {
            get => _lsweight;
            set
            {
                SetProperty(ref _lsweight, value);
            }
        }

        private double _max;
        public double Max
        {
            get => _max;
            set
            {
                SetProperty(ref _max, value);
                CalculateRpeChartPerRep();
            }
        }

        private int _chartReps;
        public int ChartReps
        {
            get => _chartReps;
            set
            {
                SetProperty(ref _chartReps, value);
                CalculateRpeChartPerRep();
            }
        }

        public string WeightUnit
        {
            get => Preferences.Get(nameof(WeightUnit), "ERR");
        }

        private MvxObservableCollection<LoadInfo> _rpeChartListPerRep;
        public MvxObservableCollection<LoadInfo> RpeChartListPerRep
        {
            get => _rpeChartListPerRep;
            set
            {
                SetProperty(ref _rpeChartListPerRep, value);
            }
        }

        // Commands
        public IMvxCommand CalculateMaxCommand { get; private set; } 
        public IMvxAsyncCommand ShowSettingsViewModelCommand { get; private set; }

        private async Task ShowSettingsViewModel()
        {
            await _navigationService.Navigate<SettingsViewModel>();
        }

        // Methods
        private void CalculateMax()
        {
            Max = _rpeCalculationService.OneRepMax(LSWeight, LSReps, LSRpe);
        }

        private void CalculateRpeChartPerRep()
        {
            MvxObservableCollection<LoadInfo> temp = new MvxObservableCollection<LoadInfo>(_rpeCalculationService.CalculateLoadForRep(Max, ChartReps));
            RpeChartListPerRep = temp;
        }


        public override void ViewAppearing()
        {
            RaisePropertyChanged(() => WeightUnit);
        }
    }
}
