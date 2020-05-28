using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalHealthMonitoringShared;
using Newtonsoft.Json;

namespace HospitalHealthMonitoringSystem
{
    public partial class HealthMonitoringDialog : Form
    {

        //Test comment for the test branch
        ToolStripButton btnSetBedParameters;

        CancellationTokenSource _cts = new CancellationTokenSource();

        BindingSource bsList = new BindingSource(typeof(BedViewModel), null);

        public HealthMonitoringDialog()
        {
            InitializeComponent();

            BindToolStripMenu();

            bsList.CurrentChanged += (s, e) => SetSelectedItem();
            bsList.DataSourceChanged += (s, e) =>
            {
                SetButtonEnabledState();
                SetSelectedItem();
            };

            dgList.DoubleClick += (s, e) => btnSetBedParameters.PerformClick();

            dgList.CellPainting += dgList_CellPainting;

            dgList.DataSource = bsList;

            LoadBeds();

            LoadSafeValues();

            SetButtonEnabledState();
        }

        List<BedModel> _Beds = new List<BedModel>();
        public List<BedModel> Beds
        {
            get => _Beds;
            set
            {
                if (!Equals(_Beds, value))
                {
                    bsList.DataSource = value.Select(x => new BedViewModel(x)).ToList();
                    _Beds = value;

                    OnBedsChanged(EventArgs.Empty);
                }
            }
        }
        protected virtual void OnBedsChanged(EventArgs e) => BedsChanged?.Invoke(this, e);
        public EventHandler BedsChanged;

        SafeValues _SafeValues;
        public SafeValues SafeValues
        {
            get => _SafeValues;
            set
            {
                if (!Equals(_SafeValues, value))
                {
                    _SafeValues = value;
                }
            }
        }

        BedViewModel _SelectedItem;
        public BedViewModel SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (!Equals(_SelectedItem, value))
                {
                    _SelectedItem = value;

                    OnSelectedItemChanged(EventArgs.Empty);
                }
            }
        }
        protected virtual void OnSelectedItemChanged(EventArgs e) => SelectedItemChanged?.Invoke(this, e);
        public EventHandler SelectedItemChanged;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!e.Handled)
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                    case Keys.Enter:
                        btnSetBedParameters.PerformClick();
                        break;

                    default:
                        base.OnKeyDown(e);
                        return;
                }

                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            base.OnKeyDown(e);
        }

        private void dgList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                var item = (BedViewModel)dgList.Rows[e.RowIndex].DataBoundItem;
                var column = dgList.Columns[e.ColumnIndex];

                if (column.Name == nameof(BedViewModel.BreathDuration))
                {
                    if (item.BreathDuration > SafeValues.MinBreathDuration && item.BreathDuration < SafeValues.MaxBreathDuration)
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }

                if (column.Name == nameof(BedViewModel.BreathingRate))
                {
                    if (item.BreathingRate < SafeValues.MaxBreathingRate && item.BreathingRate > SafeValues.MinBreathingRate)
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }

                if (column.Name == nameof(BedViewModel.HeartRate))
                {
                    if (item.HeartRate > SafeValues.MinHeartRate && item.HeartRate < SafeValues.MaxHeartRate)
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }

                if (column.Name == nameof(BedViewModel.SystolicBloodPressure))
                {
                    if (item.SystolicBloodPressure > SafeValues.MinSystolicBloodPressure && item.SystolicBloodPressure < SafeValues.MaxSystolicBloodPressure)
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }

                if (column.Name == nameof(BedViewModel.DiastolicBloodPressure))
                {
                    if (item.DiastolicBloodPressure > SafeValues.MinDiastolicBloodPressure && item.DiastolicBloodPressure < SafeValues.MaxDiastolicBloodPressure)
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void BindToolStripMenu()
        {
            btnSetBedParameters = new ToolStripButton("Set parameters", null, (s, e) => SetBedParameters()) { ToolTipText = "Shortcut: F1, Enter, Double click" };

            toolStripMenu.Items.AddRange(new ToolStripItem[]
            {
                btnSetBedParameters,
                new ToolStripSeparator(),
            });
        }

        async Task StartAutoRefreshingData()
        {
            try
            {
                while (!_cts.IsCancellationRequested)
                {
                    LoadBedDevices();
                    dgList.Refresh();

                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                }
            }
            catch { throw; }
        }

        void LoadBedDevices()
        {
            try
            {
                BedModel item = new BedModel();

                foreach (var bed in Beds)
                {
                    var serializedVentilatorData = Client.Connect(SharedHelper.GetLocalIPAddress(), bed.VentilatorDevice.PortNumber);
                    var serializedCDMData = Client.Connect(SharedHelper.GetLocalIPAddress(), bed.CardioDevice.PortNumber);

                    item.VentilatorDevice = JsonConvert.DeserializeObject<VentilatorDeviceModel>(serializedVentilatorData);
                    item.CardioDevice = JsonConvert.DeserializeObject<CardioDeviceModel>(serializedCDMData);

                    bsList.Cast<BedViewModel>().Where(x => x.Id == bed.Id).FirstOrDefault().WriteData(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException?.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        async void LoadBeds()
        {
            try
            {
                var bedsDescriptorPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + @"\icu_beds_descriptor.json";
                var bedData = JsonConvert.DeserializeObject<List<BedModel>>(File.ReadAllText(bedsDescriptorPath));

                Beds = bedData;

                UpdateStatus();

                StartServers();

                await StartAutoRefreshingData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException?.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void StartServers()
        {
            string myPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            string myDir = Path.GetDirectoryName(myPath);

            string ventilatorServerPath = System.IO.Path.Combine(myDir, nameof(VentilatorServerDevice) + ".exe");
            string CDMServerPath = Path.Combine(myDir, nameof(CMDServerDevice) + ".exe");

            foreach (var bed in Beds)
            {
                Process.Start(ventilatorServerPath, bed.VentilatorDevice.PortNumber.ToString());
                Process.Start(CDMServerPath, bed.CardioDevice.PortNumber.ToString());
            }
        }

        private void LoadSafeValues()
        {
            var safeValuesPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + @"\icu_safe_values.json";
            SafeValues = JsonConvert.DeserializeObject<SafeValues>(File.ReadAllText(safeValuesPath));
        }

        void SetBedParameters()
        {
            try
            {
                if (SelectedItem == null)
                    return;

                using (var f = new HealthMonitoringEditDialog(SelectedItem.Value))
                {
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        _cts.Cancel();
                        _cts = new CancellationTokenSource();

                        var serializedVentilatorData = Client.Connect(SharedHelper.GetLocalIPAddress(), f.Bed.VentilatorDevice.PortNumber, JsonConvert.SerializeObject(f.Bed.VentilatorDevice));

                        Task.Run(() => StartAutoRefreshingData());

                        f.Bed.VentilatorDevice = JsonConvert.DeserializeObject<VentilatorDeviceModel>(serializedVentilatorData);

                        bsList.Cast<BedViewModel>().Where(x => x.Id == f.Bed.Id).FirstOrDefault().WriteData(f.Bed);
                        dgList.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException?.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        void SetButtonEnabledState()
        {
            btnSetBedParameters.Enabled = SelectedItem != null;
        }

        private void SetSelectedItem()
        {
            SelectedItem = bsList.Current as BedViewModel;
        }

        void UpdateStatus()
        {
            lblItemCount.Text = "Total beds: " + Beds.Count;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            bsList.Dispose();

            Process.GetProcesses().Where(p => p.ProcessName == nameof(CMDServerDevice) || p.ProcessName == nameof(VentilatorServerDevice)).ToList().ForEach(y => y.Kill());

            _cts.Dispose();

            base.Dispose(disposing);
        }
    }
}
