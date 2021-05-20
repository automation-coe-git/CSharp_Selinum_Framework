using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.src
{
    class VerifyAssertion
    {

        public void checkAssertionTrue()
        {
            try
            {
                Assert.IsTrue(true);
                Console.WriteLine("Assertion passed");
               
            }
            catch (AssertionException)
            {
                
                Console.WriteLine("Assertion failed");
                throw;
                
            }

        }

        public void checkAssertionFalse()
        {
            try
            {
                Assert.IsTrue(false);
                Console.WriteLine("Assertion passed");
               
            }
            catch (AssertionException)
            {
                
                Console.WriteLine("Assertion failed");
                throw;
            }
        }

    }
}
