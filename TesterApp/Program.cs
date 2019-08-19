using System;
using NumberOperators;
using TestDTO;

namespace TesterApp
{
  class Program
  {
    static void Main(string[] args)
    {
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
      Console.WriteLine("Press any key to finish");
      Console.ReadLine();
    }
  }
}
