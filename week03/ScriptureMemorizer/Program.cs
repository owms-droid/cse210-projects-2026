using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Commands: press Enter (hide 3 words), 'hide <write number here>', 'reveal <write number here>', 'reset', 'help', 'quit'");
            Console.Write("Input: ");
            string input = Console.ReadLine();
            if (input == null) break;

            input = input.Trim();
            if (input.Length == 0)
            {
                scripture.HideRandomWords(3);
            }
            else
            {
                var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var cmd = parts[0].ToLower();
                int n = 1;
                if (parts.Length > 1) int.TryParse(parts[1], out n);

                switch (cmd)
                {
                    case "quit":
                    case "exit":
                        return;
                    case "help":
                        Console.WriteLine("Commands:\n  (Enter) - hide 3 words\n  hide N - hide N words\n  reveal N - reveal N words\n  reset - show all words\n  quit - exit");
                        break;
                    case "reset":
                        scripture.Reset();
                        break;
                    case "hide":
                        scripture.HideRandomWords(Math.Max(1, n));
                        break;
                    case "reveal":
                        scripture.RevealRandomWords(Math.Max(1, n));
                        break;
                    default:
                        Console.WriteLine("Unknown command. Type 'help' for options.");
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Good job!");
                break;
            }
        }
    }
}