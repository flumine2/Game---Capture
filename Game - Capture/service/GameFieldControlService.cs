using Game___Capture.model;
using Game___Capture.Updatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game___Capture.service
{
    class GameFieldControlService : IUpdatable
    {
        private readonly Game _game;
        private double _deltaY;

        public GameFieldControlService(Game game)
        {
            _game = game;
        }

        public void Update(double deltaTime)
        {
            _deltaY += Config.FallingSpeed(deltaTime);
            if (_deltaY >= Config.CELL_SIZE.Height + 10)
            {
                _deltaY -= Config.CELL_SIZE.Height + 10;
                _game.GameField.OffsetField();
            }
        }
    }
}
