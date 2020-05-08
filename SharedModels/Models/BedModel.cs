using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalHealthMonitoringShared
{
    public class BedModel : NotifyChangedBaseClass
    {
        int _Id;
        [JsonProperty("bed_id")]
        public int Id
        {
            get => _Id;
            set => SetField(ref _Id, value);
        }

        public bool IsNew => Id == 0 ? true : false;

        CardioDeviceModel _CardioDevice = new CardioDeviceModel();
        [JsonProperty("CMD")]
        public CardioDeviceModel CardioDevice
        {
            get => _CardioDevice;
            set => SetField(ref _CardioDevice, value);
        }

        VentilatorDeviceModel _VentilatorDevice = new VentilatorDeviceModel();
        [JsonProperty("VentilatorDevice")]
        public VentilatorDeviceModel VentilatorDevice
        {
            get => _VentilatorDevice;
            set => SetField(ref _VentilatorDevice, value);
        }
    }
}
