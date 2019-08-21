#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace TestDTO;

namespace NumberOperators {
  /* Declaring and implementing an interface on the COM class increases performance per call 3x even if
   * using the COM object directly via a proxy object in the calling process
   */
  public interface class INumbersAdder
  {
    int add(int a, int b);
    int add(IntPair^ pair);
    IntPair^ buildPair(int a, int b);
  };

  public ref class NumbersAdder : System::EnterpriseServices::ServicedComponent, INumbersAdder
  {
  public:
    virtual int add(int a, int b);
    virtual int add(IntPair^ pair);
    virtual IntPair^ buildPair(int a, int b);
  };

  public ref class NumbersSubstracter
  {
  public:
    int sub(int a, int b) {
      return a - b;
    }
  };
}
