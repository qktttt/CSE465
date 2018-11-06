// piglatin.cpp

#include <iostream>
#include <cstring>

using namespace std;

const int MAX = 43;

char* ToPigLatin(char* word);
bool isVowel(char c, bool isStart);

int main()
{
   // creation of 5 character strings, each length MAX
   char word[5][MAX];
   int i;				// loop counter

   cout << "Input 5 words: ";
   for (i = 0; i < 5; i++)
       cin >> word[i];

   cout << "\nPig Latin version of the 5 words:\n";
   for (i = 0; i < 3; i++)
   {
      ToPigLatin(word[i]);
      cout << word[i] << ' ';
   }
   // Note that the above outputs illustrate that the original
   //  string itself has been converted.  The outputs below illustrate
   //  that a pointer to this string is also being returned from the 
   //  function.

   cout << ToPigLatin(word[3]) << ' '
        << ToPigLatin(word[4]) << '\n';

   return 0;
}

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
	bool calStart = isupper(word[0]);
	if(isVowel(word[0], true)) {
		strcpy(wordCopy, word);
		strcat(wordCopy, "way");
	} else {
		int moveStart = 0;
		int moveEnd = 0;
		while(!isVowel(word[moveEnd], moveEnd == 0) 
			&& moveEnd < length) {
			moveEnd++;
		}
		int pointer = 0;
		for(int i = moveEnd; i < length; i++) {
			wordCopy[pointer++] = tolower(word[i]);
		}
		for(int i = 0; i < moveEnd; i++) {
			wordCopy[pointer++] = tolower(word[i]);
		}
		wordCopy[pointer++] = 'a';
		wordCopy[pointer++] = 'y';
		wordCopy[pointer] = '\0';
	}
	strcpy(word, wordCopy);
	if(calStart) word[0] = toupper(word[0]);
	return word;
}

bool isVowel(char c, bool isStart) {
	if(!isStart and (c == 'y' or c == 'Y') )
		return true;
	return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') or 
	(c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U');
}

// Write your definition of the ToPigLatin function here
