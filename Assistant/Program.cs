using System.Runtime.InteropServices;

public class MainClass
{
    private static int wordLen = 5;
    public static void Main()
    {
        bool isfinished = false;
        string word;

        Dictionary<string, int> wordScores = LibraryClass.library();
        while (isfinished == false)
        {
            suggest(wordScores);
            word = getInput();
            wordScores = checkColour(wordScores, word);
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
    public static Dictionary<string, int> checkColour(Dictionary<string, int> wordScores,string word)
    {
        foreach (char letter in word)
        {
            int pos = word.IndexOf(letter); 
            Console.WriteLine("What colour was " + letter + "(Green[1]/Yellow[2]/Grey[3])");
            string answer = Console.ReadLine()!;
            while (!answer.Equals("1") && !answer.Equals("2") && !answer.Equals("3"))
            {
                answer = Console.ReadLine()!;
            }
            switch (answer)
            {
                case "GREEN":
                    wordScores = LibraryClass.removeLetter(wordScores, letter, pos, 'G');
                    break;
                case "YELLOW":
                    wordScores = LibraryClass.removeLetter(wordScores, letter, pos, 'Y');
                    break;
                case "GREY":
                    wordScores = LibraryClass.removeLetter(wordScores, letter, pos, 'O');
                    break;
            }
        }
        return wordScores;
    }
    public static void suggest(Dictionary<string, int> wordScores)
    {
        Console.WriteLine("Suggestions: ");
        foreach (var pair in wordScores.Take(10))
        {
            Console.WriteLine(pair.Key);
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
        Console.WriteLine("Are these the correct words Y/N");
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