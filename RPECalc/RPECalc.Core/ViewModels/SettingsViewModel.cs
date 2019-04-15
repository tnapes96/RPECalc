using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace RPECalc.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {


        public string WeightUnit
        {
            get => Preferences.Get(nameof(WeightUnit), "lbs");
            set
            {
                Preferences.Set(nameof(WeightUnit), value);
                RaisePropertyChanged(nameof(WeightUnit));
            }
        }
    }
}
