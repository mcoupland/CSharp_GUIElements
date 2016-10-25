using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
namespace GUIElements
{
    /// <summary>
    /// This is a button
    /// </summary>
    public partial class GUIButton : UserControl
    {
        #region Custom Events
        public delegate void LeftClickHandler(object sender, MouseButtonEventArgs e);
        public delegate void RightClickHandler(object sender, MouseButtonEventArgs e);

        public event LeftClickHandler OnLeftClick;
        public event RightClickHandler OnRightClick;

        private DateTime _left_down = DateTime.MinValue;
        private DateTime _left_up = DateTime.MaxValue;
        private DateTime _right_down = DateTime.MinValue;
        private DateTime _right_up = DateTime.MaxValue;
        private TimeSpan _click_threshold = TimeSpan.FromMilliseconds(300);

        private void LeftMouseDown(object sender, MouseButtonEventArgs e) { _left_down = DateTime.Now; }
        private void LeftMouseUp(object sender, MouseButtonEventArgs e) { _left_up = DateTime.Now; ClickOrNot(e); }
        private void RightMouseDown(object sender, MouseButtonEventArgs e) { _right_down = DateTime.Now; }        
        private void RightMouseUp(object sender, MouseButtonEventArgs e) { _right_up = DateTime.Now; ClickOrNot(e); }
        private void ClickOrNot(MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                if(_left_up.Subtract(_left_down) < _click_threshold)
                {
                    OnLeftClick?.Invoke(this, e);
                }
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                if (_right_up.Subtract(_right_down) < _click_threshold)
                {
                    OnRightClick?.Invoke(this, e);
                }
            }
            _left_up = DateTime.MaxValue;
            _left_down = DateTime.MinValue;
            _right_up = DateTime.MaxValue;
            _right_down = DateTime.MinValue;
        }

        public GUIButton _revert_button;
        #endregion
        
        #region Public Member Elements        
        private object _attachment;
        public object Attachment
        {
            get
            {
                return _attachment;
            }

            set
            {
                _attachment = value;
            }
        }
        private GUIEnumerations.ButtonState _current_state = GUIEnumerations.ButtonState.ToggleUp;
        public GUIEnumerations.ButtonState CurrentState
        {
            get
            {
                return _current_state;
            }
            set
            {
                _current_state = value;
            }
        }
        private string _caption_content = "GUIEButton";
        public string CaptionContent
        {
            get { return _caption_content; }
        }
        #endregion

        #region Private Members
        private GUIEnumerations.ButtonDock _dock = GUIEnumerations.ButtonDock.Bottom;
        private Label _caption = new Label();
        private Image _picture = new Image();
        private Brush _gui_panel_background = Brushes.White;
        private GUIEnumerations.ButtonType _button_type = GUIEnumerations.ButtonType.Momentary;
        private string _picture_source = string.Empty;                
        private bool _trim_caption = false;
        private Size _picture_size = new Size(200, 200);
        private bool _fix_whitespace = false;
        #endregion

        #region Constructors
        public GUIButton()
        {
            InitializeComponent();
            BuildButton();            
        }

        public GUIButton(
            GUIEnumerations.ButtonType button_type,
            GUIEnumerations.ButtonDock dock, 
            string caption_text, 
            string image_source, 
            bool? trimcaption)
        {
            InitializeComponent();
            _button_type = button_type;
            _caption_content = caption_text;
            _picture_source = image_source;
            _trim_caption = trimcaption.HasValue ? trimcaption.Value : _trim_caption;
            _dock = dock;
            BuildButton();
        }
        #endregion

        #region Public Methods To Modify Button
        public void UpdateButton(Color? backgroundcolor, GUIEnumerations.ButtonDock? dock, bool? fixwhitespace)
        {
            _gui_panel_background = backgroundcolor.HasValue ? new SolidColorBrush(backgroundcolor.Value) : guiPanel.Background;
            _dock = dock.HasValue ? dock.Value : _dock;
            _fix_whitespace = fixwhitespace.HasValue ? fixwhitespace.Value : _fix_whitespace;            
            BuildButton();
        }
        public void UpdateCaption(Color? backgroundcolor, Color? captioncolor, string caption, bool showtooltip = false)
        {
            _caption.Background = backgroundcolor.HasValue ? new SolidColorBrush(backgroundcolor.Value) : _caption.Background;
            _caption.Foreground = captioncolor.HasValue ? new SolidColorBrush(captioncolor.Value) : _caption.Foreground;
            _caption.Content = !string.IsNullOrEmpty(caption) ? caption : _caption.Content;
            if (!string.IsNullOrEmpty(_caption_content)) { this.ToolTip = _caption_content; }
        }
        public void UpdateFrame(Thickness framesize, Brush backgroundcolor, double backgroundopacity, Brush bordercolor, Thickness bordersize)
        {
            guiBorder.Margin = framesize;
            guiFrame.Background = backgroundcolor;
            guiFrame.Opacity = backgroundopacity;
            guiFrame.BorderBrush = bordercolor;
            guiFrame.BorderThickness = bordersize;
        }
        public void UpdatePanelBorder(Brush bordercolor, Thickness bordersize)
        {
            guiBorder.BorderBrush = bordercolor;
            guiBorder.BorderThickness = bordersize;
        }
        public void UpdatePicture(string picturesource, int width, int height)
        {
            _picture_size = new Size(width, height);
            _picture_source = !string.IsNullOrEmpty(picturesource) ? picturesource : _picture_source;
            _picture.Source = BitmapSourceFromString(_picture_source);
            _picture.Width = _picture_size.Width;
            _picture.Height = _picture_size.Height;
            _picture.Margin = new Thickness(0);
            LayoutElements();
        }
        #endregion

        public GUIEnumerations.ButtonState ToggleLeftClick()
        {
            if(_current_state == GUIEnumerations.ButtonState.ToggleUp)
            {
                _current_state = GUIEnumerations.ButtonState.ToggleDown;
            }
            else
            {
                _current_state = GUIEnumerations.ButtonState.ToggleUp;
            }
            return _current_state;
        }
        
        #region Event Binding & Handling
        private void BindEvents()
        {
            this.MouseLeftButtonDown += LeftMouseDown;
            this.MouseLeftButtonUp += LeftMouseUp;
            this.MouseRightButtonDown += RightMouseDown;
            this.MouseRightButtonUp += RightMouseUp;
            this.MouseEnter += MouseInvaded;
            this.MouseLeave += MouseRetreated;
        }

        private void MouseRetreated(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void MouseInvaded(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }        
        #endregion

        #region Build the Button
        private void BuildButton()
        {
            BindEvents();
            AddImage();
            AddCaption();
            AddElements();
            LayoutElements();
        }
        
        private void AddElements()
        {
            guiPanel.Children.Clear();
            guiPanel.Children.Add(_caption);
            guiPanel.Children.Add(_picture);
        }

        private void AddImage()
        {
            if (!string.IsNullOrEmpty(_picture_source))
            {
                _picture.Source = BitmapSourceFromString(_picture_source);
                _picture.Width = _picture_size.Width;
                _picture.Height = _picture_size.Height;
            }
            _picture.Margin = new Thickness(0);
            _picture.Stretch = Stretch.UniformToFill;
            _picture.HorizontalAlignment = HorizontalAlignment.Stretch;
            _picture.VerticalAlignment = VerticalAlignment.Stretch;
        }

        private void AddCaption()
        {
            if (string.IsNullOrEmpty(_caption_content)) { _caption.Width = 0; _caption.Height = 0; }
            guiPanel.Background = _gui_panel_background;
            _caption.Content = _caption_content;            
            _caption.Foreground = Brushes.Black;
            _caption.VerticalAlignment = VerticalAlignment.Stretch;
            _caption.VerticalContentAlignment = VerticalAlignment.Center;
            _caption.HorizontalAlignment = HorizontalAlignment.Stretch;
            _caption.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        private void DockImage()
        {
            switch (_dock)
            {
                case GUIEnumerations.ButtonDock.Bottom:
                    DockPanel.SetDock(_picture, Dock.Bottom);
                    DockPanel.SetDock(_caption, Dock.Top);
                    break;
                case GUIEnumerations.ButtonDock.Top:
                    DockPanel.SetDock(_picture, Dock.Top);
                    DockPanel.SetDock(_caption, Dock.Bottom);
                    break;
                case GUIEnumerations.ButtonDock.Left:
                    DockPanel.SetDock(_picture, Dock.Left);
                    DockPanel.SetDock(_caption, Dock.Right);
                    break;
                case GUIEnumerations.ButtonDock.Right:
                    DockPanel.SetDock(_picture, Dock.Right);
                    DockPanel.SetDock(_caption, Dock.Left);
                    break;
            }
        }

        private void LayoutElements()
        {
            switch (_dock)
            {
                case GUIEnumerations.ButtonDock.Bottom:
                    SetPortrait(_caption, _picture);
                    break;
                case GUIEnumerations.ButtonDock.Top:
                    SetPortrait(_picture, _caption);
                    break;
                case GUIEnumerations.ButtonDock.Left:
                    SetLandscape(_picture, _caption);
                    break;
                case GUIEnumerations.ButtonDock.Right:
                    SetLandscape(_caption, _picture);
                    break;
            }
        }

        private void SetLandscape(UIElement left, UIElement right)
        {
            DockPanel.SetDock(left, Dock.Left);
            DockPanel.SetDock(right, Dock.Right);
        }

        private void SetPortrait(UIElement top, UIElement bottom)
        {
            DockPanel.SetDock(bottom, Dock.Bottom);
            DockPanel.SetDock(top, Dock.Top);
            TrimCaption();
            FixWhiteSpace();
        }

        private void TrimCaption()
        {
            if (!_trim_caption) { return; }
            int picture_width = GetElementSize(_picture).Width;
            _caption.Width = picture_width; return; 
        }

        private void FixWhiteSpace()
        {
            if (!_fix_whitespace) { return; }   
            if (_picture.Source == null) { return; }
            int caption_width = GetElementSize(_caption).Width;
            int picture_width = GetElementSize(_picture).Width;  
            double compensate = 0;
            if (caption_width > picture_width)
            {
                compensate = (caption_width - picture_width) / 2;
            }                
            Thickness compensated = _picture.Margin;
            if (_dock == GUIEnumerations.ButtonDock.Bottom)
            { compensated.Bottom = _picture.Margin.Bottom + compensate; }
            else
            { compensated.Top = _picture.Margin.Top + compensate; }
            _picture.Margin = compensated;
        }
        #endregion

        #region Static Helper Methods
        private static System.Drawing.Size GetElementSize(UIElement element)
        {
            element.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
            int width = Convert.ToInt16(Math.Ceiling(element.DesiredSize.Width));
            int height = Convert.ToInt16(Math.Ceiling(element.DesiredSize.Height));
            return new System.Drawing.Size(width, height);
        }

        private static ImageSource BitmapSourceFromString(string source)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(source);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bitmap.EndInit();
            return bitmap;
        }
        #endregion
    }
}
