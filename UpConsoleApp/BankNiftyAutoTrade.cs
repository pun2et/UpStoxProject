using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpConsoleApp
{
    public class BankNiftyAutoTrade
    {
        public void OnFirstTimerCalled(object source, EventArgs e)
        {
            Console.WriteLine("Bank nifty Buy Triggered");
            Console.WriteLine("Bank nifty  Sell triggered");
        }
    }
}
