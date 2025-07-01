# Wordle-Assistant
Gives suggestions for guesses on wordle

## Thought process
I'll assign a value to letters based on how common those letters are within my wordlist, this will come with a few restrictions as my wordlist has extra words that are not included within the oxford dictionary. then using the values assigned to the letters, score each word in my wordlist. then sort by the highest scoring words. In my c# program I then sort the list by unique characters. then suggest the highest scoring words with the most unique characters. As the user enters words the wordlist and suggestions are updated in accordance to give better suggestions.

As it works through the terminal its not the most user friendly due to the constant validation checks.

### Resources
I've never used dictionaries in C# prior to this only in python and such I used stackoverflow a bunch
The word list used in this project is sourced from [dwyl/english-words](https://github.com/dwyl/english-words). You can access the raw word list here: [words_alpha.txt](https://raw.githubusercontent.com/dwyl/english-words/refs/heads/master/words_alpha.txt).
