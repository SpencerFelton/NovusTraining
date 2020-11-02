using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance {
    class Program {
        static void Main(string[] args) {
            Account myAccount = new Account();
            double currentAccount = 0.0;

            currentAccount = myAccount.setAccountBalance(1000.00);
            Console.WriteLine($"Current amount is {currentAccount}");

            //withdraw
            currentAccount = myAccount.withdrawFromAccount(200.00);
            Console.WriteLine($"Current amount is {currentAccount}");

            currentAccount = myAccount.getAccountBalance();
            Console.WriteLine($"Current amount is {currentAccount}");
            Console.ReadLine();
        }
    }
}
