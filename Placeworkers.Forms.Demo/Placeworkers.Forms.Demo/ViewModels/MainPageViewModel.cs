using System.Collections.Generic;
using System.IO;
using System.Net;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace Placeworkers.Forms.Demo.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public List<Item> ItemsSource { get; }

        public DelegateCommand<string> NavigationCommand;

        public MainPageViewModel(INavigationService navigationService, IExceptionHandler exceptionHandler)
        {
            NavigationCommand = new DelegateCommand<string>((page) =>
            {
                if (page.Contains("."))
                {
                    var fileName = Path.GetFileName(page);
                    var filePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, fileName);
                    if (!File.Exists(filePath))
                    {
                        var webClient = new WebClient();
                        webClient.DownloadFile(page, filePath);
                    }
                    navigationService.NavigateAsync("DocumentView", new NavigationParameters { { "filePath", filePath } });
                    //var p = ((IPageAware)navigationService).Page;
                    //var document = new DocumentPage(filePath) { Title = fileName };
                    //p.Navigation.PushAsync(document).FireAndForgetSafeAsync(exceptionHandler);
                    return;
                }
                navigationService.NavigateAsync(page).FireAndForgetSafeAsync(exceptionHandler);
            });
            ItemsSource = new List<Item> {
                new Item { Title = "DateTimePicker", Detail="Entry element like a DatePicker", Page="DateTimePickerView" },
                new Item { Title = "NavigationButton", Detail="Button for navigation purposes", Page="NavigationButtonView" },
                new Item { Title = "Checkbox", Detail="Checkbox with Text", Page="CheckboxView" },
                new Item { Title = "DocumentView", Detail="Display pdf", Page="http://www.orimi.com/pdf-test.pdf" },
                new Item { Title = "DocumentView", Detail="Display docx", Page="http://www.snee.com/xml/xslt/sample.doc" }
            };
        }

        public class Item
        {
            public string Title { get; set; }
            public string Detail { get; set; }
            public string Page { get; set; }
        }
    }
}