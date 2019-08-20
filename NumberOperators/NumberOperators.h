#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace TestDTO;

namespace NumberOperators {  
  public ref class NumbersAdder : System::EnterpriseServices::ServicedComponent
  {
  public:
    int add(int a, int b) {
      return a + b;
    }
    int add(IntPair^ pair) {
      return pair->a + pair->b;
    }
    IntPair^ buildPair(int a, int b) {
      IntPair^ pair = gcnew IntPair();
      pair->a = a;
      pair->b = b;
      return pair;
    }
  };

  public ref class NumbersSubstracter
  {
  public:
    int sub(int a, int b) {
      return a - b;
    }
  };
}
