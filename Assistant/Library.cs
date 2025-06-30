public class LibraryClass
{
    public static Dictionary<string, int> library()
    {
        Dictionary<string, int> wordScores = new Dictionary<string, int> { };
        using StreamReader reader = new("C:/Users/zerte/OneDrive/Desktop/LetterBoxed Solver/wordlist.txt");
        while (!reader.EndOfStream)
        {
            string word = reader.ReadLine()!; //Discovered an exclamation mark removes the warning
            int score = int.Parse(reader.ReadLine()!);
            wordScores.Add(word, score);
        }
        var sorted = wordScores.OrderByDescending(pair => pair.Key.Distinct().Count()).ThenByDescending(pair => pair.Value); //Sort by unique characters, then sort by scores
        return wordScores;
    }
}