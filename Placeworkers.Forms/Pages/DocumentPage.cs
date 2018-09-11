using Xamarin.Forms;
namespace Placeworkers.Forms
{
    public class DocumentPage : Page
    {
        public static readonly BindableProperty FilePathProperty = BindableProperty.Create(nameof(FilePath), typeof(string), typeof(DocumentPage), null);
        public string FilePath
        {
            get => (string)GetValue(FilePathProperty);
            set => SetValue(FilePathProperty, value);
        }

        public DocumentPage() { }
        public DocumentPage(string filePath) => FilePath = filePath;
    }
}