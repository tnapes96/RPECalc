using MvvmCross;
using MvvmCross.ViewModels;
using RPECalc.Core.Services;
using RPECalc.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPECalc.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<IRPECalculationService, RPECalculationService>();

            RegisterAppStart<RPEChartViewModel>();
        }
    }
}
