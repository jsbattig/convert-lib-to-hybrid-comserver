#include "stdafx.h"

#include "NumberOperators.h"

int NumberOperators::NumbersAdder::add(int a, int b) {
  return a + b;
}

int NumberOperators::NumbersAdder::add(IntPair^ pair) {
  return pair->a + pair->b;
}

IntPair^ NumberOperators::NumbersAdder::buildPair(int a, int b) {
  IntPair^ pair = gcnew IntPair();
  pair->a = a;
  pair->b = b;
  return pair;
}