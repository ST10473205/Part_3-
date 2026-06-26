using System.Collections.Generic;

namespace demo
{
    public class Quiz_Question_Load
    {
        public void autoLoadQuiz(ref List<Question_in_quiz> questions)
        {
            questions = new List<Question_in_quiz>()
            {
                new Question_in_quiz
                {
                    Text = "What phishing  involves? =)",
                    correctAnswer = "Tricking users to steal sensitive data",
                    wrongAnswer = new List<string>
                    {
                        "System backup process",
                        "Secure login method",
                        "Password encryption tips"
                    }
                },

                new Question_in_quiz
                {
                    Text = "What is a definition of a strong password?",
                    correctAnswer = "A unique and hard-to-guess password",
                    wrongAnswer = new List<string>
                    {
                        "Using your name",
                        "Short simple words",
                        "Reusing old passwords"
                    }
                },

                new Question_in_quiz
                {
                    Text = "Which behavior is considered safe browsing?",
                    correctAnswer = "Using verified and trusted websites",
                    wrongAnswer = new List<string>
                    {
                        "Clicking random links",
                        "Opening unknown sites",
                        "Enabling all pop-ups"
                    }
                },

                new Question_in_quiz
                {
                    Text = "What is a common sign of phishing emails?",
                    correctAnswer = "Messages with urgency or suspicious links",
                    wrongAnswer = new List<string>
                    {
                        "Well-written content",
                        "Known sender address",
                        "Having an unsubscribe option"
                    }
                },

                new Question_in_quiz
                {
                    Text = "Which password is considered strongest?",
                    correctAnswer = "A complex mix like P@ssW0rd!#987",
                    wrongAnswer = new List<string>
                    {
                        "password123",
                        "qwerty2024",
                        "123456789"
                    }
                },

                new Question_in_quiz
                {
                    Text = "How often should passwords generally be updated?",
                    correctAnswer = "Every few months (3–6 months)",
                    wrongAnswer = new List<string>
                    {
                        "Once a year",
                        "Never",
                        "Only after hacking"
                    }
                },

                new Question_in_quiz
                {
                    Text = "Why is reusing passwords risky?",
                    correctAnswer = "One breach can compromise multiple accounts",
                    wrongAnswer = new List<string>
                    {
                        "It slows typing",
                        "It breaks websites",
                        "It has no real effect"
                    }
                },

                new Question_in_quiz
                {
                    Text = "Which indicates an unsafe website?",
                    correctAnswer = "Pop-ups and suspicious spelling errors",
                    wrongAnswer = new List<string>
                    {
                        "HTTPS security",
                        "Fast loading speed",
                        "No advertisements"
                    }
                },

                new Question_in_quiz
                {
                    Text = "What is the safest approach on public Wi-Fi?",
                    correctAnswer = "Avoid sensitive actions or use a VPN",
                    wrongAnswer = new List<string>
                    {
                        "Do online banking freely",
                        "Share files openly",
                        "Shop without protection"
                    }
                },

                new Question_in_quiz
                {
                    Text = "What should you do when a site is flagged as unsafe?",
                    correctAnswer = "Leave the site immediately",
                    wrongAnswer = new List<string>
                    {
                        "Ignore the warning",
                        "Refresh the page",
                        "Continue anyway"
                    }
                }
            };
        }
    }
}