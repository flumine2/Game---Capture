using Game___Capture.model;
using Game___Capture.Resources;
using Game___Capture.SaveResults;
using Game___Capture.service;
using Game___Capture.util;
using Game___Capture.views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Game___Capture
{
    public delegate Point MousePositionDelegate();
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _gameIsRunning;
        private RenderService _renderService;
        private UpdateService _updateService;
        private PlayerActionService _actionService;
        private GameFieldControlService _fieldService;
        private ScoreService _scoreService;
        private Game _game;
        private readonly StartExitTopListWindow _startExitTopListWindow;

        public MainWindow()
        {
            InitializeComponent();
            _startExitTopListWindow = new StartExitTopListWindow(this);
            ShowMainMenuWindow();
        }

        private void ShowMainMenuWindow()
        {
            Visibility = Visibility.Hidden;
            _startExitTopListWindow.Visibility = Visibility.Visible;
        }

        private void Showing()
        {
            Thread.Sleep(1500);
            Dispatcher.Invoke(ShowMainMenuWindow);
        }

        public async void StartNew()
        {
            InitGame();

            Stopwatch stopwatch = new();
            stopwatch.Start();

            long lastTime = stopwatch.ElapsedMilliseconds;
            while (_gameIsRunning)
            {
                long current = stopwatch.ElapsedMilliseconds;
                double elapsed = current - lastTime;

                _actionService.ProcessInput(); // 1
                _updateService.Update(elapsed); // 2
                _renderService.RenderFrame(); // 3

                await Task.Delay(TimeSpan.FromMilliseconds(current + Config.MS_PER_FRAME - stopwatch.ElapsedMilliseconds));
                // For Debag:
                //await Task.Delay(40);
                lastTime = current;
            }
        }

        private void InitGame()
        {
            _game = new Game();
            _game.Timer.TimerStoped += StopGame;
            _game.Timer.TimerStoped += Showing;

            _scoreService = new ScoreService(_game);

            _actionService = new PlayerActionService(() => Mouse.GetPosition(Game_Field), _scoreService, _game.GameField);

            _renderService = new RenderService(
                image: Game_Field,
                game: _game,
                actionService: _actionService,
                scoreString: Score_String,
                timeString: Time_Line);

            _fieldService = new GameFieldControlService(_game);

            _updateService = new UpdateService(_game, _actionService, _fieldService);

            _gameIsRunning = true;
            _game.Timer.Start();
        }

        private void StopGame()
        {
            _gameIsRunning = false;
            Saves.Dictionary[Environment.UserName]["Score"] = _game.Score;
        }

        #region Closing

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Saves.Serialize();
            Application.Current.Shutdown();
        }

        #endregion

        #region Mouse Capture region

        private void Game_Field_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _actionService.IsMouseDown = true;
            Mouse.GetPosition(Game_Field);
        }

        private void Game_Field_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _actionService.IsMouseDown = false;
        }

        private void Game_Field_MouseLeave(object sender, MouseEventArgs e)
        {
            _actionService.IsMouseDown = false;
        }

        #endregion
    }
}
