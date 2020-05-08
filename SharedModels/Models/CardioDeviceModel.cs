using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalHealthMonitoringShared
{
    public class CardioDeviceModel : NotifyChangedBaseClass
    {
        int _PortNumber;
        [JsonProperty("cmd_port")]
        public int PortNumber
        {
            get => _PortNumber;
            set => SetField(ref _PortNumber, value);
        }

        int _HeartRate;
        [JsonProperty("heart_rate")]
        public int HeartRate
        {
            get => _HeartRate;
            set => SetField(ref _HeartRate, value);
        }

        BloodPressureModel _BloodPressure = new BloodPressureModel();
        [JsonProperty("blood_pressure")]
        public BloodPressureModel BloodPressure
        {
            get => _BloodPressure;
            set => SetField(ref _BloodPressure, value);
        }
    }

    public class BloodPressureModel : NotifyChangedBaseClass
    {
        int _Systolic;
        [JsonProperty("systolic")]
        public int Systolic
        {
            get => _Systolic;
            set => SetField(ref _Systolic, value);
        }

        int _Diastolice;
        [JsonProperty("diastolic")]
        public int Diastolic
        {
            get => _Diastolice;
            set => SetField(ref _Diastolice, value);
        }
    }
}
