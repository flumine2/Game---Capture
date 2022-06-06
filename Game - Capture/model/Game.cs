using Game___Capture.model.Cells;
using Game___Capture.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Game___Capture.model
{
    class Game
    {
        private int _score;
        private readonly GameField _gameField;
        public readonly RemainingTime Timer;

        public int Score
        {
            get => _score;
        }

        public GameField GameField
        {
            get => _gameField;
        }

        public Game()
        {
            _gameField = new GameField();
            Timer = new RemainingTime(Config.GAME_TIME);
        }

        public void AddScore(int value)
        {
            if (value > 0)
            {
                _score += value;
            }
        }
    }
}
