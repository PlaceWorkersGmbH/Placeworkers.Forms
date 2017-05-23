using Prism.Unity;
using Placeworkers.Forms.Demo.Views;

namespace Placeworkers.Forms.Demo
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
			//var assembly = typeof(Placeworkers.Forms.NavigationCell).Assembly;
			NavigationService.NavigateAsync("NavigationView/MainPage");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<NavigationView>();
            Container.RegisterTypeForNavigation<DateTimePickerView>();
			Container.RegisterTypeForNavigation<NavigationButtonView>();
            Container.RegisterTypeForNavigation<CheckboxView>();
		}
	}
}

