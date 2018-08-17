using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace UpConsoleApp
{
    public class Triggers : EventArgs
    {

        public int asnwer;

        public delegate void FirstTimerEventHandler(object source, EventArgs eventArgs);
        public event FirstTimerEventHandler FirstTimerCalled;

        public void EngageBankNifty()
        {
            Console.WriteLine("Bank nifty trggered");
            OnFirstTimerCalled();
        }
        protected virtual void OnFirstTimerCalled()
        {
            Logger.LogThis("logger at in OnFirstTimerCalled Method started");
            Console.WriteLine("in OnFirstTimerCalled Method");
            if (FirstTimerCalled != null)
            {
                FirstTimerCalled(this, EventArgs.Empty);
            }
        }
    }
}
