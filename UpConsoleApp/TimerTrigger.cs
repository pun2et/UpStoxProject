using System;
using System.Timers;

namespace UpConsoleApp
{
    public class TimerTrigger : EventArgs
    {
        private static Timer aTimer;

        public void TimerSetter()
        {

            Logger.LogThis("TimerSetter started");

            TimeSpan day = new TimeSpan(24, 00, 00);    // 24 hours in a day.
            TimeSpan now = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));     // The current time in 24 hour format
            TimeSpan activationTime = new TimeSpan(15, 21, 0);    // 4 AM
            TimeSpan activationTime2 = new TimeSpan(9, 12, 0);    // 4 AM
         
            TimeSpan timeLeftUntilFirstRun;





            var ActTime = now.Subtract(activationTime).Negate().TotalSeconds;
            Console.WriteLine((day - now).ToString() +"\n");
            Console.WriteLine("activateion time - " + double.Parse((now.Subtract(activationTime).Negate().TotalSeconds).ToString()) + "\n");
            //Console.WriteLine("activateion time2 - " + (now - activationTime2 + "\n").ToString());
            

            if (double.Parse((now.Subtract(activationTime).TotalSeconds).ToString()) > 0)
            {
                timeLeftUntilFirstRun = ((day - now) + activationTime);
                Console.WriteLine(timeLeftUntilFirstRun + "\n");
            }
            else
            {
                var nagator = now.Subtract(activationTime).Negate();
                Console.WriteLine("time left to trigger - ");
                Console.WriteLine(nagator);
                timeLeftUntilFirstRun = nagator;
                Console.WriteLine(timeLeftUntilFirstRun + "\n");
            }
            




            // Create a timer and set a two second interval.
            aTimer = new Timer();
            aTimer.Interval = double.Parse(timeLeftUntilFirstRun.TotalMilliseconds.ToString());
            
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;

            Console.WriteLine("time started... ");
           
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            Console.WriteLine("Triggering Main trigger");

            Triggers triggers = new Triggers();
            var banknifty = new BankNiftyAutoTrade();

            triggers.FirstTimerCalled += banknifty.OnFirstTimerCalled;
            triggers.EngageBankNifty();
        }
    }
}
