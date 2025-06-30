def scoreletters(words):
    nletters = {} #Dictionary to store letter and number of appearances
    scoredletters = []
    for word in words:
        for letter in word:
            if letter in nletters:
                nletters[letter] += 1
            else:
                nletters[letter] = 1
    for letter, count in sorted(nletters.items(), key=lambda item: item[1]): #Sorting by count ascending
        scoredletters.append(letter)
    return scoredletters
        

def scorewords(words, letters):
    scoredwords = {}
    for word in words:
        score = 0
        for letter in word:
            score += letters.index(letter)
        scoredwords[word] = score
    for word, scores in sorted(scoredwords.items(), key=lambda item: item[1], reverse=True): #Sorting by count ascending
         print(word + ": ", scores)


words = []
with open("C:/Users/zerte/OneDrive/Documents/GitHub\Wordle-Assistant/wordlist/wordlist.txt", "r") as wordlist:
    for word in wordlist:
        words.append(word)
letters = scoreletters(words)
scorewords(words, letters)


        