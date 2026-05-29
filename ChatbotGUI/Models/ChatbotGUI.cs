using System;
using System.Collections.Generic;

namespace ChatbotGUI.Models
{
    public class Chatbot
    {
        // ---------- Memory Fields ----------
        public string UserName { get; private set; } = string.Empty;
        private string favoriteTopic = string.Empty;
        private string lastTopic = string.Empty;

        // ---------- Delegate definition (meets delegates requirement) ----------
        public delegate string ResponseDelegate(string input, string sentiment);

        // ---------- Keyword response dictionary (meets keyword recognition + random responses) ----------
        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>
        {
            {"password", new List<string>{
                "Use strong, unique passwords for each account. Avoid using personal details.",
                "A good password is at least 12 characters long and includes symbols.",
                "Consider using a password manager to keep track of your credentials securely."}},
            {"phishing", new List<string>{
                "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                "Never click on suspicious links. Hover over them to preview the URL first.",
                "Report phishing attempts to your email provider or IT department."}},
            {"privacy", new List<string>{
                "Review your social media privacy settings regularly.",
                "Limit the personal information you share online – scammers can use it against you.",
                "Enable two‑factor authentication wherever possible."}},
            {"browsing", new List<string>{
                "Always look for HTTPS in the website address before entering sensitive data.",
                "Keep your browser and plugins updated to patch security vulnerabilities.",
                "Use an ad‑blocker to reduce the risk of malicious advertisements."}},
            {"scam", new List<string>{
                "Be suspicious of offers that sound too good to be true – they usually are.",
                "Never send money or gift cards to someone you've only met online.",
                "Verify the identity of the person or company before sharing personal details."}}
        };

        // ---------- Sentiment detection ----------
        private string DetectSentiment(string input)
        {
            input = input.ToLower();
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid"))
                return "worried";
            if (input.Contains("frustrated") || input.Contains("angry") || input.Contains("annoyed"))
                return "frustrated";
            if (input.Contains("curious") || input.Contains("interested"))
                return "curious";
            if (input.Contains("happy") || input.Contains("great") || input.Contains("good"))
                return "happy";
            return "neutral";
        }

        // ---------- Delegate implementation: returns a response based on topic and sentiment ----------
        private string GenerateResponse(string topic, string sentiment)
        {
            if (keywordResponses.ContainsKey(topic))
            {
                var tips = keywordResponses[topic];
                Random rnd = new Random();
                string tip = tips[rnd.Next(tips.Count)];

                // Adjust the prefix based on sentiment (traditional switch – no C# 8+ features)
                string prefix;
                switch (sentiment)
                {
                    case "worried":
                        prefix = "I understand it can be worrying. ";
                        break;
                    case "frustrated":
                        prefix = "It's frustrating, I know. Let's work through it. ";
                        break;
                    case "curious":
                        prefix = "Great question! ";
                        break;
                    case "happy":
                        prefix = "I'm glad you're feeling positive! ";
                        break;
                    default:
                        prefix = "";
                        break;
                }

                return prefix + tip;
            }
            else
            {
                return "I didn't quite understand. Could you rephrase?";
            }
        }

        // Create a delegate instance bound to the GenerateResponse method
        private ResponseDelegate responseHandler;
        public Chatbot()
        {
            // Assign the delegate (proves delegate usage)
            responseHandler = GenerateResponse;
        }

        // ---------- Main response method with conversation flow, memory, and sentiment ----------
        public string GetResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "I didn't catch that. Could you rephrase?";

            string lowerInput = input.ToLower().Trim();
            string sentiment = DetectSentiment(lowerInput);

            // 1. Check for name introduction (memory)
            if (lowerInput.Contains("my name is"))
            {
                var parts = input.Split(new[] { "my name is" }, StringSplitOptions.None);
                if (parts.Length > 1)
                {
                    string newName = parts[1].Trim();
                    if (!string.IsNullOrWhiteSpace(newName))
                    {
                        UserName = newName;
                        return $"Nice to meet you, {UserName}! How can I assist with cybersecurity today?";
                    }
                }
            }

            // 2. Check for favourite topic (memory)
            if (lowerInput.Contains("i like") || lowerInput.Contains("interested in"))
            {
                string[] markers = { "i like ", "interested in " };
                foreach (var marker in markers)
                {
                    int index = lowerInput.IndexOf(marker);
                    if (index >= 0)
                    {
                        favoriteTopic = lowerInput.Substring(index + marker.Length).Trim();
                        return $"Great! I'll remember that you're interested in {favoriteTopic}. Feel free to ask me about it.";
                    }
                }
            }

            // 3. Follow‑up handling (conversation flow)
            if ((lowerInput.Contains("tell me more") || lowerInput.Contains("another tip") || lowerInput.Contains("explain more"))
                && !string.IsNullOrEmpty(lastTopic))
            {
                // Use the delegate to get a response for the last topic
                return responseHandler(lastTopic, sentiment);
            }

            // 4. Keyword recognition – check if any known keyword is present
            foreach (var keyword in keywordResponses.Keys)
            {
                if (lowerInput.Contains(keyword))
                {
                    lastTopic = keyword;  // update conversation flow
                    return responseHandler(keyword, sentiment);
                }
            }

            // 5. Simple wellbeing / greeting responses
            if (lowerInput.Contains("how are you"))
                return $"I'm doing well, thank you {UserName}! How can I help you with cybersecurity?";
            if (lowerInput.Contains("what can you do") || lowerInput.Contains("help"))
                return "I can discuss password safety, phishing, scams, privacy, and safe browsing. What would you like to know?";

            // 6. If nothing matched – default (error handling)
            return "I didn't quite understand that. Could you rephrase? Ask me about passwords, phishing, scams, privacy, or safe browsing.";
        }
    }
}