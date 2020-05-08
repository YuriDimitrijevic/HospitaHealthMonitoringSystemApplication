using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalHealthMonitoringShared
{
    public class SafeValues : NotifyChangedBaseClass
    {      
        int _MaxBreathingRate;
        [JsonProperty("max_breathing_rate")]
        public int MaxBreathingRate
        {
            get => _MaxBreathingRate;
            set => SetField(ref _MaxBreathingRate, value);
        }

        int _MinBreathingRate;
        [JsonProperty("min_breathing_rate")]
        public int MinBreathingRate
        {
            get => _MinBreathingRate;
            set => SetField(ref _MinBreathingRate, value);
        }

        int _MaxBreathDuration;
        [JsonProperty("max_breath_duration")]
        public int MaxBreathDuration
        {
            get => _MaxBreathDuration;
            set => SetField(ref _MaxBreathDuration, value);
        }

        int _MinBreathDuration;
        [JsonProperty("min_breath_duration")]
        public int MinBreathDuration
        {
            get => _MinBreathDuration;
            set => SetField(ref _MinBreathDuration, value);
        }        

        int _MaxHeartRate;
        [JsonProperty("max_heart_rate")]
        public int MaxHeartRate
        {
            get => _MaxHeartRate;
            set => SetField(ref _MaxHeartRate, value);
        }

        int _MinHeartRate;
        [JsonProperty("min_heart_rate")]
        public int MinHeartRate
        {
            get => _MinHeartRate;
            set => SetField(ref _MinHeartRate, value);
        }

        int _MaxSystolicBloodPressure;
        [JsonProperty("max_systolic")]
        public int MaxSystolicBloodPressure
        {
            get => _MaxSystolicBloodPressure;
            set => SetField(ref _MaxSystolicBloodPressure, value);
        }

        int _MinSystolicBloodPressure;
        [JsonProperty("min_systolic")]
        public int MinSystolicBloodPressure
        {
            get => _MinSystolicBloodPressure;
            set => SetField(ref _MinSystolicBloodPressure, value);
        }

        int _MaxDiastolicBloodPressure;
        [JsonProperty("max_diastolic")]
        public int MaxDiastolicBloodPressure
        {
            get => _MaxDiastolicBloodPressure;
            set => SetField(ref _MaxDiastolicBloodPressure, value);
        }

        int _MinDiastolicBloodPressure;
        [JsonProperty("min_diastolic")]
        public int MinDiastolicBloodPressure
        {
            get => _MinDiastolicBloodPressure;
            set => SetField(ref _MinDiastolicBloodPressure, value);
        }
    }
}
