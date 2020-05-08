using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalHealthMonitoringSystem
{
    public class NumericTextBox : TextBox
    {
        protected override void OnGotFocus(EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.Text))
            {
                this.SelectionStart = 0;
                this.SelectionLength = this.Text.Length;
            }

            base.OnGotFocus(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (AllowDecimalNotation)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        bool _AllowDecimalNotation;

        [DefaultValue(false)]
        public virtual bool AllowDecimalNotation
        {
            get => _AllowDecimalNotation;
            set
            {
                if (!Equals(_AllowDecimalNotation, value))
                {
                    _AllowDecimalNotation = value;

                    OnAllowDecimalNotationChanged(EventArgs.Empty);
                }
            }
        }

        protected virtual void OnAllowDecimalNotationChanged(EventArgs e) => AllowDecimalNotationChanged?.Invoke(this, e);
        public event EventHandler AllowDecimalNotationChanged;
    }
}
