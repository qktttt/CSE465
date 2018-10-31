// this is the piglatin.cpp 
// C++ homework od homework 5
#include <iostream>
#include <cstring>
#include <string>

using namespace std;

char* ToPigLatin(char * word) {
	bool calStart = /*if the first character is calpitalized?*/;
	if(/*first character is vowel*/) {
		char[] result = /* word + "way"*/;
	} else { /*if the first character is consonant*/
		char[] partMoveToEnd = /*from the first letter to until first vowel*/;
		char[] restOfWord = /*from the first vowel to end*/;
		char[] result = /* restOfWord + partMoveToEnd + "ay" */; 
	}
	if(calStart) result[0] = /*calpitalied the first charater*/;
	return result;
}



int main(int argc, char** argv) {
	cout << "Pig Latin version of the 5 words:\n";
	for(int i = 1; i <= 5; i++) {
		cout << ToPigLatin(argv[i]) << " ";
	}
	cout << endl;
	return 0;
}