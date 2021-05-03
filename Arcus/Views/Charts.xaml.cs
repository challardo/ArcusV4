using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Arcus.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Charts : ContentPage
    {
       ChartView chartView;
        public Charts()
        {
            InitializeComponent();
              chartView = (ChartView)FindByName("chart");
           // chartView = (ChartView)FindByName("chartView");

            DrawChat();
        }
       public void DrawChat()
        {
            var entries = new[]
            {
             new ChartEntry(212)
               {
                 Label = "UWP",
                 ValueLabel = "112",
                 Color = SKColor.Parse("#2c3e50")
               },
              new ChartEntry(248)
                  {
                    Label = "Android",
                   ValueLabel = "648",
                 Color = SKColor.Parse("#77d065")
                  },
             new ChartEntry(128)
                 {
                  Label = "iOS",
                 ValueLabel = "428",
                 Color = SKColor.Parse("#b455b6")
                     },
                 new ChartEntry(514)
                 {
                  Label = "Forms",
                   ValueLabel = "214",
                   Color = SKColor.Parse("#3498db")
                }
                    };
            var chart = new PieChart() { Entries = entries, LabelTextSize = 30f };
            chartView.Chart = chart;
        }


    }
}