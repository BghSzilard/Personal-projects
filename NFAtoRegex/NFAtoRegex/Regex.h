#pragma once
#include <string>
#include "NFA.h"

class Regex
{
private:
	std::string m_pattern{};
	NFA m_nfa;

	void addNewStartState();
	void addNewFinalState();
	void createPattern();
	void simplifyPattern();
	void replaceTilde();
public:
	Regex(const NFA& nfa);
	std::string getPattern() const { return m_pattern; }

	NFA getNFA()
	{
		return m_nfa;
	}
};

