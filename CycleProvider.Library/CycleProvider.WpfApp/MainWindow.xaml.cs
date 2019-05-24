using CycleProvider.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CycleProvider.WpfApp
{
    public partial class MainWindow : Window
    {
        private CycleProvider<Point> _cycleProvider = new CycleProvider<Point>();
        private BackgroundWorker _bw = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();

            SetupCycleProvider();
            SetupElpFloat();
            SetupBackgroundWorker();
            BtnStart.Click += (s, a) => { if (!_bw.IsBusy) _bw.RunWorkerAsync(); BtnStart.IsHitTestVisible = false; };
        }

        private void SetupElpFloat()
        {
            ElpFloat.DataContext = _cycleProvider;
            ElpFloat.MouseEnter += (s, a) =>
            {
                _cycleProvider.Next();
                Title = _cycleProvider.CurrentItem.ToString();
            };
        }

        private void SetupCycleProvider()
        {
            _cycleProvider.Add(new Point { X = 1, Y = 1 });
            _cycleProvider.Add(new Point { X = 0, Y = 1 });
            _cycleProvider.Add(new Point { X = 0, Y = 0 });
            _cycleProvider.Add(new Point { X = 1, Y = 0 });
            _cycleProvider.Add(new Point { X = 0, Y = 0 });
            _cycleProvider.Add(new Point { X = 0, Y = 1 });
            _cycleProvider.Next();
        }

        private void SetupBackgroundWorker()
        {
            _bw.DoWork += (s, a) =>
              {
                  while (true)
                  {
                      _cycleProvider.Next();
                      1000.Sleep();
                  }
              };
        }

        private struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public override string ToString()
            {
                return $"{X} x {Y}";
            }
        }
    }
}
