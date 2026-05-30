// ResponseBank.cs
// This file stores all the chatbot's responses in organised data structures.

using System;
using System.Collections.Generic;

class ResponseBank
{
    
    public static Dictionary<string, string> KeywordResponses = new Dictionary<string, string>
    {
        { "password", "Password tip: Use at least 12 characters with uppercase, lowercase, numbers, and symbols. Never reuse passwords across different sites." },
        { "scam", "Scam alert: If something feels too good to be true, it usually is. Never send money or personal info to someone you don't know." },
        { "privacy", "Privacy tip: Review your social media privacy settings regularly. Limit what personal information you share publicly online." },
        { "virus", "Virus protection: Keep your antivirus software updated and avoid downloading files from untrusted sources." },
        { "malware", "Malware warning: Never click on pop-up ads claiming your computer is infected. These are often the malware itself." },
        { "2fa", "Two-Factor Authentication adds an extra verification step. Even if someone has your password, they cannot access your account without the second factor." },
        { "wifi", "Public Wi-Fi is risky. Avoid logging into banking or personal accounts on public networks. Use a VPN when possible." },
        { "social engineering", "Social engineering attacks manipulate people psychologically. Always verify who you are speaking to before sharing any sensitive information." },
        { "phishing", "" },
        { "browsing", "Safe browsing tip: Always check for https and the padlock icon before entering personal information on any website." }
    };

    // Phishing gets multiple random responses to keep the conversation varied.
    // Each time the user asks about phishing, they get a different tip.
    public static List<string> PhishingResponses = new List<string>
    {
        "Phishing tip: Always check the sender's email address carefully. Scammers use addresses that look almost identical to real ones.",
        "Phishing tip: Legitimate banks and companies will never ask for your password via email or SMS.",
        "Phishing tip: Hover over links before clicking them to see the real destination URL.",
        "Phishing tip: Be suspicious of emails creating urgency like 'Your account will be closed in 24 hours'.",
        "Phishing tip: When in doubt, go directly to the company's official website instead of clicking any link."
    };

    // Follow-up phrases that indicate the user wants more information on the current topic.
    // This enables natural conversation flow without the user having to repeat themselves.
    public static List<string> FollowUpPhrases = new List<string>
    {
        "tell me more", "explain more", "give me another tip",
        "more", "continue", "go on", "what else", "another one"
    };

    // Sentiment keywords — words that reveal how the user is feeling.
    // The bot checks for these and adjusts its tone accordingly.
    public static List<string> WorriedWords = new List<string>
    {
        "worried", "scared", "anxious", "nervous", "afraid", "fear", "help", "attacked", "hacked"
    };

    public static List<string> FrustratedWords = new List<string>
    {
        "frustrated", "annoyed", "confused", "dont understand", "don't understand", "lost", "complicated"
    };

    public static List<string> CuriousWords = new List<string>
    {
        "curious", "interested", "want to know", "wondering", "how does", "what is", "can you explain"
    };
}