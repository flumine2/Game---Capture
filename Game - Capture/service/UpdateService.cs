using Game___Capture.model;
using Game___Capture.model.UserControl;
using Game___Capture.Updatable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game___Capture.service
{
    class UpdateService
    {
        private readonly IUpdatable[] _services;
        private readonly Game _game;

        public UpdateService(Game game, params IUpdatable[] services)
        {
            _game = game;
            _services = services;
        }

        public void UpdateAll(double deltaTime)
        {
            _game.GameField.Update(deltaTime);
            foreach (IUpdatable item in _services)
            {
                item.Update(deltaTime);
            }
        }
    }
}
