#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;

namespace NumberOperators {
  [ClassInterface(ClassInterfaceType::None)]
  public ref class NumbersAdder : System::EnterpriseServices::ServicedComponent
	{
  public:
    int add(int a, int b) {
      return a + b;
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
