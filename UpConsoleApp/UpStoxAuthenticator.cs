using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpstoxNet;

namespace UpConsoleApp
{
    public sealed class UpStoxAuthenticator
    {
        private static Upstox upstox = null;
        public static Upstox GetUpStox
        {
            get
            {
                if (upstox == null)
                {
                    // Create upstox instance
                    Console.WriteLine("UpStox instance creted ");
                    upstox = new Upstox();            
                }
                return upstox;
            }
        }

        public UpStoxAuthenticator()
        {
            //
            Console.WriteLine("Authenticating with APP key and URL");

        }

    }
}
