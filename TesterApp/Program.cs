using System;
using NumberOperators;

namespace TesterApp
{
  class Program
  {
    static void Main(string[] args)
    {
      NumbersAdder adder = new NumbersAdder(); // This object now created within the context of COM Surrogate (32 bit) process
      Console.WriteLine("10 + 12 = " + adder.add(10, 12)); // This call marshaled to COM Surrogate process hosting a copy of NumberOperators.dll
      NumbersSubstracter substracter = new NumbersSubstracter(); // This object created within current AppDomain as a normal .NET assembly
      Console.WriteLine("10 = 12 = " + substracter.sub(10, 12)); // Normal call to .NET object
      Console.WriteLine("Press any key to finish");
      Console.ReadLine();
    }
  }
}
