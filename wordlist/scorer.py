from collections import defaultdict

def scoreletters(words):
    nletters = defaultdict(lambda: [0, 0, 0, 0, 0]) #Allows me format the values, without keys
    for word in words:
        for index, letter in enumerate(word):
            nletters[letter][index] += 1
    scoredletters = sorted(nletters.items(), key=lambda item: item[0]) #Alphabetically orders the list
    return scoredletters
        
def scorewords(words, letters):
    scoredwords = {}
    for word in words:
        score = 0
        for index, letter in enumerate(word):
            score += letters[letter][index]
        scoredwords[word] = score
    scoredwords = sorted(scoredwords.items(), key=lambda item: (len(set(item[0])), item[1]), reverse=True) #Sort by unique characters and scores
    return scoredwords

words = []
with open("C:/Users/zerte/OneDrive/Documents/GitHub\Wordle-Assistant/wordlist/wordlist.txt", "r") as wordlist:
    for word in wordlist:
        words.append(word.strip())
letters = dict(scoreletters(words))
scoredwords = scorewords(words, letters)
with open("C:/Users/zerte/OneDrive/Documents/GitHub/Wordle-Assistant/wordlist/wordlelist.txt", "w") as newfile:
        for word, score in scoredwords:
            newfile.write(f"{word}\n") #write can only use single strings so i couldnt use concatenation


        