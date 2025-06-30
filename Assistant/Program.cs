public class MainClass
{
    public static void Main()
    {
        Dictionary<string, int> wordScores = LibraryClass.library();
        Console.WriteLine("Starting word suggestions: ");
        for (int x = 0; x < 10; x++)
        {
            Console.WriteLine();
        }

    }
}