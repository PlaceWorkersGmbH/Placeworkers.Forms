using System;
namespace Placeworkers.Forms.Demo.ViewModels
{
    public class CheckboxViewModel
    {
        private bool _checked = true;
        public bool Checked
        {
            get => _checked;
            set => _checked = value;
        }
    }
}
