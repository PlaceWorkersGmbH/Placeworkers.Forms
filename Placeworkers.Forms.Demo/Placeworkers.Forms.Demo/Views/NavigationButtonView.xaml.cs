
using System;
using Xamarin.Forms;

namespace Placeworkers.Forms.Demo
{
    public partial class NavigationButtonView : ContentPage
    {
        public NavigationButtonView() => InitializeComponent();

        public void Handle_Pressed(object sender, EventArgs e)
        {
            //B1.Style = (Style)Application.Current.Resources["NavigationButton2"];
            //B2.Style = (Style)Application.Current.Resources["NavigationButton2"];
            //B3.Style = (Style)Application.Current.Resources["NavigationButton2"];
            B1.Padding = new Thickness(30, 0, 10, 0);
            B2.Padding = new Thickness(40, 0, 10, 0);
            B3.Padding = new Thickness(50, 0, 10, 0);
            B1.Padding = new Thickness(30, 0, 10, 0);
            B2.Padding = new Thickness(40, 0, 10, 0);
            B3.Padding = new Thickness(50, 0, 10, 0);
        }
    }
}