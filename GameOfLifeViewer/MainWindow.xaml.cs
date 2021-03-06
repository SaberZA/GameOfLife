﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GameOfLife;
using Timer = System.Timers.Timer;

namespace GameOfLifeViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;
        private Timer _timer;
        private List<Rectangle> _rectangles;
        private bool _reDraw;
        private Canvas _canvas;
        
        public MainWindow()
        {
            InitializeComponent();
            _timer = new Timer(100);
            _timer.Elapsed += (s,e) => Progress();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            _game = new Game(10);
            _game.Toggle(0, 0);
            _game.Toggle(1, 0);
            _game.Toggle(2, 0);
            _game.Toggle(2, 1);
            _game.Toggle(2, 2);
            _game.Toggle(1, 2);
            _game.Toggle(0, 2);

            _canvas = new Canvas();
            var btnProc = new Button();
            btnProc.Click += btnProc_Click;
            btnProc.Content = "Proc";

            var btnStop = new Button();
            btnStop.Click += BtnStopOnClick;

            _canvas.Children.Add(btnProc);
            Canvas.SetLeft(btnProc, 165);
            Canvas.SetTop(btnProc, 380);
            
            this.Content = _canvas;
            Draw();
            CanToggleBlock = true;
        }

        private void BtnStopOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (_timer == null) return;
            _timer.Stop();
        }

        private void Draw()
        {
            for (int col = 0; col < _game.Size; col++)
            {
                for (int row = 0; row < _game.Size; row++)
                {
                    MyRectangle rect;
                    rect = new MyRectangle();
                    rect.X = col;
                    rect.Y = row;
                    rect.Rectangle.Fill = _game.ValueOfPoint(col, row) == 1
                        ? new SolidColorBrush(Colors.Black)
                        : new SolidColorBrush(Colors.White);
                    rect.Rectangle.Width = Width/_game.Size;
                    rect.Rectangle.Height = Height/_game.Size;
                    rect.Rectangle.Stroke = new SolidColorBrush(Colors.Green);
                    Canvas.SetLeft(rect.Rectangle, col * 30);
                    Canvas.SetTop(rect.Rectangle, row * 30);
                    rect.Rectangle.MouseDown += (s,e) => RectOnMouseDown(s,e,rect);
                    Dispatcher.Invoke(() => _canvas.Children.Add(rect.Rectangle));
                }
            }
        }

        private void RectOnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs, MyRectangle rectangle)
        {
            if (CanToggleBlock)
            {
                _game.Toggle(rectangle.X, rectangle.Y);
                Draw();
            }
        }

        public bool CanToggleBlock { get; set; }

        private void btnProc_Click(object sender, RoutedEventArgs e)
        {
            CanToggleBlock = false;
            _timer.Start();
        }

        private void Progress()
        {
            _timer.Stop();
            for (int colIndex = 0; colIndex < _game.Board.Length; colIndex++)
            {
                int[] col = _game.Board[colIndex];
                Dispatcher.Invoke(Draw);
                for (int rowIndex = 0; rowIndex < col.Length; rowIndex++)
                {
                    Dispatcher.Invoke(Draw);
                    if (_game.PointHasFewerThanTwoNeighbours(colIndex, rowIndex))
                    {
                        _game.SetPointOff(colIndex, rowIndex);
                    }
                    else if (_game.PointHasTwoOrThreeNighbours(colIndex, rowIndex))
                    {
                        _game.SetPointOn(colIndex, rowIndex);
                    }
                    else if (_game.PointHasMoreThanThreeNeighbours(colIndex, rowIndex))
                    {
                        _game.SetPointOff(colIndex, rowIndex);
                    }
                    else if (_game.PointHasThreeNeighboursAndIsDead(colIndex, rowIndex))
                    {
                        _game.SetPointOn(colIndex, rowIndex);
                    }
                    
                }
            }

            _timer.Start();
        }
    }

    
}
