using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_example;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    // 最小化窗口
    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    // 最大化/还原窗口
    private void MaximizeButton_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
    }

    // 关闭窗口
    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
    
    // 实现窗口拖动
    private void TitleBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        
        if (e.LeftButton != System.Windows.Input.MouseButtonState.Pressed)
            return;
        
        // 如果窗口是最大化状态，调整为正常状态并设置位置
        if (this.WindowState == WindowState.Maximized)
        {
            // 获取当前鼠标位置相对于屏幕的坐标
            var mousePosition = Mouse.GetPosition(this);

            // 鼠标离左上角x距离
            double leftArea = mousePosition.X;
            double leftPrediction = leftArea / this.ActualWidth;
            
            MaximizeButton_Click(sender, e);

            // 将窗口的位置设置为鼠标位置
            this.Left = mousePosition.X - this.ActualWidth * leftPrediction;
            this.Top = mousePosition.Y;
        }

        // 启用拖动
        this.DragMove();
    }
    
    // 动态调整clip大小
    private void DynamicBorder_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (sender is Border border)
        {
            // 动态调整 Clip 区域
            border.Clip = new RectangleGeometry
            {
                Rect = new Rect(0, 0, border.ActualWidth, border.ActualHeight),
                RadiusX = border.CornerRadius.TopLeft,
                RadiusY = border.CornerRadius.TopLeft
            };
        }
    }
}