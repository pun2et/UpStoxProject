using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpstoxNet;
using UpConsoleApp;
using System.Timers;
using UpConsoleApp.ScheduledTriggers;

namespace UpConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Timer aTimer;
            //aTimer = new System.Timers.Timer();
            //aTimer.Interval = 6000;

            //// Hook up the Elapsed event for the timer. 
            //aTimer.Elapsed += OnTimedEvent;

            //// Have the timer fire repeated events (true is the default)
            //aTimer.AutoReset = true;

            //// Start the timer
            //aTimer.Enabled = true;

            //Console.WriteLine("Press the Enter key to exit the program at any time... ");
            //Console.ReadLine();

            Logger.CreateLogFile();
            
            Logger.LogThis("Logger started");
            Console.WriteLine("Hello World!");



            new UpStoxAuthenticator();
            var gg = new DumbTheoryTrigger();
            gg.TimerSetter();

            Console.ReadKey();

            //void OnTimedEvent(Object source, ElapsedEventArgs e)
            //{
            //    Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            //}
        }
    }
}
