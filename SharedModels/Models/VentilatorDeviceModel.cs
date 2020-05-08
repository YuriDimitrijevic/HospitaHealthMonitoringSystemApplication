using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalHealthMonitoringShared
{
    public class VentilatorDeviceModel : NotifyChangedBaseClass
    {
        int _PortNumber;
        [JsonProperty("vent_port")]
        public int PortNumber
        {
            get => _PortNumber;
            set => SetField(ref _PortNumber, value);
        }

        double _OxygenPercent;
        [JsonProperty("oxygen_%")]
        public double OxygenPercent
        {
            get => _OxygenPercent;
            set => SetField(ref _OxygenPercent, value);
        }

        double _AirPressure;
        [JsonProperty("PA")]
        public double AirPressure
        {
            get => _AirPressure;
            set => SetField(ref _AirPressure, value);
        }

        int _BreathingRate;
        [JsonProperty("breathing_rate")]
        public int BreathingRate
        {
            get => _BreathingRate;
            set => SetField(ref _BreathingRate, value);
        }

        double _BreathDuration;
        [JsonProperty("breath_duration")]
        public double BreathDuration
        {
            get => _BreathDuration;
            set => SetField(ref _BreathDuration, value);
        }

        double _BloodOxygenLevel;
        [JsonProperty("blood_oxygen_level")]
        public double BloodOxygenLevel
        {
            get => _BloodOxygenLevel;
            set => SetField(ref _BloodOxygenLevel, value);
        }
    }
}
