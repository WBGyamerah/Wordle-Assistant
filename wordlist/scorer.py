def score(words):
    nletters = {} #Dictionary to store letter and number of appearances
    for word in words:
        for letter in word:
            if letter in nletters:
                nletters[letter] += 1
            else:
                nletters[letter] = 1
    for letter, count in nletters.items():
        print(letter + ": " + str(count))
            
    

words = []
with open("C:/Users/zerte/OneDrive/Documents/GitHub\Wordle-Assistant/wordlist/wordlist.txt", "r") as wordlist:
    for word in wordlist:
        words.append(word)
score(words)


        