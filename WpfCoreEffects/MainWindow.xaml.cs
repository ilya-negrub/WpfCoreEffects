using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCoreEffects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private bool ValidMagnifyEffect<T>(object sender, Action<Grid, T> action)
        {
            if (sender is Grid grid && grid.Effect is T magnify)
            {
                action(grid, magnify);
                return true;
            }

            return false;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            ValidMagnifyEffect<MagnifyEffect>(sender, (grid, magnify) =>
            {
                Point p = e.GetPosition(grid);
                magnify.CenterPoint = new Point(p.X / grid.ActualWidth, p.Y / grid.ActualHeight);
            });

            ValidMagnifyEffect<MagnifySmoothEffect>(sender, (grid, magnify) =>
            {
                Point p = e.GetPosition(grid);
                magnify.CenterPoint = new Point(p.X / grid.ActualWidth, p.Y / grid.ActualHeight);
            });
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            ValidMagnifyEffect<MagnifyEffect>(sender, (grid, magnify) =>
            {   
                magnify.MagnificationAmount += e.Delta / 1000d;
            });

            ValidMagnifyEffect<MagnifySmoothEffect>(sender, (grid, magnify) =>
            {
                magnify.MagnificationAmount += e.Delta / 1000d;
            });
        }


        

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ValidMagnifyEffect<MagnifyEffect>(sender, (grid, magnify) =>
            {
                magnify.Radius += 0.01;
            });

            ValidMagnifyEffect<MagnifySmoothEffect>(sender, (grid, magnify) =>
            {
                magnify.InnerRadius += 0.01;
                magnify.OuterRadius = magnify.InnerRadius + 0.01;

                if (magnify.InnerRadius == 0) 
                    magnify.OuterRadius = 0;
            });
        }

        private void Grid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ValidMagnifyEffect<MagnifyEffect>(sender, (grid, magnify) =>
            {
                magnify.Radius -= 0.01;
            });

            ValidMagnifyEffect<MagnifySmoothEffect>(sender, (grid, magnify) =>
            {
                magnify.InnerRadius -= 0.01;
                magnify.OuterRadius = magnify.InnerRadius + 0.01;

                if (magnify.InnerRadius == 0)
                    magnify.OuterRadius = 0;
            });
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ValidMagnifyEffect<MagnifyEffect>(sender, (grid, magnify) =>
            {                
                magnify.AspectRatio = grid.ActualWidth / grid.ActualHeight;
            });

            ValidMagnifyEffect<MagnifySmoothEffect>(sender, (grid, magnify) =>
            {                
                magnify.AspectRatio = grid.ActualWidth / grid.ActualHeight;
            });
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mainGrid.Effect = new MagnifyEffect()
            {
                CenterPoint = new Point(0.5, 0.5),
                Radius = 0.1,
                MagnificationAmount = 1.6,
                AspectRatio = mainGrid.ActualWidth / mainGrid.ActualHeight,
            };
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            mainGrid.Effect = new MagnifySmoothEffect()
            {
                CenterPoint = new Point(0.5, 0.5),
                InnerRadius = 0.1,
                OuterRadius = 0.11,
                MagnificationAmount = 1.6,
                AspectRatio = mainGrid.ActualWidth / mainGrid.ActualHeight,
            };
        }
    }
}
