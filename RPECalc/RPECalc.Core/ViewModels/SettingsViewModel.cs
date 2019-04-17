using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace RPECalc.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        readonly IMvxNavigationService _navigationService;
        public SettingsViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string WeightUnit
        {
            get => Preferences.Get(nameof(WeightUnit), "ERR");
            set
            {
                Preferences.Set(nameof(WeightUnit), value);
                RaisePropertyChanged(nameof(WeightUnit));
            }
        }

        public double RoundTo
        {
            get => Preferences.Get(nameof(RoundTo), 0.0);
            
            set
            {
                Preferences.Set(nameof(RoundTo), value);
                RaisePropertyChanged(nameof(RoundTo));
            }
        }
    }
}
