// this is the piglatin.cpp 
// C++ homework od homework 5
#include <iostream>
#include <cstring>
#include <string>
#include <locale>

using namespace std;

char* ToPigLatin(char * word) {
	char wordCopy[43];
	int length = 0; // this is the length of string
	while(word[length] != '\0')
		length++;
	bool calStart = isupper(word[0]));
	if(isVowel(word[0], true)) {
		strcpy(wordCopy, word);
		strcat(wordCopy, "way");
	} else {
		int moveStart = 0;
		int moveEnd = 0;
		while(isVowel(word[moveEnd], moveEnd == 0) 
			and moveEnd < length) {
			moveEnd++;
		}
		int pointer = 0;
		for(int i = moveEnd; i < length; i++) {
			wordCopy[pointer++] = word[i];
		}
		for(int i = 0; i < moveEnd; i++) {
			wordCopy[pointer++] = word[i];
		}
		strcat(wordCopy, "ay");
	}
	strcpy(word, wordCopy);
	if(calStart) word[0] = toUpper(word[0]);
	return word;
}

bool isVowel(char c, bool isStart) {
	if(isStart and (c == 'y' or c == 'Y') )
		return true;
	return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') or 
	(c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U');
}

int main(int argc, char** argv) {
	cout << "Pig Latin version of the 5 words:\n";
	for(int i = 1; i <= 5; i++) {
		cout << ToPigLatin(argv[i]) << " ";
	}
	cout << endl;
	return 0;
}