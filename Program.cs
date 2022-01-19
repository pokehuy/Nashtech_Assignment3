using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignment3
{
    public class Clock{
        public delegate void ClockApp();
        public event ClockApp OnChange = delegate { };
        public void ClockDisplay(){
            OnChange();
        }
    }
    class Program{
        public delegate void ClockApp();
        static void Main(String[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var primes = GetPrimeNumbers(2,10000).Result;
            // foreach(var prime in primes){
            //     Console.WriteLine(prime);
            // }
            sw.Stop();
            Console.WriteLine("Total prime numbers: {0}\nProcess time: {1}", primes.Count, sw.Elapsed.TotalSeconds);
            while(true){
                Thread.Sleep(1000);
                Clock clock = new Clock();
                clock.OnChange += () => Console.WriteLine(DateTime.Now);
                clock.ClockDisplay();
            }
        }

        private static async Task<List<int>> GetPrimeNumbers(int minimum, int maximum)
        {
            var result = new List<int>();
            return await Task.Run(() => {
            
            for(int i = minimum; i <= maximum; i++){
                if(IsPrimeNumber(i))
                {
                    result.Add(i);
                }
            }
            return result;
            });
        }

        static bool IsPrimeNumber(int number)
        {
            if (number % 2 == 0)
            {
                return number == 2;
            }
            else
            {
                var topLimit = (int)Math.Sqrt(number);
                for(int i = 3; i <= topLimit; i += 2)
                {
                    if (number % i == 0) return false;
                }
                return true;
            }
        }
    }
}
