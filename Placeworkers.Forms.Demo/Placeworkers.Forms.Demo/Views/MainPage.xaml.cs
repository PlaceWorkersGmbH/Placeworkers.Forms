using Placeworkers.Forms.Demo.ViewModels;
using Xamarin.Forms;
using static Placeworkers.Forms.Demo.ViewModels.MainPageViewModel;

namespace Placeworkers.Forms.Demo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var navCell = sender as NavigationCell;
            if (BindingContext is MainPageViewModel viewModel && navCell != null)
            {
                var item = navCell.BindingContext as Item;
                if (item != null)
                {
                    viewModel.NavigationCommand.Execute(item.Page);
                }
            }
            List.SelectedItem = null;
        }
    }
}