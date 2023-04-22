#include "NFA.h"
#include <fstream>
#include <string>
#include <iostream>
#include <numeric>
#include <algorithm>
#include <queue>

NFA::NFA(std::string_view fileName)
{

    std::ifstream inputFile(fileName.data());

    if (!inputFile.is_open())
    {
        throw std::runtime_error("Failed to open file");
    }

    readStates(inputFile);
    readInputAlphabet(inputFile);
    readStartState(inputFile);
    readFinalStates(inputFile);
    readTransitions(inputFile);
}

NFA::NFA()
{

}

void NFA::printAutomaton() const
{
    std::cout << "States: ";
    for (auto state : m_states)
    {
        std::cout << state << " ";
    }
    std::cout << std::endl;

    std::cout << "Input Alphabet: ";
    for (auto symbol : m_inputAlphabet)
    {
        std::cout << symbol << " ";
    }
    std::cout << std::endl;

    std::cout << "Start State: " << m_startState << std::endl;

    std::cout << "Final States: ";
    for (auto state : m_finalStates)
    {
        std::cout << state << " ";
    }
    std::cout << std::endl;

    std::cout << "Transitions: " << std::endl;
    for (const auto& [sourceState, transitions] : m_transitions)
    {
        for (const auto& transition : transitions)
        {
            std::cout << transition.sourceState << " - "
                << transition.symbol << " -> {";
            std::cout << transition.destState << " ";
            std::cout << "}" << std::endl;
        }
    }
}


void NFA::addState(char state)
{
    m_states.insert(state);
}

void NFA::addFinalState(char finalState)
{
    m_finalStates.insert(finalState);
}

void NFA::removeState(char state)
{
    // Remove state from m_states
    m_states.erase(state);

    // Remove all transitions with the given state as the source state
    for (auto it = m_transitions.begin(); it != m_transitions.end(); ++it)
    {
        auto& transitions = it->second;
        transitions.erase(
            std::remove_if(transitions.begin(), transitions.end(),
                [&state](const Transition& t)
                {
                    return t.sourceState == state;
                }
            ),
            transitions.end()
                    );
    }

    // Remove all transitions with the given state as the destination state
    for (auto it = m_transitions.begin(); it != m_transitions.end(); ++it)
    {
        auto& transitions = it->second;
        transitions.erase(
            std::remove_if(transitions.begin(), transitions.end(),
                [&state](const Transition& t)
                {
                    return t.destState == state;
                }
            ),
            transitions.end()
                    );
    }
}


void NFA::readStates(std::ifstream& inputFile)
{
    std::string line;
    std::getline(inputFile, line);
    for (char state : line)
    {
        m_states.insert(state);
    }
}


void NFA::readInputAlphabet(std::ifstream& inputFile)
{
    std::string line;
    std::getline(inputFile, line);
    for (char symbol : line)
    {
        std::string temp = "";
        temp += symbol;
        m_inputAlphabet.insert(temp);
    }
}

void NFA::readStartState(std::ifstream& inputFile)
{
    std::string line;
    std::getline(inputFile, line);
    if (line.size() != NFARegexConstants::STATE_LENGTH || !(m_states.count(line[NFARegexConstants::STATE_LENGTH - 1])))
    {
        throw std::runtime_error("Invalid start state: " + line);
    }
    m_startState = line[NFARegexConstants::STATE_LENGTH - 1];
}


void NFA::readFinalStates(std::ifstream& inputFile)
{
    std::string line;
    std::getline(inputFile, line);
    for (char state : line)
    {
        m_finalStates.insert(state);
        if (!m_states.count(state))
        {
            throw std::runtime_error("Invalid final state: " + state);
        }
    }
}

void NFA::readTransitions(std::ifstream& inputFile)
{
    std::string line;
    while (std::getline(inputFile, line))
    {
        if (line.size() != NFARegexConstants::TRANSITION_LENGTH)
        {
            throw std::runtime_error("Invalid transition");
        }

        const char sourceState = line[NFARegexConstants::SOURCE_STATE_POS];
        const std::string symbol = std::string(1, line[NFARegexConstants::SYMBOL_POS]);
        const char destState = line[NFARegexConstants::DEST_STATE_POS];

        if (!m_states.count(sourceState) || !m_states.count(destState))
        {
            throw std::runtime_error("Invalid transition: source or destination state not found");
        }

        if (!m_inputAlphabet.count(symbol) && NFARegexConstants::lambda != symbol)
        {
            throw std::runtime_error("Invalid transition: symbol not found in input alphabet");
        }

        m_transitions[sourceState].emplace_back(sourceState, symbol, destState);
    }
}

void NFA::addTransition(char startState, const std::string& nonterminal, char destState)
{
    Transition transition(startState, nonterminal, destState);
    m_transitions[startState].push_back(transition);
}


void NFA::setStartState(char state)
{
    m_startState = state;
}

void NFA::removeFinalStates()
{
    m_finalStates.clear();
}

std::map<std::pair<char, char>, int> NFA::calculateTransitionFrequency() const
{
    std::map<std::pair<char, char>, int> transitionsFreq;
    for (const auto& [state, transitions] : m_transitions)
    {
        for (const auto& transition : transitions)
        {
            transitionsFreq[{transition.sourceState, transition.destState}]++;
        }
    }
    return transitionsFreq;
}

std::vector<NFA::Transition> NFA::getAllTransitionsBetween(char sourceState, char destState) const
{
    std::vector<Transition> transitions;

    if (m_transitions.count(sourceState) > 0)
    {
        for (const auto& transition : m_transitions.at(sourceState))
        {
            if (transition.destState == destState)
            {
                transitions.emplace_back(sourceState, transition.symbol, destState);
            }
        }
    }

    return transitions;
}


void NFA::mergeTransitions()
{
    std::map<std::pair<char, char>, int> frequencyList = calculateTransitionFrequency();
    for (const auto& [statePair, frequency] : frequencyList)
    {
        if (frequency > 1)
        {
            std::vector<NFA::Transition> transitions = getAllTransitionsBetween(statePair.first, statePair.second);
            std::string newSymbol = "";
            for (const auto& transition : transitions)
            {
                newSymbol += transition.symbol;
                newSymbol += "|";
            }
            newSymbol.erase(newSymbol.size() - 1, 1);
            deleteTransitions(statePair.first, statePair.second);
            addTransition(statePair.first, newSymbol, statePair.second);
        }
    }
}


std::set<char> NFA::getIncomingStates(char state) const
{
    std::set<char> incomingStates;

    for (const auto& [srcState, transitions] : m_transitions)
    {
        for (const auto& transition : transitions)
        {
            if (transition.destState == state && transition.sourceState != state)
            {
                incomingStates.insert(transition.sourceState);
            }
        }
    }

    return incomingStates;
}




std::set<char> NFA::getOutgoingStates(char state) const
{
    std::set<char> outgoingStates;

    if (m_transitions.count(state) > 0)
    {
        for (const auto& transition : m_transitions.at(state))
        {
            if (transition.destState != state)
            {
                outgoingStates.insert(transition.destState);
            }
        }
    }

    return outgoingStates;
}



std::vector<std::pair<char, char>> NFA::getInputOutputPairs(char state) const 
{
    std::vector<std::pair<char, char>> inputOutputPairs;

    // Get the set of incoming states
    std::set<char> incomingStates = getIncomingStates(state);

    // Get the set of outgoing states
    std::set<char> outgoingStates = getOutgoingStates(state);

    // Create input-output state pairs
    for (const auto& inState : incomingStates) 
    {
        for (const auto& outState : outgoingStates) 
        {
            inputOutputPairs.emplace_back(inState, outState);
        }
    }

    return inputOutputPairs;
}

bool NFA::checkWord(std::string word) const
{
    std::queue<std::pair<std::string, char>> words;
    words.push({ word, m_startState });

    while (!words.empty())
    {
        const auto& [current_word, current_state] = words.front();

        // Find all transitions from the current state
        const auto& transitions = m_transitions.find(current_state);
        if (transitions == m_transitions.end()) {
            words.pop();
            continue;
        }

        for (const auto& transition : transitions->second)
        {
            // Check if the transition symbol matches the first character of the current word
            if (transition.symbol[0] == current_word[0])
            {
                std::string temp = current_word;
                temp.erase(0, 1);

                // If the current word has been completely consumed and the current state is a final state, return true
                if (temp.empty() && m_finalStates.count(transition.destState) > 0)
                {
                    return true;
                }

                // Add the remaining word and the destination state of the transition to the queue
                words.push({ temp, transition.destState });
            }
        }

        // Remove the current word and state from the queue
        words.pop();
    }

    // If the queue is empty and no final state was reached, return false
    return false;
}



void NFA::deleteTransitions(char sourceState, char destState)
{
    auto& transitions = m_transitions[sourceState];
    for (auto it = transitions.begin(); it != transitions.end(); )
    {
        if (it->destState == destState)
        {
            it = transitions.erase(it);
        }
        else
        {
            ++it;
        }
    }
}