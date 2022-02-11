using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


namespace WpfЗадание_6.Свойства_зависимостей
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    class WeatherMeas : DependencyObject
    {
        public string Direction;
        public int Speedwind;

        public WeatherMeas(int temper, string direction, int speedwind)
        {
            this.Temper = temper;
            this.Direction = direction;
            this.Speedwind = speedwind;

        }
        

        public static readonly DependencyProperty TemperProperty =
            DependencyProperty.Register(
                nameof(Temper),
                typeof(int),
                typeof(WeatherMeas),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemper)),
                    new ValidateValueCallback(ValidateTemper)
                );

        private static bool ValidateTemper(object value)
        {
            int val = (int)value;
            if (val >= -50 && val <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemper(DependencyObject b, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }

        public int Temper
        {
            get => (int)GetValue(TemperProperty);
            set => SetValue(TemperProperty, value);
        }

        public enum Precipitation
        {
            солнечно = 0,
            облачно = 2,
            дождь = 2,
            снег = 3
        }




    }

    //private  void MainWindow_Load(object sender, EventArgs e)
    //{
    //    string url = "http://dataservice.accuweather.com/locations/v1/cities/search?apikey=Max&q=Tomsk&language=en&details=true";
    //    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
    //    HttpWebResponse HttpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    //    string response;
    //    using (StreamReader streamreader = new StreamReader(HttpWebResponse.GetResponseStream()))
    //    {
    //        response = streamreader.ReadToEnd();
    //    }

    //    WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
    //    Console.WriteLine("Temperature in {0}: {1} C", weatherResponse.Name, weatherResponse.Main.Temp);

    //    Console.ReadKey();

    //}
}
