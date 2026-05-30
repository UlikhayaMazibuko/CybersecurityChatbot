// This class contains all the chatbot's behaviour.

using System;
using System.Collections.Generic;
using System.Media;
using System.IO;

class ChatBot
{
    // PART 2 ADDITION: UserName is now a public property so the GUI form can
    // access and set it directly, instead of it being a local variable inside a method
    public string UserName { get; set; }

    private Dictionary<string, string> memory = new Dictionary<string, string>();

    private string lastTopic = "";

    private Random random = new Random();

    private List<string> phishingResponses = new List<string>
    {
        "Phishing tip: Always check the sender's email address carefully. Scammers use addresses that look almost identical to real ones.",
        "Phishing tip: Legitimate banks and companies will never ask for your password via email or SMS.",
        "Phishing tip: Hover over links before clicking them to see where they really lead.",
        "Phishing tip: Be suspicious of emails creating urgency like 'Your account will be closed in 24 hours'.",
        "Phishing tip: When in doubt, go directly to the company's official website instead of clicking any link."
    };

    private List<string> followUpPhrases = new List<string>
    {
        "tell me more", "explain more", "give me another tip",
        "more", "continue", "go on", "what else", "another one"
    };

    // PART 1
    // This plays the voice greeting WAV file when the app starts
    public void PlayVoiceGreeting()
    {
        try
        {
            string audioPath = "greeting.wav";

            if (File.Exists(audioPath))
            {
                SoundPlayer player = new SoundPlayer(audioPath);
                player.Play();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Audio error: {ex.Message}");
        }
    }

    // This was used in the console version to display ASCII art.
    public void DisplayAsciiArt()
    {
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
        Console.ResetColor();
    }

    // PART 2 ADDITION: GetResponse is the new main method for the GUI.
    // The form calls this with the user's input and gets a string back.
    // This replaces RunConversation() for the GUI version.
    // All Part 1 responses are kept here, plus all new Part 2 features.
    public string GetResponse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "I didn't catch that. Could you rephrase?";

        string lower = input.Trim().ToLower();

        string sentimentPrefix = DetectSentiment(lower);

        if (IsFollowUp(lower))
            return sentimentPrefix + HandleFollowUp();

        if (lower.Contains("my favourite topic is"))
        {
            string topic = lower.Replace("my favourite topic is", "").Trim();
            memory["favourite topic"] = topic;
            lastTopic = topic;
            return sentimentPrefix + $"Got it! I will remember that your favourite topic is {topic}. I will keep that in mind as we chat.";
        }

        if (lower.Contains("i am interested in") || lower.Contains("i'm interested in"))
        {
            string interest = lower.Replace("i am interested in", "").Replace("i'm interested in", "").Trim();
            memory["interest"] = interest;
            lastTopic = interest;
            return sentimentPrefix + $"Noted! I will remember that you are interested in {interest}.";
        }

        if (lower.Contains("what do you remember") || lower.Contains("what do you know about me"))
            return RecallMemory();

        if (lower == "exit" || lower == "quit" || lower == "bye")
            return $"Goodbye, {UserName}! Stay safe online. Remember: think before you click!";

        if (lower.Contains("how are you"))
        {
            return sentimentPrefix + "I am doing great, thank you for asking! Ready to help you stay cyber-safe.";
        }

        if (lower.Contains("purpose") || lower.Contains("what do you do"))
        {
            return sentimentPrefix + "My purpose is to educate you about cybersecurity. I can help with password safety, recognising phishing, scams, and safe browsing habits.";
        }

        if (lower.Contains("what can") && lower.Contains("ask"))
        {
            return "You can ask me about:\n- Password safety\n- Phishing scams\n- Safe browsing\n- 2FA\n- Social engineering\n- Public Wi-Fi\n- Scams\n- Privacy\n- Malware\n- Viruses";
        }

        if (lower.Contains("phishing"))
        {
            lastTopic = "phishing";
            int index = random.Next(phishingResponses.Count);
            return sentimentPrefix + phishingResponses[index];
        }

        if (lower.Contains("password"))
        {
            lastTopic = "password";
            return sentimentPrefix + "Password safety tip: Use at least 12 characters with a mix of letters, numbers, and symbols. Never reuse passwords across sites — use a password manager instead!";
        }

        if (lower.Contains("browsing") || lower.Contains("safe browsing"))
        {
            lastTopic = "safe browsing";
            return sentimentPrefix + "Safe browsing tip: Look for 'https://' and the padlock icon before entering any personal info on a website. Avoid using public Wi-Fi for banking or shopping.";
        }

        if (lower.Contains("2fa") || lower.Contains("two factor"))
        {
            lastTopic = "2fa";
            return sentimentPrefix + "Two-Factor Authentication (2FA) adds an extra layer of security. Even if someone steals your password, they still cannot access your account without the second verification step.";
        }

        if (lower.Contains("social engineering"))
        {
            lastTopic = "social engineering";
            return sentimentPrefix + "Social engineering is when attackers manipulate people into revealing confidential info. Always verify who you are speaking to before sharing any personal details.";
        }

        if (lower.Contains("wifi") || lower.Contains("wi-fi"))
        {
            lastTopic = "wifi";
            return sentimentPrefix + "Public Wi-Fi is risky! Avoid accessing banking or personal accounts on public networks. Use a VPN if you must connect to public Wi-Fi.";
        }

        if (lower.Contains("scam"))
        {
            lastTopic = "scam";
            return sentimentPrefix + "Scam alert: If something feels too good to be true, it usually is. Never send money or personal information to someone you do not know online.";
        }

        if (lower.Contains("privacy"))
        {
            lastTopic = "privacy";
            return sentimentPrefix + "Privacy tip: Review your social media privacy settings regularly. Limit what personal information you share publicly online.";
        }

        if (lower.Contains("malware"))
        {
            lastTopic = "malware";
            return sentimentPrefix + "Malware warning: Never click on pop-up ads claiming your computer is infected. These are often the malware itself. Keep your antivirus software updated.";
        }

        if (lower.Contains("virus"))
        {
            lastTopic = "virus";
            return sentimentPrefix + "Virus protection: Keep your antivirus software updated at all times and avoid downloading files from untrusted or unfamiliar sources.";
        }

        return "I didn't quite understand that. Could you rephrase? Try asking about passwords, phishing, or safe browsing. Type 'what can I ask' to see all topics.";
    }


    // PART 2 ADDITION: Sentiment detection
    // Checks the user's message for emotional keywords and returns
    // an empathetic opening phrase to prefix the bot's response.
    private string DetectSentiment(string input)
    {
        List<string> worriedWords = new List<string>
        {
            "worried", "scared", "anxious", "nervous", "afraid", "fear", "hacked", "attacked", "help"
        };

        List<string> frustratedWords = new List<string>
        {
            "frustrated", "annoyed", "confused", "dont understand", "don't understand", "lost", "complicated"
        };

        List<string> curiousWords = new List<string>
        {
            "curious", "interested", "want to know", "wondering", "how does", "what is", "can you explain"
        };

        foreach (string word in worriedWords)
        {
            if (input.Contains(word))
                return "I understand this can feel overwhelming. Take a breath — I am here to help. ";
        }

        foreach (string word in frustratedWords)
        {
            if (input.Contains(word))
                return "No worries, let me explain this more clearly. ";
        }

        foreach (string word in curiousWords)
        {
            if (input.Contains(word))
                return "Great question! I love the curiosity. ";
        }

        return "";
    }

    // PART 2 ADDITION: Checks if the user's message is a follow-up
    private bool IsFollowUp(string input)
    {
        foreach (string phrase in followUpPhrases)
        {
            if (input.Contains(phrase))
                return true;
        }
        return false;
    }

    // PART 2 ADDITION: Handles follow-up by continuing the last topic
    private string HandleFollowUp()
    {
        if (string.IsNullOrEmpty(lastTopic))
            return "I am not sure what topic you would like more on. Could you be more specific? For example: 'tell me more about passwords'.";

        if (lastTopic == "phishing")
        {
            int index = random.Next(phishingResponses.Count);
            return "Here is another phishing tip: " + phishingResponses[index];
        }

        switch (lastTopic)
        {
            case "password":
                return "More on passwords: Consider using a password manager like Bitwarden or LastPass. These tools generate and store strong unique passwords for every site so you never have to remember them all.";
            case "safe browsing":
                return "More on safe browsing: Install a browser extension like uBlock Origin to block malicious ads and trackers. Always keep your browser updated to the latest version.";
            case "2fa":
                return "More on 2FA: The most secure form of 2FA is an authenticator app like Google Authenticator or Microsoft Authenticator. Avoid SMS-based 2FA when possible as SIM swapping attacks can bypass it.";
            case "wifi":
                return "More on Wi-Fi safety: A VPN (Virtual Private Network) encrypts all your internet traffic, making it much harder for anyone on the same network to spy on your activity.";
            case "social engineering":
                return "More on social engineering: Common attacks include pretexting (creating a fake scenario), baiting (leaving infected USB drives), and vishing (voice phishing over phone calls).";
            case "scam":
                return "More on scams: Romance scams, lottery scams, and job offer scams are extremely common in South Africa. Always verify the identity of anyone who contacts you unexpectedly.";
            case "privacy":
                return "More on privacy: Use a private browser like Firefox or Brave. Search with DuckDuckGo instead of Google to avoid having your searches tracked and stored.";
            case "malware":
            case "virus":
                return "More on malware: Types include ransomware (locks your files for payment), spyware (monitors your activity), and trojans (disguise themselves as legitimate software).";
            default:
                return $"I do not have additional details on {lastTopic} right now. Try asking about a different cybersecurity topic!";
        }
    }

    // PART 2 ADDITION: Recalls what the bot has stored about the user
    private string RecallMemory()
    {
        if (memory.Count == 0)
            return $"I do not have anything stored about you yet, {UserName}. Try telling me your favourite topic or what you are interested in learning about!";

        string recall = $"Here is what I remember about you, {UserName}:\n";
        foreach (var entry in memory)
        {
            recall += $"- Your {entry.Key}: {entry.Value}\n";
        }
        return recall;
    }
}