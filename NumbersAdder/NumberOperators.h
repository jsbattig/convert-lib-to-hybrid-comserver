#pragma once

using namespace System;

namespace NumberOperators {
	public ref class NumbersAdder
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
