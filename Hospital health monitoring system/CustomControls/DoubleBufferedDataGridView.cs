using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalHealthMonitoringSystem
{
    public partial class DoubleBufferedDataGridView : DataGridView
    {
        public DoubleBufferedDataGridView()
        {            
            DoubleBuffered = true;
        }
    }
}
