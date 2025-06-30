public class LibraryClass
{
    public static Dictionary<string, int> library()
    {
        Dictionary<string, int> wordScores = new Dictionary<string, int> { };
        using StreamReader reader = new("C:/Users/zerte/OneDrive/Documents/GitHub/Wordle-Assistant/wordlist/wordlelist.txt");
        while (!reader.EndOfStream)
        {
            string word = reader.ReadLine()!; //Discovered an exclamation mark removes the warning
            int score = int.Parse(reader.ReadLine()!);
            wordScores.Add(word, score);
        }
        var sorted = wordScores.OrderByDescending(pair => pair.Key.Distinct().Count()).ThenByDescending(pair => pair.Value) //Sort by unique characters, then sort by scores
        .ToDictionary(pair => pair.Key, pair => pair.Value); //returns a list so needs to be turned back to a dictionary
        return sorted;
    }

    public static Dictionary<string, int> removeLetter(Dictionary<string, int> wordScores, char letter, int pos, char marker)
    {
        switch (marker)
        {
            case 'G':
                foreach (var wordScore in wordScores)
                {
                    if (wordScore.Key[pos] != letter)
                    {
                        wordScores.Remove(wordScore.Key);
                    }
                }
                return wordScores;
            case 'Y':
                foreach (var wordScore in wordScores)
                {
                    if (wordScore.Key.Contains(letter) && wordScore.Key[pos] == letter)
                    {
                        wordScores.Remove(wordScore.Key);
                    }
                }
                return wordScores;
            case 'O':
                foreach (var wordScore in wordScores)
                {
                    if (wordScore.Key.Contains(letter))
                    {
                        wordScores.Remove(wordScore.Key);
                    }
                }
                return wordScores;
        }
        return wordScores;
    }
}