using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game___Capture.model
{
    class TimerExpanded
    {
        private Timer timer;
        private TimeSpan time;

        public TimerExpanded(int seconds)
        {
            timer = new Timer(interval: 50);
            timer.Elapsed += new ElapsedEventHandler(TimerElapsed);

            time = TimeSpan.FromSeconds(seconds);
        }

        public void Start()
        {
            timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (time != TimeSpan.Zero)
            {
                time -= TimeSpan.FromSeconds(1);
            }
            else
            {
                timer.Stop();
            }
        }

        public override string ToString()
        {
            return $"{time.Minutes} : {time.Seconds} : {time.Milliseconds:0.00}";
        }
    }
}
