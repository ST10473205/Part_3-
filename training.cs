using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace demo
{
    public class training
    {
        private ArrayList reply = new ArrayList();
        private ArrayList ignore = new ArrayList();

        // ================= RECEIVE DATA FROM MAIN =================
        public void SetData(ArrayList r, ArrayList i)
        {
            reply = r;
            ignore = i;
        }

        // ================= TRAIN METHOD (ACCEPTS FIRST ARGUMENT) =================
        // first argument = training input source (reply list or dataset)
        public void Train(ArrayList trainingInput)
        {
            if (trainingInput == null || trainingInput.Count == 0)
                return;

            // You can process or "prepare knowledge base" here
            string file = "trained_data.txt";

            if (!File.Exists(file))
                File.Create(file).Close();

            foreach (string item in trainingInput)
            {
                string cleaned = CleanText(item);

                if (!string.IsNullOrWhiteSpace(cleaned))
                {
                    File.AppendAllText(file, cleaned + Environment.NewLine);
                }
            }
        }

        // ================= MAIN AI METHOD =================
        public string CheckAndLearn(string userInput, string username = "user")
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return GetFallback();

            userInput = userInput.ToLower();

            List<string> words = userInput
                .Split(new[] { ' ', ',', '.', '?', '!', ';', ':' },
                StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> foundAnswers = new List<string>();

            // INTEREST HANDLING
            if (userInput.Contains("interested"))
            {
                string interests = string.Join(", ",
                    words.Where(w =>
                        w.Length > 2 &&
                        !ignore.Cast<string>().Contains(w) &&
                        w != "interested"));

                if (!string.IsNullOrWhiteSpace(interests))
                {
                    File.AppendAllText("interested_topic.txt",
                        username + " interested in: " + interests + Environment.NewLine);

                    return "Great! I will remember you're interested in " + interests;
                }

                return "Please tell me what you're interested in.";
            }

            // KEYWORD SEARCH
            foreach (string w in words)
            {
                if (ignore.Cast<string>().Contains(w))
                    continue;

                foreach (string r in reply)
                {
                    if (r.ToLower().Contains(w))
                    {
                        if (!foundAnswers.Contains(r))
                            foundAnswers.Add(r);
                    }
                }
            }

            return foundAnswers.Count > 0
                ? string.Join("\n and ", foundAnswers)
                : GetFallback();
        }

        // ================= CLEAN TEXT =================
        private string CleanText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";

            text = text.ToLower();

            return new string(text
                .Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                .ToArray());
        }

        // ================= FALLBACK =================
        private string GetFallback()
        {
            string[] responses =
            {
                "Sorry, I didn't understand that.",
                "Can you rephrase your question?",
                "Try asking about cybersecurity topics.",
                "I'm still learning.",
                "I don't have an answer for that yet."
            };

            return responses[new Random().Next(responses.Length)];
        }
    }
}