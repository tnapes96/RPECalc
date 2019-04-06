using MvvmCross.Forms.Views;
using RPECalc.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RPECalc.Forms.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RPEChartView : MvxContentPage<RPEChartViewModel>
	{
		public RPEChartView ()
		{
			InitializeComponent ();
		}
	}
}