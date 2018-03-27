using Prism.Unity;
using Placeworkers.Forms.Demo.Views;
using Prism;
using Prism.Ioc;

namespace Placeworkers.Forms.Demo
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer) { }

		protected override void OnInitialized()
		{
			InitializeComponent();
			NavigationService.NavigateAsync("NavigationView/MainPage");
		}

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<NavigationView>();
            containerRegistry.RegisterForNavigation<DateTimePickerView>();
            containerRegistry.RegisterForNavigation<NavigationButtonView>();
            containerRegistry.RegisterForNavigation<CheckboxView>();
        }
	}
}

