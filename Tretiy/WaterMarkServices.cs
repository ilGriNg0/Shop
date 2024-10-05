using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tretiy
{
   public static class WaterMarkServices
    {
        public static readonly DependencyProperty WaterMarkProperty = DependencyProperty.RegisterAttached(
                "WaterMark",
                typeof(string),
                typeof(WaterMarkServices),
                new PropertyMetadata(string.Empty));

        public static void SetWaterMark(UIElement element, string watermark) => element.SetValue(WaterMarkProperty, watermark);
       
        public static string GetWaterMark(UIElement element) => (string)element.GetValue(WaterMarkProperty);
    }
}
