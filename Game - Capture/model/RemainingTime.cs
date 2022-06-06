using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Media;

namespace Game___Capture.model
{
    class RemainingTime
    {
        private readonly Timer _timer;
        private TimeSpan _remainingTime;
        public event Action TimerStoped;

        public RemainingTime(int seconds)
        {
            _timer = new Timer(interval: 50);
            _timer.Elapsed += new ElapsedEventHandler(TimerElapsed);

            _remainingTime = TimeSpan.FromSeconds(seconds);
        }

        public void Start()
        {
            _timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_remainingTime != TimeSpan.Zero)
            {
                _remainingTime -= TimeSpan.FromMilliseconds(50);
            }
            else
            {
                _timer.Stop();
                TimerStoped();
            }
        }

        public override string ToString()
        {
            return $"{_remainingTime.Minutes} : {_remainingTime.Seconds} : {_remainingTime.Milliseconds}";
        }
    }
}
