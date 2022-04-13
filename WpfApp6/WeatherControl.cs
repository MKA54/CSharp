using System.Windows;

namespace WpfApp6
{
    internal class WeatherControl:DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(string),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    "",
                    FrameworkPropertyMetadataOptions.AffectsMeasure|
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            var t = (int) value;

            return t < -50 || t > 50;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            var t = (int) baseValue;

            if (t < -50)
            {
                return -50;
            }

            return 50;
        }

        public WeatherControl(int temperature, string directionWind, int windSpeed, PresencePrecipitation presencePrecipitation)
        {
            Temperature = temperature;
            DirectionWind = directionWind;
            WindSpeed = windSpeed;
            PresencePrecipitation = presencePrecipitation;
        }

        public int Temperature
        {
            get => (int) GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        public string DirectionWind
        {
            get => DirectionWind;

            set => DirectionWind = value;
        }

        public int WindSpeed
        {
            get => WindSpeed;
            set => WindSpeed = value;
        }

        public PresencePrecipitation PresencePrecipitation
        {
            get => PresencePrecipitation;
            set => PresencePrecipitation = value;
        }
    }
}
