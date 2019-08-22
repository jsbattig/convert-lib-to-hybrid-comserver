using System;
using System.Threading;
using System.Threading.Tasks;
using NumberOperators;
using TestDTO;
using Ascentis.ExternalCache;

namespace TesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const int loops = 100000;
            const int threadCount = 4;
            NumbersAdder adder = new NumbersAdder(); // This object now created within the context of COM Surrogate (32 bit) process
            Console.WriteLine("10 + 12 = " + adder.add(10, 12)); // This call marshaled to COM Surrogate process hosting a copy of NumberOperators.dll
            NumbersSubstracter substracter = new NumbersSubstracter(); // This object created within current AppDomain as a normal .NET assembly
            Console.WriteLine("10 - 12 = " + substracter.sub(10, 12)); // Normal call to .NET object
            IntPair pair = new IntPair() { a = 10, b = 12 };
            Console.WriteLine("pair.a = 10, pair.b = 12. adder.add(pair) = " + adder.add(pair));
            pair = adder.buildPair(5, 10);
            Console.WriteLine("Built pair in COM Server. pair.a = " + pair.a + ". pair.b = " + pair.b);
            pair.Clear();
            Console.WriteLine("Called pair.Clear()");
            Console.WriteLine("Built pair in COM Server. pair.a = " + pair.a + ". pair.b = " + pair.b);

            var initialTicks = Environment.TickCount;
            for (var i = 0; i < loops; i++)
                adder.add(10, 2);
            Console.WriteLine("Requests per second (Single threaded): " + (loops / ((float)(Environment.TickCount - initialTicks) / 1000)));

            initialTicks = Environment.TickCount;
            Thread[] threads = new Thread[threadCount];
            for (var i = 0; i < threadCount; i++)
            {
                (threads[i] = new Thread((innerAdder =>
                {
                    for (var j = 0; j < loops; j++)
                        ((NumbersAdder)innerAdder).add(10, 2);
                }))).Start(new NumbersAdder());
            }
            foreach (var thread in threads)
                thread.Join();
            Console.WriteLine($"Aggregate requests per second ({threadCount} threads): " + (int)(threadCount * loops / ((float)(Environment.TickCount - initialTicks) / 1000)));
            Console.WriteLine($"Per thread requests per second ({threadCount} threads): " + (int)(loops / ((float)(Environment.TickCount - initialTicks) / 1000)));

            initialTicks = Environment.TickCount;
            INumbersAdder adderi = (INumbersAdder)adder;
            for (var i = 0; i < loops; i++)
                adderi.add(10, 2);
            Console.WriteLine("Requests per second (Single threaded using interface): " + (loops / ((float)(Environment.TickCount - initialTicks) / 1000)));

            ExternalCache externalCache = new ExternalCache();
            externalCache.Add("test", 1);
            ExternalCacheItem item = new ExternalCacheItem();
            item["Test"] = "hello";
            externalCache.Add("test 2", item);
            var retrieved = (ExternalCacheItem)externalCache.Get("test 2");
            Console.WriteLine(retrieved.Container.Test);

            Console.WriteLine("Press any key to finish");
            Console.ReadLine();
        }
    }
}
