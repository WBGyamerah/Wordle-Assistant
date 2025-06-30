import requests

def filterlist(unfiltered, length):
    filtered = []
    for word in unfiltered:
        if len(word) < length or len(word) > length:
            continue
        filtered.append(word)
    return filtered

length = 5  

listurl = "https://raw.githubusercontent.com/dwyl/english-words/refs/heads/master/words_alpha.txt" #wordlist source
response = requests.get(listurl)

if response.status_code == 200: #if the get request goes through unimpeded
    unfiltered = response.text.splitlines()
    filtered = filterlist(unfiltered, length)
    with open("C:/Users/zerte/OneDrive/Documents/GitHub/Wordle-Assistant/wordlist/wordlist.txt", "w") as newfile:
        for word in filtered:
            newfile.write(word + "\n")
else:
    print("Failed to download wordlist: HTTP {response.status_code}") #Returns error code allowing diagnosis