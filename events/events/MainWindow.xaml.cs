

using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace events
{
    public partial class MainWindow : Window
    {
        private string userName = string.Empty;
        private bool awaitingName = true;
        private readonly Random random = new Random();
        private SoundPlayer? greetingPlayer;

        private readonly List<string> chatHistory = new List<string>();

        private readonly Dictionary<string, string> answers =
            new Dictionary<string, string>
            {
                {
                    "Multi-Factor Authentication",
                    "Multi-Factor Authentication (MFA) adds an extra layer of security by requiring two or more forms of verification before accessing an account."
                },
                {
                    "Social Engineering",
                    "Social engineering involves tricking people into revealing confidential information. Be careful of suspicious messages and unexpected requests."
                },
                {
                    "Malware",
                    "Malware is harmful software designed to damage devices, steal information, or gain unauthorised access. Use trusted security software and avoid suspicious downloads."
                },
                {
                    "Ransomware",
                    "Ransomware is malware that locks or encrypts files and demands payment. Keep backups and avoid opening suspicious attachments."
                },
                {
                    "Public Wi-Fi",
                    "Public Wi-Fi can be risky. Avoid sensitive transactions on unsecured networks and use trusted websites and secure connections."
                },
                {
                    "Privacy",
                    "Protect your privacy by limiting the personal information you share online and reviewing the privacy settings on your accounts."
                },
                {
                    "Social Media",
                    "Use strong privacy settings on social media. Think carefully before posting personal information, your location, or private photos."
                },
                {
                    "Online Scams",
                    "Online scams attempt to trick people into giving away money or information. Verify unexpected offers and never rush into clicking suspicious links."
                },
                {
                    "Software Updates",
                    "Software updates fix security weaknesses and improve performance. Install updates from official sources as soon as practical."
                },
                {
                    "Safe Downloading",
                    "Download files and applications only from trusted official websites or app stores. Avoid unknown links and suspicious attachments."
                },
                {
                    "Email Security",
                    "Check the sender's address, be cautious of unexpected attachments, and never share passwords through email."
                },
                {
                    "Device Security",
                    "Protect your devices with a strong passcode, security updates, trusted security software, and automatic screen locking."
                },
                {
                    "Backups",
                    "Backups are copies of important files. Keep backups in a secure separate location and check that you can restore your files."
                },
                {
                    "Identity Theft",
                    "Identity theft happens when someone uses your personal information without permission. Protect sensitive details and report suspicious account activity."
                }
            };

        private readonly string[] randomTips =
        {
            "Use a unique password for every important account.",
            "Never share your passwords or verification codes.",
            "Think before clicking links in unexpected messages.",
            "Keep your device and applications updated.",
            "Enable multi-factor authentication where possible.",
            "Back up your important files regularly.",
            "Check website addresses before entering personal information.",
            "Only download applications from trusted sources."
        };

        public MainWindow()
        {
            InitializeComponent();

            CreateTopicButtons();

            AddBotMessage(
                "Welcome to CyberK! What is your name?");

            PlayGreetingSound();
        }

        // Creates the 14 cybersecurity topic buttons.
        private void CreateTopicButtons()
        {
            TopicsPanel.Children.Clear();

            foreach (string topic in answers.Keys)
            {
                Button topicButton = new Button
                {
                    Content = topic,
                    Tag = topic,
                    HorizontalContentAlignment = HorizontalAlignment.Left
                };

                topicButton.Click += TopicButton_Click;

                TopicsPanel.Children.Add(topicButton);
            }
        }

        // Shows or hides the topic buttons.
        private void FindTopicsButton_Click(
            object sender, RoutedEventArgs e)
        {
            TopicsPanel.Visibility =
                TopicsPanel.Visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }

        // Plays the greeting WAV file.
        private void PlayGreetingSound()
        {
            string soundPath =
                @"C:\Users\Student\OneDrive - ADvTECH Ltd\Documents\events\events\greeting.wav";

            try
            {
                if (File.Exists(soundPath))
                {
                    greetingPlayer = new SoundPlayer(soundPath);
                    greetingPlayer.Load();
                    greetingPlayer.Play();
                }
            }
            catch
            {
                // The chatbot can still run if the sound is unavailable.
            }
        }

        // Sends a message when the Send button is clicked.
        private void SendButton_Click(
            object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        // Allows the user to press Enter to send a message.
        private void MessageInput_KeyDown(
            object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
                e.Handled = true;
            }
        }

        // Processes the user's message.
        private void SendMessage()
        {
            string message = MessageInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            AddUserMessage(message);
            MessageInput.Clear();

            if (awaitingName)
            {
                userName = message;
                awaitingName = false;

                AddBotMessage(
                    $"Nice to meet you, {userName}! I am CyberK, your cybersecurity awareness assistant. You can click Find Topics or ask me a cybersecurity question.");

                return;
            }

            string response = GetResponse(message);

            AddBotMessage(response);
        }

        // Recognises topics and keywords in messages.
        private string GetResponse(string message)
        {
            string input = message.ToLowerInvariant();

            if (input.Contains("hello") ||
                input.Contains("hi") ||
                input.Contains("hey"))
            {
                return $"Hello {userName}! How can I help you with cybersecurity today?";
            }

            if (input.Contains("your name") ||
                input.Contains("who are you"))
            {
                return "I am CyberK, your cybersecurity awareness chatbot.";
            }

            if (input.Contains("thank"))
            {
                return $"You're welcome, {userName}! Stay safe online.";
            }

            if (input.Contains("password"))
            {
                return answers["Device Security"] +
                       "\nAlso, use strong, unique passwords and never share them.";
            }

            if (input.Contains("phishing"))
            {
                return answers["Email Security"] +
                       "\nPhishing is a scam that uses fake messages or websites to steal information.";
            }

            if (input.Contains("virus"))
            {
                return answers["Malware"];
            }

            if (input.Contains("hack"))
            {
                return "To reduce the risk of being hacked, use strong passwords, enable multi-factor authentication, update your software, and avoid suspicious links.";
            }

            foreach (KeyValuePair<string, string> topic in answers)
            {
                if (input.Contains(topic.Key.ToLowerInvariant()))
                {
                    return topic.Value;
                }
            }

            if (input.Contains("tip"))
            {
                return randomTips[random.Next(randomTips.Length)];
            }

            return $"I'm not sure about that yet, {userName}. Try asking about passwords, malware, phishing, or one of the topics under Find Topics.";
        }

        // Displays an answer when a topic button is clicked.
        private void TopicButton_Click(
            object sender, RoutedEventArgs e)
        {
            if (sender is Button button &&
                button.Tag is string topic &&
                answers.TryGetValue(topic, out string? answer))
            {
                AddUserMessage(topic);
                AddBotMessage(answer);
            }
        }

        // Displays a message from the user.
        private void AddUserMessage(string message)
        {
            string displayName = string.IsNullOrWhiteSpace(userName)
                ? "You"
                : userName;

            AddMessageToChat(
                displayName,
                message,
                "#DCE6F1",
                "#0B1F3A",
                HorizontalAlignment.Right);
        }

        // Displays a message from CyberK.
        private void AddBotMessage(string message)
        {
            AddMessageToChat(
                "CyberK",
                message,
                "#0B1F3A",
                "#FFF8E7",
                HorizontalAlignment.Left);
        }

        // Creates and displays a chat message.
        private void AddMessageToChat(
            string sender,
            string message,
            string bubbleColor,
            string textColor,
            HorizontalAlignment alignment)
        {
            StackPanel messageStack = new StackPanel
            {
                Margin = new Thickness(5, 6, 5, 6),
                HorizontalAlignment = alignment,
                MaxWidth = 520
            };

            TextBlock senderText = new TextBlock
            {
                Text = sender,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString("#0B1F3A")!),
                Margin = new Thickness(4, 0, 4, 3)
            };

            TextBlock messageText = new TextBlock
            {
                Text = message,
                Foreground = new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString(textColor)!),
                TextWrapping = TextWrapping.Wrap,
                FontSize = 14
            };

            Border bubble = new Border
            {
                Background = new SolidColorBrush(
                    (Color)ColorConverter.ConvertFromString(bubbleColor)!),
                CornerRadius = new CornerRadius(8),
                Padding = new Thickness(12),
                Child = messageText
            };

            messageStack.Children.Add(senderText);
            messageStack.Children.Add(bubble);

            ChatPanel.Children.Add(messageStack);

            chatHistory.Add($"{sender}: {message}");

            ChatScroll.ScrollToEnd();
        }

        // Clears the visible conversation.
        private void ClearButton_Click(
            object sender, RoutedEventArgs e)
        {
            ChatPanel.Children.Clear();
        }

        // Displays the saved conversation history.
        private void HistoryButton_Click(
            object sender, RoutedEventArgs e)
        {
            if (chatHistory.Count == 0)
            {
                MessageBox.Show(
                    "There is no chat history yet.",
                    "CyberK History",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            string history = string.Join(
                Environment.NewLine + Environment.NewLine,
                chatHistory);

            MessageBox.Show(
                history,
                "CyberK Chat History",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        // Displays a random cybersecurity tip.
        private void RandomTipButton_Click(
            object sender, RoutedEventArgs e)
        {
            TipText.Text = "Security tip: " +
                randomTips[random.Next(randomTips.Length)];
        }
    }
}
