using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Placeworkers.Forms.Demo.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public List<Item> ItemsSource { get; }

        public DelegateCommand<string> NavigationCommand;

        public MainPageViewModel(INavigationService navigationService)
        {
            NavigationCommand = new DelegateCommand<string>(async (page)=>{
                await navigationService.NavigateAsync(page);
            });
            ItemsSource = new List<Item> { 
                new Item { Title = "DateTimePicker", Detail="Entry element like a DatePicker", Page="DateTimePickerView" },
				new Item { Title = "NavigationButton", Detail="Button for navigation purposes", Page="NavigationButtonView" },
				new Item { Title = "Checkbox", Detail="Checkbox with Text", Page="CheckboxView" }
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

