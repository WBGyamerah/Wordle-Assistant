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
        return wordScores;
    }

    public static Dictionary<string, int> removeLetter(Dictionary<string, int> wordScores, char letter, int pos, char marker)
    {
        switch (marker)
        {
            case '1':
                foreach (var wordScore in wordScores)
                {
                    if (wordScore.Key[pos] != letter) // Remove words that contain any other letter in the specified position
                    {
                        wordScores.Remove(wordScore.Key);
                    }
                }
                return wordScores;
            case '2':
                foreach (var wordScore in wordScores) 
                {
                    if (wordScore.Key.Contains(letter) && wordScore.Key[pos] == letter) // Remove words that contain the letter in the specified position
                    {
                        wordScores.Remove(wordScore.Key);
                    }
                }
                return wordScores;
            case '3':
                foreach (var wordScore in wordScores)
                {
                    if (wordScore.Key.Contains(letter)) // Remove words that contain the letter
                    {
                        wordScores.Remove(wordScore.Key);
                    }
                }
                return wordScores;
        }
        return wordScores;
    }
}