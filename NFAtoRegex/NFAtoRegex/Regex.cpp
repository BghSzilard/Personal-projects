#include "Regex.h"
#include "StateCompare.h"

#include <string>
#include <queue>
#include <regex>

Regex::Regex(const NFA& nfa)
{
	m_nfa = nfa;
	addNewStartState();
	addNewFinalState();
	m_nfa.mergeTransitions();
	createPattern();
	simplifyPattern();
}

void Regex::addNewStartState()
{
	char oldStartState = m_nfa.getStartState();
	m_nfa.addState(NFARegexConstants::START_STATE);
	m_nfa.addTransition(NFARegexConstants::START_STATE, NFARegexConstants::lambda, oldStartState);
	m_nfa.setStartState(NFARegexConstants::START_STATE);
}

void Regex::addNewFinalState()
{
	std::set<char> oldFinalStates = m_nfa.getFinalStates();
	for (char oldFinalState : oldFinalStates)
	{
		m_nfa.addTransition(oldFinalState, NFARegexConstants::lambda, NFARegexConstants::FINAL_STATE);
	}
	m_nfa.addState(NFARegexConstants::FINAL_STATE);
	m_nfa.removeFinalStates();
	m_nfa.addFinalState(NFARegexConstants::FINAL_STATE);
}

void Regex::createPattern()
{
	std::map<char, std::vector<NFA::Transition>> transitions = m_nfa.getTransitions();
	std::priority_queue<char, std::vector<char>, StateCompare> states(m_nfa);
	for (char state : m_nfa.getStates())
	{
		if (NFARegexConstants::FINAL_STATE != state && NFARegexConstants::START_STATE != state)
		{
			states.push(state);
		}
	}
	while (states.size())
	{
		char state = states.top();
		states.pop();
		std::vector<std::pair<char, char>> inputOutputPairs = m_nfa.getInputOutputPairs(state);
		for (auto& const inputOutputPair : inputOutputPairs)
		{
			std::string newSymbol = "";
			NFA::Transition firstTransition = *(m_nfa.getAllTransitionsBetween(inputOutputPair.first, state)).begin();
			NFA::Transition secondTransition = *(m_nfa.getAllTransitionsBetween(state, inputOutputPair.second)).begin();

			// add the symbol(s) of the first transition
			if (firstTransition.symbol != NFARegexConstants::lambda)
			{
				newSymbol += firstTransition.symbol;
			}

			//deal with self loops
			if (m_nfa.getAllTransitionsBetween(state, state).size())
			{
				NFA::Transition selfTransition = *(m_nfa.getAllTransitionsBetween(state, state)).begin();
				if (newSymbol.size() > 1 && newSymbol.at(newSymbol.size() - 2) == '|')
				{
					newSymbol.insert(0, "(");
					newSymbol += ")";
				}
				if (selfTransition.symbol.size() > 1)
				{
					newSymbol += "(";
					newSymbol += selfTransition.symbol;
					newSymbol += ")";
					newSymbol += "*";
				}
				else
				{
					newSymbol += selfTransition.symbol;
					newSymbol += "*";
				}
			}

			//add the symbols(s) of the second transition
			if (secondTransition.symbol != NFARegexConstants::lambda)
			{
				if (newSymbol.size() > 1 && newSymbol.at(newSymbol.size() - 2) == '|')
				{
					newSymbol.insert(0, "(");
					newSymbol += ")";
				}
				if (secondTransition.symbol.size() > 1 && secondTransition.symbol[1] == '|')
				{
					newSymbol.insert(newSymbol.size(), "(");
					newSymbol += secondTransition.symbol;
					newSymbol.insert(newSymbol.size(), ")");
				}
				else
				{
					newSymbol += secondTransition.symbol;
				}
			}

			//deal with direct transitions
			if (m_nfa.getAllTransitionsBetween(inputOutputPair.first, inputOutputPair.second).size())
			{
				NFA::Transition directTransition = *(m_nfa.getAllTransitionsBetween(inputOutputPair.first, inputOutputPair.second).begin());
				if (newSymbol.size() > 1)
				{
					newSymbol.insert(0, "(");
					newSymbol += ")";
				}
				newSymbol += "|";
				if (directTransition.symbol.size() > 1)
				{
					newSymbol += "(";
					newSymbol += directTransition.symbol;
					newSymbol += ")";
				}
				else
				{
					newSymbol += directTransition.symbol;
				}
				m_nfa.deleteTransitions(inputOutputPair.first, inputOutputPair.second);
			}
			m_nfa.addTransition(inputOutputPair.first, newSymbol, inputOutputPair.second);
		}
		m_nfa.removeState(state);
	}
	m_pattern = m_nfa.getAllTransitionsBetween(NFARegexConstants::START_STATE, NFARegexConstants::FINAL_STATE).begin()->symbol;
}

void Regex::simplifyPattern()
{
	replaceTilde();
}

void Regex::replaceTilde()
{
	size_t pos = 0;
	while ((pos = m_pattern.find("|~", pos)) != std::string::npos) 
	{
		m_pattern.replace(pos, 2, "*");
		pos += 1;
	}
}