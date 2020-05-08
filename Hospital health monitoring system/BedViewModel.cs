using HospitalHealthMonitoringShared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalHealthMonitoringSystem
{
    public class BedViewModel : NotifyChangedBaseClass
    {
        public BedViewModel(BedModel value)
        {
            Id = value.Id;
            IsNew = value.IsNew;
            Value = value;

            WriteData(value);
        }

        BedModel _Value;
        [Browsable(false)]
        public BedModel Value
        {
            get => _Value;
            private set => SetField(ref _Value, value);
        }

        bool _IsNew;
        [Browsable(false)]
        public bool IsNew
        {
            get => _IsNew;
            private set => SetField(ref _IsNew, value);
        }

        int _Id;
        [DisplayName("Id")]
        public int Id
        {
            get => _Id;
            private set => SetField(ref _Id, value);
        }

        double _OxygenPercent;
        [DisplayName("Oxygen concentration (%)")]
        public double OxygenPercent
        {
            get => _OxygenPercent;
            set => SetField(ref _OxygenPercent, value);
        }

        double _AirPressure;
        [DisplayName("Air pressure")]
        public double AirPressure
        {
            get => _AirPressure;
            set => SetField(ref _AirPressure, value);
        }

        int _BreathingRate;
        [DisplayName("Breaths per minute")]
        public int BreathingRate
        {
            get => _BreathingRate;
            set => SetField(ref _BreathingRate, value);
        }

        double _BreathDuration;
        [DisplayName("Breathing duration (miliseconds)")]
        public double BreathDuration
        {
            get => _BreathDuration;
            set => SetField(ref _BreathDuration, value);
        }

        double _BloodOxygenLevel;
        [DisplayName("Blood oxygen level (SpO2 %)")]
        public double BloodOxygenLevel
        {
            get => _BloodOxygenLevel;
            set => SetField(ref _BloodOxygenLevel, value);
        }

        int _HeartRate;
        [DisplayName("Heart rate")]
        public int HeartRate
        {
            get => _HeartRate;
            set => SetField(ref _HeartRate, value);
        }

        int _SystolicBloodPressure;
        [DisplayName("Systolic blood pressure")]
        public int SystolicBloodPressure
        {
            get => _SystolicBloodPressure;
            set => SetField(ref _SystolicBloodPressure, value);
        }

        int _DiastolicBloodPressure;
        [DisplayName("Diastolic blood pressure")]
        public int DiastolicBloodPressure
        {
            get => _DiastolicBloodPressure;
            set => SetField(ref _DiastolicBloodPressure, value);
        }

        public void WriteData(BedModel value)
        {
            OxygenPercent = value.VentilatorDevice.OxygenPercent;
            AirPressure = value.VentilatorDevice.AirPressure;
            BreathDuration = value.VentilatorDevice.BreathDuration;
            BreathingRate = value.VentilatorDevice.BreathingRate;
            BloodOxygenLevel = value.VentilatorDevice.BloodOxygenLevel;
            HeartRate = value.CardioDevice.HeartRate;
            SystolicBloodPressure = value.CardioDevice.BloodPressure.Systolic;
            DiastolicBloodPressure = value.CardioDevice.BloodPressure.Diastolic;
        }

        public bool UpdateData()
        {           
            Value.VentilatorDevice.OxygenPercent = OxygenPercent;
            Value.VentilatorDevice.AirPressure = AirPressure;
            Value.VentilatorDevice.BreathingRate = BreathingRate;
            Value.VentilatorDevice.BreathDuration = BreathDuration;

            return true;
        }
    }
}
