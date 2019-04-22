using NetworkStatus.Node.Status.Device.Temperature;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkStatus.Node.Status.Device.Temperature
{
    interface IHardwareTemperatureService
    {
        HardwareTemperature GetHardwareTemperature();
    }
}
