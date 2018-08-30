using System.Diagnostics;
using Placeworkers.Forms.Demo.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms.Internals;

namespace Placeworkers.Forms.Demo
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            Log.Listeners.Add(new DelegateLogListener((arg1, arg2) => Debug.WriteLine(string.Format("{0} - {1}", arg1, arg2))));
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

