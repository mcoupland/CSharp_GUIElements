using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GUIElements
{
    public class GUIButtonStateInfo
    {
        public Brush frame_border_color = new SolidColorBrush(Colors.Black);
        public Thickness frame_border_thickness = new Thickness(1);
        public Brush frame_background_color = new SolidColorBrush(Colors.Black);
        public double frame_background_opacity = 0.4;
        public Thickness frame_size = new Thickness(0);

        public Brush panel_border_color = new SolidColorBrush(Colors.Transparent);
        public Thickness panel_border_thickness = new Thickness(1);
        public Brush panel_background_color = new SolidColorBrush(Colors.White);

        public string button_picture_source = string.Format(@"{0}{1}", System.AppDomain.CurrentDomain.BaseDirectory, "default-capture.jpg");
        public Size button_picture_size = new Size(200, 200);

        public string caption_content = "GUIEButton Hover";
        public Brush caption_color = new SolidColorBrush(Colors.White);

        public GUIButtonStateInfo() { }

    }
}
