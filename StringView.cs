using System;
using StringProcessingApp.Services;

namespace StringProcessingApp.Views
{
    public class StringView
    {
        private readonly StringService _service = new StringService();

        public void Run()
        {
            string choice = "";
            while (choice != "11")
            {
                DisplayMenu();
                choice = Console.ReadLine();
                ProcessChoice(choice);
                if (choice != "11") 
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("=== String Processing System ===");
            Console.WriteLine($"Current Text: \"{_service.GetCurrentText()}\"");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Enter Text");
            Console.WriteLine("2. View Current Text");
            Console.WriteLine("3. Convert to UPPERCASE");
            Console.WriteLine("4. Convert to lowercase");
            Console.WriteLine("5. Count Characters");
            Console.WriteLine("6. Check if Contains Word");
            Console.WriteLine("7. Replace Word");
            Console.WriteLine("8. Extract Substring");
            Console.WriteLine("9. Trim Spaces");
            Console.WriteLine("10. Reset Text");
            Console.WriteLine("11. Exit");
            Console.Write("\nSelect an option: ");
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.Write("Enter new text: ");
                    _service.SetText(Console.ReadLine());
                    break;
                case "2":
                    Console.WriteLine($"Current Text: {_service.GetCurrentText()}");
                    break;
                case "3":
                    _service.ToUpper();
                    Console.WriteLine("Converted to UPPERCASE.");
                    break;
                case "4":
                    _service.ToLower();
                    Console.WriteLine("Converted to lowercase.");
                    break;
                case "5":
                    Console.WriteLine($"Length: {_service.GetLength()} characters.");
                    break;
                case "6":
                    Console.Write("Enter word to find: ");
                    string word = Console.ReadLine();
                    bool found = _service.ContainsWord(word);
                    Console.WriteLine(found ? "Word found!" : "Word not found.");
                    break;
                case "7":
                    Console.Write("Word to replace: ");
                    string oldW = Console.ReadLine();
                    Console.Write("Replacement word: ");
                    string newW = Console.ReadLine();
                    _service.ReplaceWord(oldW, newW);
                    break;
                case "8":
                    Console.Write("Start Index: ");
                    int start = int.Parse(Console.ReadLine());
                    Console.Write("Length: ");
                    int len = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Result: {_service.ExtractSubstring(start, len)}");
                    break;
                case "9":
                    _service.TrimSpaces();
                    Console.WriteLine("Spaces trimmed.");
                    break;
                case "10":
                    _service.Reset();
                    Console.WriteLine("Text reset to original.");
                    break;
            }
        }
    }
}
