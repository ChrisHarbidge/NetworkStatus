namespace NetworkStatus.Node.Status.Device.Temperature
{
    public class HardwareTemperature
    {
        public int TemperatureMilliDegreesCelcius { get; set; }

        public double TemperatureDegreesCelcius() => TemperatureMilliDegreesCelcius / 1000.0;
    }
}
