// SentimentDetector.cs
// This class analyses the user's message to detect their emotional tone.
// The detected sentiment is used to personalise the chatbot's response style.

class SentimentDetector
{
    // These are the three sentiments the bot can detect
    public enum Sentiment
    {
        Neutral,
        Worried,
        Frustrated,
        Curious
    }

    // This method takes the user's input and returns what sentiment it detects.
    // It checks for keywords from the ResponseBank and returns the matching sentiment.
    public static Sentiment Detect(string input)
    {
        string lower = input.ToLower();

        foreach (string word in ResponseBank.WorriedWords)
        {
            if (lower.Contains(word))
                return Sentiment.Worried;
        }

        foreach (string word in ResponseBank.FrustratedWords)
        {
            if (lower.Contains(word))
                return Sentiment.Frustrated;
        }

        foreach (string word in ResponseBank.CuriousWords)
        {
            if (lower.Contains(word))
                return Sentiment.Curious;
        }

        return Sentiment.Neutral;
    }

    // This method returns an opening phrase based on the detected sentiment.
    // It is added to the front of any response to make the bot feel empathetic.
    public static string GetSentimentPrefix(Sentiment sentiment)
    {
        switch (sentiment)
        {
            case Sentiment.Worried:
                return "I understand this can feel overwhelming. Take a breath — I'm here to help. ";
            case Sentiment.Frustrated:
                return "No worries, let me explain this more clearly. ";
            case Sentiment.Curious:
                return "Great question! I love the curiosity. ";
            default:
                return "";
        }
    }
}
