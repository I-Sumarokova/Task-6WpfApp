using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Занятие6WpfApp
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string wind;
        private int speed;

        public enum Weather { Sanny, Cloudy, Rain, Snow};

        public string Wind
        {
            get => wind;
            set => wind = value;
        }
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value > 0)
                {
                    speed = value;
                }
                else
                {
                    speed = 0;
                }
            }
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public WeatherControl(string wind, int speed, int temperature)
        {
            this.Wind = wind;
            this.Speed = speed;
            this.Temperature = temperature;
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int)value;
            if (v >= -50 && v <= 50)
                return true;
            else
                return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v >= -50 && v <= 50)
                return v;
            else
                return 0;
        }

    public string Print()
        {
            return $"(Wind) (Speed) (Temperature)";
        }
    }
}
