#pragma once

#include <set>
#include <vector>
#include <map>
#include <string_view>

#include "NFARegexConstants.h"

class NFA
{

private:

	std::set<char> m_states;
	std::set<std::string> m_inputAlphabet;
	char m_startState{};
	std::set<char> m_finalStates;

public:

	struct Transition
	{
		char sourceState;
		std::string symbol;
		char destState;

		Transition(char sourceState_, const std::string& symbol_, char destState_)
			: sourceState(sourceState_), symbol(symbol_), destState(destState_) {}

	};

private:
	std::map<char, std::vector<Transition>> m_transitions;

	
public:
	NFA(std::string_view fileName);
	NFA();

	const std::set<char>& getStates() const { return m_states; }
	const std::set<std::string>& getInputAlphabet() const { return m_inputAlphabet; }
	char getStartState() const { return m_startState; }
	const std::set<char>& getFinalStates() const { return m_finalStates; }
	const std::map<char, std::vector<Transition>>& getTransitions() const { return m_transitions; }

	void printAutomaton() const;

	void removeState(char state);
	void addFinalState(char finalState);
	void addState(char state);
	void addTransition(char startState, const std::string& nonterminal, char nextState);
	void setStartState(char state);
	void removeFinalStates();
	void mergeTransitions();

	std::set<char> getIncomingStates(char state) const;
	std::set<char> getOutgoingStates(char state) const;
	std::vector<std::pair<char, char>> getInputOutputPairs(char state) const;
	void deleteTransitions(char sourceState, char destState);
	std::vector<NFA::Transition> getAllTransitionsBetween(char sourceState, char destState) const;

	bool checkWord(std::string word) const;

private:
	void readStates(std::ifstream& inputFile);
	void readInputAlphabet(std::ifstream& inputFile);
	void readStartState(std::ifstream& inputFile);
	void readFinalStates(std::ifstream& inputFile);
	void readTransitions(std::ifstream& inputFile);
	std::map<std::pair<char, char>, int> calculateTransitionFrequency() const;
	
};

