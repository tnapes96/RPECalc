using MvvmCross;
using MvvmCross.ViewModels;
using RPECalc.Core.Services;
using RPECalc.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace RPECalc.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IRPECalculationService, RPECalculationService>();

            bool firstTime = Preferences.Get("FirstTime", true);
            if (firstTime)
            {
                Preferences.Set("WeightUnit", "lbs");
                Preferences.Set("RoundTo", 5.0);
                Preferences.Set("FirstTime", false);
            }

            RegisterAppStart<RPEChartViewModel>(); 
        }
    }
}
