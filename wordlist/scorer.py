#Limitations vowels are in almost every word, but this is represented in the scores as letters like s t l appear as doubles and some vowels are just rarer.
def scoreletters(words):
    nletters = {} #Dictionary to store letter and number of appearances
    scoredletters = []
    for word in words:
        for letter in word:
            if letter in nletters:
                nletters[letter] += 1
            else:
                nletters[letter] = 1
    for letter, count in sorted(nletters.items(), key=lambda item: item[1]): #Sort by count ascending
        scoredletters.append(letter)
    return scoredletters
        
def scorewords(words, letters):
    scoredwords = {}
    for word in words:
        score = 0
        for letter in word:
            score += letters.index(letter)
        scoredwords[word] = score
    scoredwords = sorted(scoredwords.items(), key=lambda item: (len(set(item[0])), item[1]), reverse=True) #Sort by unique characters and scores
    return scoredwords

words = []
with open("C:/Users/zerte/OneDrive/Documents/GitHub\Wordle-Assistant/wordlist/wordlist.txt", "r") as wordlist:
    for word in wordlist:
        words.append(word)
letters = scoreletters(words)
scoredwords = scorewords(words, letters)
with open("C:/Users/zerte/OneDrive/Documents/GitHub/Wordle-Assistant/wordlist/wordlelist.txt", "w") as newfile:
        for word, score in scoredwords:
            newfile.write(f"{word}{score}\n") #write can only use single strings so i couldnt use concatenation


        