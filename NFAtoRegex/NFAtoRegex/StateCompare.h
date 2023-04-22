#pragma once
#include "NFA.h"

class StateCompare
{
private:
	NFA m_nfa;

public:
	StateCompare(NFA nfa);
	bool operator()(char state1, char state2) const;
};