using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetworkStatus.Node.Status.Device.Temperature
{
    public class HardwareTemperatureService : IHardwareTemperatureService
    {
        private const string HARDWARE_TEMP_FOLDER_PATH = "/sys/class/thermal/";

        private const string HARDWARE_TEMP_FILE_PATH_REGEX = "thermal_zone[0-9]";
        private const string HARDWARE_TEMP_FILE_NAME = "temp";

        public HardwareTemperature GetHardwareTemperature()
        {
            var folderNameRegex = new Regex(HARDWARE_TEMP_FILE_PATH_REGEX);

            var folder = Directory.GetDirectories(HARDWARE_TEMP_FOLDER_PATH).First(path => folderNameRegex.IsMatch(path));

            var filePath = Path.Combine(folder, HARDWARE_TEMP_FILE_NAME);

            var fileContents = File.ReadAllText(filePath);

            if (int.TryParse(fileContents, out int temperature))
            {
                return new HardwareTemperature
                {
                    TemperatureMilliDegreesCelcius = temperature
                };
            }
            else
            {
                throw new InvalidDataException($"Invalid hardware temperature in file {filePath}");
            }
        }
    }
}
