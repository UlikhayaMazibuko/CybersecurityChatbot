# Cybersecurity Awareness Chatbot
### PROG6221 - Programming 2A | Part 1 & Part 2
### Student Name: Ulikhaya A. Mazibuko
### Student Number: ST10468748

## Description
A Cybersecurity Awareness Chatbot built in C# using Visual Studio.
The chatbot educates South African citizens about online safety through 
interactive conversation. Part 1 is a console application. Part 2 upgrades 
it to a full WinForms graphical user interface with advanced features.

## How to Run Part 1 (Console)
1. Clone or download this repository
2. Open `CybersecurityChatbot.sln` in Visual Studio
3. Set `CybersecurityChatbot` as the startup project
4. Make sure `greeting.wav` is in the project folder
5. In Solution Explorer, click on `greeting.wav` and set:
   - **Copy to Output Directory**
6. Press **F5** or click the green **Start** button to run

## How to Run Part 2 (GUI)
1. Open `CybersecurityChatbot.sln` in Visual Studio
2. Right-click `CybersecurityChatbot_GUI` in Solution Explorer
3. Click **Set as Startup Project**
4. Make sure `greeting.wav` is in the project folder
5. Press **F5** or click the green **Start** button to run

## Part 1 Features
- Voice greeting plays automatically when the app launches
- ASCII art logo displayed as a title screen
- Asks for the user's name and personalises all responses
- Responds to cybersecurity questions including:
  - Password safety
  - Phishing scams
  - Safe browsing
  - Two-factor authentication (2FA)
  - Public Wi-Fi dangers
  - Social engineering
- Input validation — handles empty or unrecognised input gracefully
- Colour-coded console UI for a structured, readable interface

## Part 2 Features
- Full WinForms graphical user interface with dark cybersecurity theme
- Keyword recognition using a Dictionary data structure
- Random phishing responses using a List for varied conversation
- Sentiment detection for worried, curious and frustrated tone
- Memory and recall system using a Dictionary
- Conversation flow with follow-up question handling
- Error handling for unknown or empty inputs
- Code organised across multiple classes:
  - `ChatBot.cs` — core chatbot logic
  - `ResponseBank.cs` — all responses and keyword data
  - `SentimentDetector.cs` — emotional tone detection
  - `Form1.cs` — GUI form and user interaction

## Project Structure
CybersecurityChatbot/
│
├── CybersecurityChatbot/          ← Part 1 Console Project
│   ├── Program.cs                 ← Entry point
│   ├── ChatBot.cs                 ← Chatbot logic
│   ├── greeting.wav               ← Voice greeting audio
│   └── README.md                  ← This file
│
├── CybersecurityChatbot_GUI/      ← Part 2 GUI Project
│   ├── Form1.cs                   ← Main GUI window
│   ├── Form1.Designer.cs          ← Auto-generated layout
│   ├── ChatBot.cs                 ← Updated chatbot logic
│   ├── ResponseBank.cs            ← Keywords and responses
│   └── SentimentDetector.cs      ← Sentiment detection
│
└── .github/
└── workflows/
└── dotnet.yml             ← GitHub Actions CI workflow

## GitHub Actions CI
This project uses GitHub Actions for Continuous Integration.
Every time code is pushed, the workflow automatically checks 
that the project builds successfully.

### CI Workflow Status
Build passing - successful

## Releases
| Version | Description |
|---------|-------------|
| v1.0 | Console Chatbot - Part 1 submission |
| v2.0 | GUI Chatbot - Part 2 submission |

## Commit History

### Part 1 Commits
1. `Initial commit: Set up project structure and main files`
2. `Added voice greeting WAV file and ASCII art display`
3. `Implemented personalised greeting and user name interaction`
4. `Added cybersecurity response system covering passwords, phishing and safe browsing`
5. `Implemented input validation and default response handling`
6. `Enhanced console UI with colour formatting and visual structure`

### Part 2 Commits
1. `Added WinForms GUI project with Form1 layout and controls`
2. `Added ResponseBank class with keyword dictionary and phishing response list`
3. `Added SentimentDetector class for emotional tone analysis`
4. `Updated ChatBot with GetResponse method, memory system and follow-up handling`
5. `Implemented WinForms GUI with chat display, input box and send button`
6. `Updated README with Part 2 GUI features and release notes`
