using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace UpConsoleApp.ScheduledTriggers
{
   public class DumbTheoryTrigger
    {
        private static Timer aTimer;
        private static Timer bTimer;

        public void TimerSetter()
        {

            Logger.LogThis("TimerSetter started");

            TimeSpan day = new TimeSpan(24, 00, 00);    // 24 hours in a day.
            TimeSpan now = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));     // The current time in 24 hour format
            TimeSpan activationTime = new TimeSpan(09, 13, 15);    // 9.14 AM
          
            TimeSpan timeLeftUntilFirstRun;                      


            if (double.Parse((now.Subtract(activationTime).TotalSeconds).ToString()) > 0)
            {
                timeLeftUntilFirstRun = ((day - now) + activationTime);
                Logger.LogThis("Scheduler will trigger at -" + timeLeftUntilFirstRun + "\n");
            }
            else
            {
                var nagator = now.Subtract(activationTime).Negate();
                Logger.LogThis("time left to trigger - ");
                Console.WriteLine(nagator);
                timeLeftUntilFirstRun = nagator;
                Logger.LogThis(timeLeftUntilFirstRun + "\n");
            }
            

            // Create a timer and set a two second interval.
            aTimer = new Timer();
            aTimer.Interval = double.Parse(timeLeftUntilFirstRun.TotalMilliseconds.ToString());

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnNineOneFourElapsedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = false;

            // Start the timer
            aTimer.Enabled = true;

            Console.WriteLine("time started... ");

        }

        private void OnNineOneFourElapsedEvent(object sender, ElapsedEventArgs e)
        {
            Logger.LogThis("The Elapsed event was raised at - "+ e.SignalTime);
            Logger.LogThis("Triggering Main trigger");
            Console.WriteLine("The Elapsed event was raised at - " + e.SignalTime);
            Triggers triggers = new Triggers();
            var banknifty = new BankNiftyAutoTrade();
           

            triggers.FirstTimerCalled += banknifty.OnFirstTimerCalled;
            triggers.EngageBankNifty();
            aTimer.Enabled = false;
            SecondTrigger();
            
            
        }

        private void OnNineOneFiveElapsedEvent(object sender, ElapsedEventArgs e)
        {
            
            Logger.LogThis("2 The Elapsed event was raised at - " + e.SignalTime);
            Logger.LogThis("2 Triggering Main trigger");
            Console.WriteLine("2 The Elapsed event was raised at - " + e.SignalTime);
            Triggers triggers = new Triggers();
            var banknifty = new BankNiftyAutoTrade();


            triggers.FirstTimerCalled += banknifty.OnFirstTimerCalled;
            triggers.EngageBankNifty();
            bTimer.Enabled = false;
            TimerSetter();
        }

        public void SecondTrigger()
        {
            bTimer = new Timer();
            bTimer.Interval = double.Parse(TimeSpan.FromMinutes(3).TotalMilliseconds.ToString());
            Console.WriteLine("2 time started... " + bTimer.Interval);
            // Hook up the Elapsed event for the timer. 
            bTimer.Elapsed += OnNineOneFiveElapsedEvent;

            // Have the timer fire repeated events (true is the default)
            bTimer.AutoReset = false;

            // Start the timer
            bTimer.Enabled = true;
        }
    }
}
