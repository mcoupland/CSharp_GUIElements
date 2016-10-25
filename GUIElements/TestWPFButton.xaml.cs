using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FlexControls
{
    /// <summary>
    /// Interaction logic for TestWPFButton.xaml
    /// </summary>
    public partial class TestWPFButton : Window
    {
        public TestWPFButton()
        {
            #region init
            InitializeComponent();
            string caption_text = string.Empty;
            string image_source = string.Empty;
            Brush border_brush = Brushes.Transparent;
            Thickness border_thickness = new Thickness(0);
            System.Drawing.Size image_size = new System.Drawing.Size(200, 200);

            WPFButton.TransparencyStruct TransparencyInfo = new WPFButton.TransparencyStruct();
            TransparencyInfo.Color = Brushes.White;
            TransparencyInfo.Opacity = 0.4;
            TransparencyInfo.Size = new Thickness(20);
            TransparencyInfo.BorderBrush = Brushes.Black;
            TransparencyInfo.BorderThickness = new Thickness(1);
            #endregion

            WPFButton wpf_button = BuildButton(
                "Default",
                null,
                null,
                string.Empty,
                string.Empty,
                null,
                null,
                null);
        }
        //    #region buttons
        //    caption_text = "Button0";
        //    wpf_button = new WPFButton(caption_text);
        //    Surface.Children.Add(wpf_button);

        //    caption_text = "Button1";
        //    wpf_button = new WPFButton(caption_text);
        //    Surface.Children.Add(wpf_button);
            
        //    caption_text = "";
        //    image_source = @"C:\Users\Michael\Documents\2015 Projects\JAMPLean\JAMPLean\Resources\default-capture.jpg";
        //    wpf_button = new WPFButton(caption_text, image_source);
        //    wpf_button.SetPictureSize(image_size.Width, image_size.Height);
        //    Surface.Children.Add(wpf_button);

        //    caption_text = "Button3";
        //    image_source = @"C:\Users\Michael\Documents\2015 Projects\JAMPLean\JAMPLean\Resources\default-capture.jpg";
        //    wpf_button = new WPFButton(caption_text, image_source);
        //    wpf_button.SetPictureSize(image_size.Width, image_size.Height);
        //    Surface.Children.Add(wpf_button);

        //    caption_text = "Button4";
        //    image_source = @"C:\Users\Michael\Documents\2015 Projects\JAMPLean\JAMPLean\Resources\default-capture.jpg";
        //    wpf_button = new WPFButton(caption_text, image_source);
        //    wpf_button.SetPictureSize(image_size.Width, image_size.Height);
        //    Surface.Children.Add(wpf_button);

        //    caption_text = "Button4";
        //    image_source = @"C:\Users\Michael\Documents\2015 Projects\JAMPLean\JAMPLean\Resources\default-capture.jpg";
        //    wpf_button = new WPFButton(caption_text, image_source);
        //    wpf_button.SetPictureSize(image_size.Width, image_size.Height);            
        //    wpf_button.SetTransparency(TransparencyInfo);
        //    Surface.Children.Add(wpf_button);

        //    caption_text = "Button";
        //    image_source = @"C:\Users\Michael\Documents\2015 Projects\JAMPLean\JAMPLean\Resources\default-capture.jpg";
        //    wpf_button = new WPFButton(WPFButton.SceneViewerImageDock.Left, caption_text, image_source);
        //    wpf_button.SetPictureSize(image_size.Width, image_size.Height);
        //    TransparencyInfo.BorderBrush = Brushes.Transparent;
        //    TransparencyInfo.BorderThickness = new Thickness(0);
        //    wpf_button.SetTransparency(TransparencyInfo);
        //    wpf_button.BorderBrush = Brushes.Black;
        //    wpf_button.BorderThickness = new Thickness(1);
        //    Surface.Children.Add(wpf_button);

        //    caption_text = "Text & Image & Transparent Margin & Border";
        //    image_source = @"C:\Users\Michael\Documents\2015 Projects\JAMPLean\JAMPLean\Resources\default-capture.jpg";
        //    wpf_button = new WPFButton(WPFButton.SceneViewerImageDock.Right, caption_text, image_source);
        //    wpf_button.SetPictureSize(image_size.Width, image_size.Height);
        //    TransparencyInfo.BorderBrush = Brushes.Transparent;
        //    TransparencyInfo.BorderThickness = new Thickness(0);
        //    wpf_button.SetTransparency(TransparencyInfo);
        //    wpf_button.BorderBrush = Brushes.Black;
        //    wpf_button.BorderThickness = new Thickness(1);
        //    Surface.Children.Add(wpf_button);

        //    caption_text = "Text & Image & Transparent Margin & Border";
        //    image_source = @"C:\Users\Michael\Documents\2015 Projects\JAMPLean\JAMPLean\Resources\default-capture.jpg";
        //    wpf_button = new WPFButton(WPFButton.SceneViewerImageDock.Top, caption_text, image_source);
        //    wpf_button.SetPictureSize(image_size.Width, image_size.Height);
        //    TransparencyInfo.BorderBrush = Brushes.Transparent;
        //    TransparencyInfo.BorderThickness = new Thickness(0);
        //    wpf_button.SetTransparency(TransparencyInfo);
        //    wpf_button.BorderBrush = Brushes.Black;
        //    wpf_button.BorderThickness = new Thickness(1);
        //    Surface.Children.Add(wpf_button);

        //    caption_text = "Text & Image & Transparent Margin & Border";
        //    image_source = @"C:\Users\Michael\Documents\2015 Projects\JAMPLean\JAMPLean\Resources\default-capture.jpg";
        //    wpf_button = new WPFButton(WPFButton.SceneViewerImageDock.Bottom, caption_text, image_source);
        //    wpf_button.SetPictureSize(150,150);
        //    TransparencyInfo.BorderBrush = Brushes.Transparent;
        //    TransparencyInfo.BorderThickness = new Thickness(0);
        //    wpf_button.SetTransparency(TransparencyInfo);
        //    wpf_button.BorderBrush = Brushes.Black;
        //    wpf_button.BorderThickness = new Thickness(1);
        //    wpf_button.OnLeftClick += Wpf_button_OnLeftClick;
        //    wpf_button.OnRightClick += Wpf_button_OnRightClick;
        //    Surface.Children.Add(wpf_button);
        //    #endregion
        //}

        private WPFButton BuildButton(
            string instancetitle,
            WPFButton.ButtonType? buttontype,
            WPFButton.SceneViewerImageDock? dock,
            string caption, 
            string imagesource, 
            int? width, 
            int? height, 
            WPFButton.TransparencyStruct? transparency)
        {
            WPFButton.ButtonType button_type = buttontype.HasValue ? buttontype.Value : WPFButton.ButtonType.Momentary;
            WPFButton.SceneViewerImageDock dock_type = dock.HasValue ? dock.Value : WPFButton.SceneViewerImageDock.Bottom;
            caption = string.IsNullOrEmpty(caption) ? string.Empty : caption;
            imagesource = string.IsNullOrEmpty(imagesource) ? string.Empty : imagesource;
            
            WPFButton wpf_button = new WPFButton(
                button_type,
                dock_type,
                caption,
                imagesource
            );

            if(width.HasValue & height.HasValue)
            {
                wpf_button.SetPictureSize(width.Value, height.Value);
            }
            if (transparency.HasValue)
            {
                wpf_button.SetTransparency(transparency.Value);
            }

            Label title = new Label();
            title.Content = instancetitle;
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Vertical;
            stack.Children.Add(title);
            stack.Children.Add(wpf_button);
            Surface.Children.Add(stack);
            return wpf_button;
        }

        private void Wpf_button_OnLeftClick(object sender, MouseButtonEventArgs e)
        {
            WPFButton button = sender as WPFButton;
            button.SetPictureSize(200, 200);
        }

        private void Wpf_button_OnRightClick(object sender, MouseButtonEventArgs e)
        {
            WPFButton button = sender as WPFButton;
            button.SetPictureSize(300, 300);
        }
    }
}
