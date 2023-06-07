using ModernWpf.Controls;
using System;

namespace VRisingServerManager.Controls
{
    class NumberBoxFormatter : INumberBoxNumberFormatter
    {
        public string FormatDouble(double value)
        {
            return value.ToString("F");
        }

        public double? ParseDouble(string text)
        {
            if (double.TryParse(text, out double result))
            {
                return Math.Round(result * 4, MidpointRounding.AwayFromZero) / 4;
            }
            return null;
        }

    }
}
