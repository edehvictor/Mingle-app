namespace API.Demo
{
    public class WeatherForecast
    {
        public int TemperatureC { get; set; }

        // public int TemperatureF
        // {
        //  get {
        //     return  (TemperatureC * 9/5) + 32;

        //  }
        // }

         //OR
        // public int TemperatureF
        // {
        //  get => (TemperatureC * 9/5) + 32;

        // }

    public int TemperatureF => (TemperatureC * 9/5) + 32; //lander expreession
    public DateTime Date { get; set; }
    public string? TempDescription { get; set; }
    }
}