#include <iostream>
#include <fstream>
#include "Regex.h"

void displayMenu()
{
	std::cout << "0 - Print automaton" << std::endl;
	std::cout << "1 - Get regular expression" << std::endl;
	std::cout << "2 - Check if a word is accepted by the regular expression" << std::endl;
	std::cout << "3 - Exit" << std::endl;
}

void printAutomaton(const NFA& automaton)
{
	automaton.printAutomaton();
	system("pause");
	system("cls");
}

void printRegularExpression(const NFA& automaton)
{
	Regex reg(automaton);
	std::cout << reg.getPattern() << std::endl;
	system("pause");
	system("cls");
}

void checkWord(const NFA& automaton)
{
	std::string word{};
	std::cout << "Please enter the word you wish to check: ";
	std::cin >> word;
	if (automaton.checkWord(word))
	{
		std::cout << "The word is accepted by the regular expression" << std::endl;;
	}
	else
	{
		std::cout << "The word is NOT accepted by the regular expression" << std::endl;;
	}
	system("pause");
	system("cls");
}

void processOption(const NFA& automaton, int option)
{
	switch (option)
	{
	case 0:
		printAutomaton(automaton);
		break;
	case 1:
		printRegularExpression(automaton);
		break;
	case 2:
		checkWord(automaton);
		break;
	case 3:
		break;
	default:
		std::cout << "Please enter a valid option";
		system("pause");
		system("cls");
		break;
	}
}

void handleUserInput(const NFA& automaton)
{
	int option = 0;
	const int OPTIONS = 3;

	while (option != OPTIONS)
	{
		displayMenu();
		std::cin >> option;
		processOption(automaton, option);
	}
}

int main()
{
	try {
		NFA automaton("Input.txt");
		handleUserInput(automaton);
	}
	catch (const std::exception& ex) {
		std::cerr << "Exception caught: " << ex.what() << std::endl;
	}
	return 0;
}
