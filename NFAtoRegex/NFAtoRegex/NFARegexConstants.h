#pragma once
#include <string>

namespace NFARegexConstants 
{
    const int SOURCE_STATE_POS = 0;
    const int SYMBOL_POS = 2;
    const int DEST_STATE_POS = 7;
    const int TRANSITION_LENGTH = 8;
    const int STATE_LENGTH = 1;
    const char START_STATE = '^';
    const char FINAL_STATE = '$';
    const std::string lambda = "~";
}