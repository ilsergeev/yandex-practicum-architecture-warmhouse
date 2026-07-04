namespace SmartHouse.Models
{
    public class TemperatureData
    {
        public double Value { get; set; }
        public string Unit { get; set; } = "°C";
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Location { get; set; } = null!;
        public string Status { get; set; } = "active";
        public string SensorId { get; set; } = null!;
        public string SensorType { get; set; } = "temperature";
        public string Description { get; set; } = null!;
    }
}
