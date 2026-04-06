# Cybersecurity Awareness Chatbot
### PROG6221 - Programming 2A | Part 1
### Student Name: Ulikhaya A. Mazibuko
### Student Number: ST10468748



## Description
A console-based Cybersecurity Awareness Chatbot built in C# using Visual Studio.
The chatbot educates South African citizens about online safety through 
interactive conversation. It covers topics such as password safety, 
phishing scams, safe browsing, two-factor authentication, and more.



## How to Run the Project

1. Clone or download this repository
2. Open `CybersecurityChatbot.sln` in Visual Studio
3. Make sure `greeting.wav` is in the project folder
4. In Solution Explorer, click on `greeting.wav` and set:
   - **Copy to Output Directory** // Copy Always
5. Press **F5** or click the green **Start** button to run



## Features

-  Voice greeting plays automatically when the app launches
-  ASCII art logo displayed as a title screen
-  Asks for the user's name and personalises all responses
-  Responds to cybersecurity questions including:
  - Password safety
  - Phishing scams
  - Safe browsing
  - Two-factor authentication (2FA)
  - Public Wi-Fi dangers
  - Social engineering
-  Input validation — handles empty or unrecognised input gracefully
-  Colour-coded console UI for a structured, readable interface



## Project Structure

CybersecurityChatbot/
│
├── Program.cs          // Entry point, starts the chatbot
├── ChatBot.cs          // All chatbot logic and behaviour
├── greeting.wav        // Voice greeting audio file (WAV format)
├── README.md           // Project documentation (this file)
└── .github/
└── workflows/
└── dotnet.yml			// GitHub Actions CI workflow



## GitHub Actions CI

This project uses GitHub Actions for Continuous Integration.
Every time code is pushed, the workflow automatically checks 
that the project builds successfully.

### CI Workflow Status
Build passing — see screenshot below

### Screenshot of Successful CI Run
![CI Success](https://github.com/UlikhayaMazibuko/CybersecurityChatbot/blob/master/CybersecurityChatbot/ci%20-%20screenshot.png).



## Commit History

This project contains a minimum of 6 meaningful commits:

1. `Initial commit: Set up project structure and main files`
2. `Added voice greeting WAV file and ASCII art display`
3. `Implemented personalised greeting and user name interaction`
4. `Added cybersecurity response system covering passwords, phishing and safe browsing`
5. `Implemented input validation and default response handling`
6. `Enhanced console UI with colour formatting and visual structure`



## References

Pieterse, H. 2021. The Cyber Threat Landscape in South Africa: A 10-Year Review.
*The African Journal of Information and Communication*, 28(28).
Available at: https://www.scielo.org.za/scielo.php?pid=S2077-72132021000200003
[Accessed 06 April 2026].
