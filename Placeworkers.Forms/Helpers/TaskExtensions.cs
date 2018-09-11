using System;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace Placeworkers.Forms
{
    public static class TaskExtensions
    {
#pragma warning disable RECS0165 // Asynchronous methods should return a Task instead of void
        public static async void FireAndForgetSafeAsync(this Task task, IExceptionHandler handler = null)
#pragma warning restore RECS0165 // Asynchronous methods should return a Task instead of void
        {
            try { await task; }
            catch (Exception ex) { handler?.HandleException(ex); }
        }
    }

    public interface IExceptionHandler
    {
        void HandleException(Exception ex);
    }

    public class DialogExceptionHandler : IExceptionHandler
    {
        readonly IUserDialogs _userDialogs;

        public DialogExceptionHandler(IUserDialogs userDialogs) => _userDialogs = userDialogs;

        public void HandleException(Exception ex) => _userDialogs.Alert(ex.Message);
    }
}