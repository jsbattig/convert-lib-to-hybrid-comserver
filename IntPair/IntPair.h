#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;

namespace TestDTO {
  [ClassInterface(ClassInterfaceType::None)]
	public ref class IntPair : System::EnterpriseServices::ServicedComponent {
  public:
    int a;
    int b;

    IntPair() {}
   
    void Clear() {
      a = 0;
      b = 0;
    }
	};
}
