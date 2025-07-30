public class LibraryClass
{
    public static List<string> library()
    {
        List<string> wordList = new List<string> { };
        using StreamReader reader = new("C:/Users/zerte/OneDrive/Documents/GitHub/Wordle-Assistant/wordlist/wordlelist.txt");
        while (!reader.EndOfStream)
        {
            string word = reader.ReadLine()!; //Discovered an exclamation mark removes the warning
            wordList.Add(word);
        }
        return wordList;
    }

    public static List<string> removeLetter(List<string> wordList, char letter, int pos, char marker)
    {
        switch (marker)
        {
            case '1'://Green
                return wordList.Where(word => word[pos] == letter).ToList();
            case '2'://Yellow
                return wordList.Where(word => word.Contains(letter) && word[pos] != letter).ToList();
            case '3'://Gray
                return wordList.Where(word => !word.Contains(letter)).ToList();
        }
        return wordList;
    }
}