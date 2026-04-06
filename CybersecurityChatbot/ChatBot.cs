// This class contains all the chatbot's behaviour

using System;
using System.Media; // we'll need this for the voice greeting using a SoundPlayer
using System.IO;


class ChatBot {

    // This method is called from Program.cs to start the program
    public void Start() {
        PlayVoiceGreeting(); // This will set off the voice
        DisplayAsciiArt(); // This will display the logo
        string userName = GreetUser(); // This right here will ask for the name and store it
        RunConversation(userName);
    }

    // This will be the voice greeting audio file (WAV file)
    private void PlayVoiceGreeting() {
        try
        {
            string audioPath = "greeting.wav"; // This builds the path to the WAV file 

            // This will check if the file actually exists before trying to play it
            if (File.Exists(audioPath))
            {

                SoundPlayer player = new SoundPlayer(audioPath);
                player.PlaySync(); // This will play the whole file before moving on
            }
            else
            {
                // If the file is missing, this will warn the user instead of crashing the program
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Note: Voice greeting file not found. Skipping audio.]");
                Console.ResetColor();
            }
        }
        catch (Exception ex) {
            // If there's anything unexpected that goes wrong, this will catch it
            Console.WriteLine($"Audio error: {ex.Message}");
        }
    }
    // This will draw a cybersecurity-themed logo using keyboard characters and show it as a title screen when the app launches
    private void DisplayAsciiArt() {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("  =====================================================");
        Console.WriteLine("  |                                                   |");
        Console.WriteLine("  |        CYBERSECURITY AWARENESS BOT                |");
        Console.WriteLine("  |                                                   |");
        Console.WriteLine("  |        /\\_____/\\     Stay Safe Online!          |");
        Console.WriteLine("  |        ( o     o )                                |");
        Console.WriteLine("  |         =  ---  =   [ Protect. Educate. Shield ]  |");
        Console.WriteLine("  |         \\_____/                                  |");
        Console.WriteLine("  |                                                   |");
        Console.WriteLine("  =====================================================");
        Console.WriteLine();
        Console.ResetColor(); // This is to always reset after colouring so next text is not also cyan
    }

    // This is the user greeting that will ask for the user's name and welcome them personally and also return the name so we can use it through out
    private string GreetUser() {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Welcome to the Cybersecurity Awareness Bot!");
        Console.WriteLine(" I'm here to help you stay safe online.");
        Console.WriteLine();
        Console.ResetColor();

        string userName = "";

        // This will keep asking until they actually type a name
        while (string.IsNullOrWhiteSpace(userName)) {
            Console.Write(" Please enter your name: ");
            userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Name cannot be empty. Please try again.");
                Console.ResetColor();
            }
        }

        // This will personalise the greeting using their name
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" Hello, {userName}! Great to meet you.");
        Console.WriteLine($" You can ask me about password safety, phishing or safe browsing.");
        Console.WriteLine($" Type 'exit' at any time to leave.");
        Console.ResetColor();
        Console.WriteLine();

        return userName;
    }

    // This is the conversation loop that keeps looping, reading input and responding until the user exits.
    private void RunConversation(string userName) {
        bool chatting = true;

        while (chatting) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {userName}: ");
            Console.ResetColor();

            string input = Console.ReadLine();

            // This will be the input validation which will handle emplty input first
            if (string.IsNullOrWhiteSpace(input)) {
                PrintBotResponse("I didn't catch that. Could you rephrase?");
                continue;
            }

            string lowerInput = input.ToLower();

            if (lowerInput == "exit" || lowerInput == "quit" || lowerInput == "bye") {
                PrintBotResponse($"Goodbye, {userName}! Stay safe online. Remember: think before you click!");
                chatting = false;
            }
            else if (lowerInput.Contains("how are you")) {
                PrintBotResponse("I'm doing great, thank you for asking! Ready to help you stay cyber-safe.");
            }
            else if (lowerInput.Contains("purpose") || lowerInput.Contains("what do you do")) {
                PrintBotResponse("My purpose is to educate you about cybersecurity. I can help with password safety, recognising phishing, and safe browsing habits.");
            }
            else if (lowerInput.Contains("what can") && lowerInput.Contains("ask")) {
                PrintBotResponse("You can ask me about:\n  - Password safety\n  - Phishing scams\n  - Safe browsing\n  - How are you / What's your purpose");
            }
            else if (lowerInput.Contains("password")) {
                PrintBotResponse("Password safety tip: Use at least 12 characters with a mix of letters, numbers, and symbols. Never reuse passwords across sites — use a password manager instead!");
            }
            else if (lowerInput.Contains("phishing")) {
                PrintBotResponse("Phishing alert! Phishing emails pretend to be from trusted sources to steal your info. Always check the sender's email address and never click suspicious links.");
            }
            else if (lowerInput.Contains("browsing") || lowerInput.Contains("safe browsing")) {
                PrintBotResponse("Safe browsing tip: Look for 'https://' and the padlock icon before entering any personal info on a website. Avoid using public Wi-Fi for banking or shopping.");
            }
            else {
                PrintBotResponse("I didn't quite understand that. Could you rephrase? Try asking about passwords, phishing, or safe browsing.");
            }
            Console.WriteLine();
        }
    }

    private void PrintBotResponse(string message) {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($" Bot: {message}");
        Console.ResetColor();
    }
}