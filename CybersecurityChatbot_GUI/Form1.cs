
// This is the main window of the Cybersecurity Awareness Chatbot GUI.
// It handles all user interaction, displays the conversation,
// plays the voice greeting, and coordinates with the ChatBot class.

using System;
using System.Drawing;
using System.Media;
using System.IO;
using System.Windows.Forms;

namespace CybersecurityChatbot_GUI
{
    public partial class Form1 : Form
    {
        private ChatBot bot = new ChatBot();

        private bool nameEntered = false;

        public Form1()
        {
            InitializeComponent();
            SetupFormAppearance();
            PlayVoiceGreeting();
            DisplayWelcome();
        }

        private void SetupFormAppearance()
        {
            this.Text = "Cybersecurity Awareness Bot";
            this.BackColor = Color.FromArgb(15, 20, 40);
            this.Size = new Size(800, 600);

            rtbChatDisplay.BackColor = Color.FromArgb(10, 15, 30);
            rtbChatDisplay.ForeColor = Color.White;
            rtbChatDisplay.Font = new Font("Consolas", 10);
            rtbChatDisplay.ReadOnly = true;
            rtbChatDisplay.BorderStyle = BorderStyle.None;

            txtUserInput.BackColor = Color.FromArgb(30, 40, 70);
            txtUserInput.ForeColor = Color.White;
            txtUserInput.Font = new Font("Consolas", 10);
            txtUserInput.BorderStyle = BorderStyle.FixedSingle;

            btnSend.BackColor = Color.FromArgb(0, 180, 180);
            btnSend.ForeColor = Color.White;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Arial", 10, FontStyle.Bold);
            btnSend.Text = "Send";

            lblTitle.Text = "[ CYBERSECURITY AWARENESS BOT ]";
            lblTitle.ForeColor = Color.Cyan;
            lblTitle.Font = new Font("Consolas", 11, FontStyle.Bold);
            lblTitle.BackColor = Color.FromArgb(0, 10, 30);
        }

        private void PlayVoiceGreeting()
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
                AppendMessage("System", $"[Audio note: {ex.Message}]", Color.Yellow);
            }
        }

        private void DisplayWelcome()
        {
            AppendMessage("Bot", "Welcome to the Cybersecurity Awareness Bot!", Color.Cyan);
            AppendMessage("Bot", "I am here to help you stay safe online.", Color.Cyan);
            AppendMessage("Bot", "Before we begin, what is your name?", Color.Cyan);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ProcessInput();
        }

        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ProcessInput();
            }
        }

        // The main method that handles all user input
        private void ProcessInput()
        {
            string input = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
                return;

            AppendMessage(nameEntered ? bot.UserName : "You", input, Color.White);

            txtUserInput.Clear();

            if (!nameEntered)
            {
                bot.UserName = input;
                nameEntered = true;
                AppendMessage("Bot", $"Hello, {bot.UserName}! Great to meet you.", Color.Cyan);
                AppendMessage("Bot", "You can ask me about passwords, phishing, scams, privacy, and much more.", Color.Cyan);
                AppendMessage("Bot", "Type 'what can I ask' to see all available topics.", Color.Cyan);
                return;
            }

            string response = bot.GetResponse(input);
            AppendMessage("Bot", response, Color.FromArgb(0, 220, 180));

            if (input.ToLower() == "exit" || input.ToLower() == "bye" || input.ToLower() == "quit")
            {
                txtUserInput.Enabled = false;
                btnSend.Enabled = false;
            }
        }

        private void AppendMessage(string sender, string message, Color colour)
        {
            rtbChatDisplay.SelectionStart = rtbChatDisplay.TextLength;
            rtbChatDisplay.SelectionLength = 0;

            rtbChatDisplay.SelectionColor = Color.Gray;
            rtbChatDisplay.AppendText($"\n{sender}:\n");

            rtbChatDisplay.SelectionColor = colour;
            rtbChatDisplay.AppendText($"{message}\n");

            rtbChatDisplay.SelectionColor = Color.FromArgb(40, 40, 60);
            rtbChatDisplay.AppendText("──────────────────────────────────────\n");

            rtbChatDisplay.ScrollToCaret();
        }
    }
}