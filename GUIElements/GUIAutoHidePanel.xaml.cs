using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GUIElements
{
    public enum PanelState { Hidden, Visible, Peeking };

    /// <summary>
    /// Interaction logic for GUIAutoHidePanel.xaml
    /// </summary>
    public partial class GUIAutoHidePanel : UserControl
    {
        public Canvas ButtonCanvas;
        private WrapPanel ButtonWrapper;
        private Rectangle ButtonRectangle;
        public PanelState CurrentState = PanelState.Visible;
        public UIElementCollection Children
        {
            get { return ButtonWrapper.Children; }
        }
        public Size _min_size;
        private Point _location;
        private Orientation _orientation = Orientation.Horizontal;
        private Brush _background;
        new public Brush Background
        {
            get { return _background; }
            set 
            { 
                _background = value;
                ButtonRectangle.Fill = _background;
            }
        }

        public GUIAutoHidePanel()
        {
            InitializeComponent();
        }

        public GUIAutoHidePanel(Grid parent, Point location, Size min_size, Orientation orientation = Orientation.Horizontal)
        {
            InitializeComponent();
            _location = location;
            _min_size = min_size;
            _orientation = orientation;
            CanvasFactory();
            parent.Children.Add(ButtonCanvas);
            Grid.SetRow(ButtonCanvas, 0);
            Grid.SetColumn(ButtonCanvas, 0);
        }

        public void TogglePanelState()
        {
            CurrentState = CurrentState == PanelState.Peeking ? PanelState.Visible : PanelState.Peeking;
            UpdateLayout();
        }

        private void CanvasFactory()
        {
            ButtonCanvas = new Canvas();
            ButtonCanvas.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            ButtonCanvas.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            ButtonCanvas.SetValue(Canvas.ZIndexProperty, 1);
            RectFactory();
            WrapperFactory();
            ButtonCanvas.Children.Add(ButtonRectangle);
            ButtonCanvas.Children.Add(ButtonWrapper);
            BuildCanvas(_location, _min_size);
        }

        private void RectFactory()
        {
            ButtonRectangle = new Rectangle();
            ButtonRectangle.Fill = new SolidColorBrush(Colors.Black);
            ButtonRectangle.Opacity = 0.4;
        }

        private void WrapperFactory()
        {
            ButtonWrapper = new WrapPanel();
            ButtonWrapper.SetValue(Canvas.ZIndexProperty, 3);
            ButtonWrapper.Background = new SolidColorBrush(Colors.Transparent);
            ButtonWrapper.Orientation = _orientation;
            ButtonWrapper.SizeChanged += ButtonWrapper_SizeChanged;
        }

        private void ButtonWrapper_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateLayout();
        }

        private new void UpdateLayout()
        {
            if (CurrentState == PanelState.Peeking)
            {
                foreach(UIElement child in ButtonWrapper.Children)
                {
                    child.Visibility = System.Windows.Visibility.Collapsed;
                }
                ButtonWrapper.Children[0].Visibility = System.Windows.Visibility.Visible;
                BuildCanvas(_location, _min_size);
                return;
            }
            foreach (UIElement child in ButtonWrapper.Children)
            {
                child.Visibility = System.Windows.Visibility.Visible;
            }
            Size max_size = new Size(Application.Current.MainWindow.RenderSize.Width, ButtonWrapper.RenderSize.Height);
            Point location = new Point(0, _location.Y);
            if(_orientation == Orientation.Vertical)
            {
                double left = Application.Current.MainWindow.RenderSize.Width - ButtonWrapper.RenderSize.Width;
                left -= _min_size.Width;
                left -= 20;
                location = new Point(left, _location.Y);
            }
            BuildCanvas(location, max_size);
        }

        private void SetOpacity(double opacity)
        {
            ButtonRectangle.Opacity = opacity;
        }
        
        private void BuildCanvas(Point location, Size size)
        {
            ButtonRectangle.SetValue(Canvas.TopProperty, location.Y);
            ButtonRectangle.SetValue(Canvas.LeftProperty, location.X);
            ButtonRectangle.SetValue(Canvas.WidthProperty, size.Width);
            ButtonRectangle.SetValue(Canvas.HeightProperty, size.Height);

            ButtonWrapper.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            ButtonWrapper.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            ButtonWrapper.SetValue(Canvas.LeftProperty, ButtonRectangle.GetValue(Canvas.LeftProperty));
            ButtonWrapper.SetValue(Canvas.TopProperty, ButtonRectangle.GetValue(Canvas.TopProperty));
        }
    }
}
