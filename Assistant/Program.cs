public class MainClass
{
    private static int wordLen = 5;
    public static void Main()
    {
        bool isfinished = false;
        string word;

        List<string> wordList = LibraryClass.library();
        while (isfinished == false)
        {
            suggest(wordList);
            word = getInput();
            wordList = checkColour(wordList, word);
            Console.WriteLine("Finished (Y/N)");
            string answer = Console.ReadLine()!.ToUpper();
            while (!answer.Equals("Y") && !answer.Equals("N"))
            {
                answer = Console.ReadLine()!.ToUpper();
            }
            if (answer.Equals("Y"))
            {
                isfinished = true;
            }
        }
    }
    public static List<string> checkColour(List<string> wordList,string word)
    {
        for(int pos = 0; pos < word.Length; pos++)
        {
            Console.WriteLine("What colour was " + word[pos] + "(Green[1]/Yellow[2]/Grey[3])");
            string answer = Console.ReadLine()!;
            while (!answer.Equals("1") && !answer.Equals("2") && !answer.Equals("3"))
            {
                answer = Console.ReadLine()!;
            }
            switch (answer)
            {
                case "1": //Green
                 wordList = LibraryClass.removeLetter(wordList, word[pos], pos, '1');
                    break;
                case "2": //Yellow
                 wordList = LibraryClass.removeLetter(wordList, word[pos], pos, '2');
                    break;
                case "3": //Gray
                 wordList = LibraryClass.removeLetter(wordList, word[pos], pos, '3');
                    break;
            }
        }
        return wordList;
    }
    public static void suggest(List<string> wordList) //gives the top 10 of the wordlist
    {
        Console.WriteLine("Suggestions: ");
        foreach (string word in wordList.Take(10))
        {
            Console.WriteLine(word);
        }
    }

    public static string getInput()
    {
        Console.WriteLine("What word was entered");
        string input = Console.ReadLine()!;
        while (validateInput(input) == false)
        {
            return getInput();
        }
        return input;
    }

    public static bool validateInput(string input) 
    {
        if (input.Length != wordLen)
        {
            Console.WriteLine("Invalid input, enter a word with" + wordLen + " letters");
            return false;
        }
        for(int i = 0; i < input.Length; i++)
        {
            if (input[i] < 'a' || input[i] > 'z') //Checks if inputted elements are between a and z (Char.IsLetter allows letters not within the english alphabet)
            {
                Console.WriteLine("Invalid input, no symbols or numbers");
                return false;
            }
        }
        Console.WriteLine(input);
        Console.WriteLine("Is this the word you entered Y/N");
        string answer = Console.ReadLine()!.ToUpper();
        while (!answer.Equals("Y") && !answer.Equals("N"))
        {
            answer = Console.ReadLine()!.ToUpper();
        }
        if (answer.Equals("N"))
        {
            return false;
        }
        return true;
    }
}