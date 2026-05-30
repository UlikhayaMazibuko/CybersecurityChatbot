class Program
{
    static void Main(string[] args)
    {
        // This starts the console version of the chatbot
        // The GUI version is handled by CybersecurityChatbot_GUI
        ChatBot bot = new ChatBot();
        bot.PlayVoiceGreeting();
        bot.DisplayAsciiArt();

        System.Console.Write(" Please enter your name: ");
        string name = System.Console.ReadLine();
        bot.UserName = name;

        System.Console.WriteLine($" Hello, {bot.UserName}! Type 'exit' to quit.");

        while (true)
        {
            System.Console.Write($" {bot.UserName}: ");
            string input = System.Console.ReadLine();
            string response = bot.GetResponse(input);
            System.Console.ForegroundColor = System.ConsoleColor.Magenta;
            System.Console.WriteLine($" Bot: {response}");
            System.Console.ResetColor();

            if (input.ToLower() == "exit" || input.ToLower() == "bye")
                break;
        }
    }
}