using Prism.Mvvm;
using Prism.Navigation;
using System.IO;
namespace Placeworkers.Forms.Demo.ViewModels
{
    public class DocumentViewModel : BindableBase, INavigatingAware
    {
        string _title;
        public string Title
        {
            get => _title;
            private set
            {
                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        string _filePath;
        public string FilePath
        {
            get => _filePath;
            private set
            {
                _filePath = value;
                RaisePropertyChanged(nameof(FilePath));
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.TryGetValue("filePath", out string filePath))
            {
                FilePath = filePath;
                Title = Path.GetFileName(filePath);
            }
        }
    }
}