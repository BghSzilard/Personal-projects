#include "StateCompare.h"

StateCompare::StateCompare(NFA nfa) : m_nfa(nfa) {}

bool StateCompare::operator()(char state1, char state2) const {
	return m_nfa.getIncomingStates(state1).size() + m_nfa.getOutgoingStates(state1).size() >
		m_nfa.getIncomingStates(state2).size() + m_nfa.getOutgoingStates(state2).size();
}