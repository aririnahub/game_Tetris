using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace TetrisGame
{
    public partial class MainWindow : Window
    {
        private TetrisGame tetrisGame;
        private DispatcherTimer gameTimer;

        public MainWindow()
        {
            InitializeComponent();

            tetrisGame = new TetrisGame(GameGrid);
            gameTimer = new DispatcherTimer();
            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(500);
            gameTimer.Start();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            tetrisGame.MoveDown();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                tetrisGame.MoveLeft();
            }
            else if (e.Key == Key.Right)
            {
                tetrisGame.MoveRight();
            }
            else if (e.Key == Key.Down)
            {
                tetrisGame.MoveDown();
            }
            else if (e.Key == Key.Space)
            {
                tetrisGame.Rotate();
            }
        }
    }
}