public class LibraryClass
{
    
    public static string[] library(char[][] sides, int nsides)
    {
        List<string> words = new List<string>();
        string word;

        using StreamReader reader = new("C:/Users/zerte/OneDrive/Desktop/LetterBoxed Solver/wordlist.txt");
        while ((word = reader.ReadLine()) != null)
        {
            bool isvalid = isValid(sides, word, nsides);
            if (isvalid == true)
            {
                words.Add(word);
            }
        }
        reader.Close();
        return words.ToArray();
    }
    public static bool isValid(char[][] sides, string word, int nsides)
    {
        int lastside = -1;

        for(int i = 0; i < word.Length; i++)
        {
            char letter = word[i];
            int curside = -1;

            for (int s = 0; s < nsides; s++)
            {
                if (sides[s].Contains(letter))
                {
                    curside = s;
                    break;
                }
            }

            if(curside == -1)
            {
                return false;
            }

            if (curside == lastside) //Checks if the side of the previous letter is the same as the current letter
            {
                return false;
            }

            lastside = curside;
        }
        return true;
    }
}
