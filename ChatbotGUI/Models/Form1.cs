using ChatbotGUI.Models;
using ChatbotGUI.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChatbotGUI
{
    public partial class Form1 : Form
    {
        private Chatbot bot = new Chatbot();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Display ASCII art
            lblAscii.Text = @"   _____      _   _      _                      _           
  / ____|    | | | |    | |                    | |          
 | |    _   _| |_| |__  | |_ ___ _ __ ___  ___ | |_ ___ _ __ 
 | |   | | | | __| '_ \ | __/ _ \ '_ ` _ \/ _ \| __/ _ \ '__|
 | |___| |_| | |_| | | || ||  __/ | | | | | (_) | ||  __/ |   
  \_____\__, |\__|_| |_| \__\___|_| |_| |_|\___/ \__\___|_|   
         __/ |                                               
        |___/                                                
   Awareness Bot";

            // Play voice greeting (try/catch so the app doesn't crash on VMs without audio)
            try
            {
                var voice = new VoiceService();
                voice.PlayGreeting();
            }
            catch (Exception)
            {
                AppendMessage("System", "(Voice greeting could not be played – continuing)");
            }

            // Initial bot message
            AppendMessage("Bot", "Welcome! What's your name?");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(userInput))
                return;

            AppendMessage("You", userInput);
            string reply = bot.GetResponse(userInput);
            AppendMessage("Bot", reply);

            txtInput.Clear();
            txtInput.Focus();
        }

        // Appends a timestamped message to the RichTextBox
        private void AppendMessage(string sender, string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            rtbChat.SelectionColor = (sender == "You") ? Color.Cyan : Color.LightGreen;
            rtbChat.AppendText($"[{timestamp}] {sender}: {message}\n");
            rtbChat.ScrollToCaret();
        }
    }
}