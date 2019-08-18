using System;
using NumberOperators;

namespace TesterApp
{
  class Program
  {
    static void Main(string[] args)
    {
      NumbersAdder adder = new NumbersAdder();
      Console.WriteLine("10 + 12 = " + adder.add(10, 12));      
      NumbersSubstracter substracter = new NumbersSubstracter();
      Console.WriteLine("10 = 12 = " + substracter.sub(10, 12));
      Console.WriteLine("Press any key to finish");
      Console.ReadLine();
    }
  }
}
