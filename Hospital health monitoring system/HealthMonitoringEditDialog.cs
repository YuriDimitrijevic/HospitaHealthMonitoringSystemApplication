using HospitalHealthMonitoringShared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalHealthMonitoringSystem
{
    public partial class HealthMonitoringEditDialog : Form
    {
        BindingSource bsItem = new BindingSource(typeof(BedViewModel), null);

        public HealthMonitoringEditDialog(BedModel value)
        {
            InitializeComponent();

            txtBedId.DataBindings.Add(nameof(Text), bsItem, nameof(BedViewModel.Id), true, DataSourceUpdateMode.Never);
            txtBPM.DataBindings.Add(nameof(Text), bsItem, nameof(BedViewModel.BreathingRate), true, DataSourceUpdateMode.OnPropertyChanged);
            txtBreathingDuration.DataBindings.Add(nameof(Text), bsItem, nameof(BedViewModel.BreathDuration), true, DataSourceUpdateMode.OnPropertyChanged);
            txtOxygenConcentration.DataBindings.Add(nameof(Text), bsItem, nameof(BedViewModel.OxygenPercent), true, DataSourceUpdateMode.OnPropertyChanged);
            txtAirPressure.DataBindings.Add(nameof(Text), bsItem, nameof(BedViewModel.AirPressure), true, DataSourceUpdateMode.OnPropertyChanged);

            Bed = value;
        }        

        BedModel _Bed;
        public BedModel Bed
        {
            get => _Bed;
            set
            {
                if (!Equals(_Bed, value))
                {
                    bsItem.DataSource = new BedViewModel(value);
                    _Bed = value;

                    OnBedChanged(EventArgs.Empty);
                }
            }
        }
        protected virtual void OnBedChanged(EventArgs e) => BedChanged?.Invoke(this, e);
        public EventHandler BedChanged;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bsItem.Current as BedViewModel).AirPressure == 0)
                    throw new Exception("You need to insert air pressure value!");

                if ((bsItem.Current as BedViewModel).BreathDuration == 0)
                    throw new Exception("You need to insert breath duration value!");

                if ((bsItem.Current as BedViewModel).BreathingRate == 0)
                    throw new Exception("You need to insert breathing rate value!");

                if ((bsItem.Current as BedViewModel).OxygenPercent == 0)
                    throw new Exception("You need to insert oxygen percent value!");

                if ((bsItem.Current as BedViewModel).UpdateData())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException?.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
