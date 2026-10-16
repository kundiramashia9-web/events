# CyberK – Cybersecurity Awareness Chatbot

## About the Project

CyberK is a C# WPF desktop application designed to promote cybersecurity awareness. It helps users learn about common online threats and understand how to protect their personal information and devices.

The chatbot provides predefined responses to user messages, recognises selected keywords, and allows users to explore cybersecurity topics through an interactive graphical user interface.

## Features

- **Personalised Greeting:** Welcomes users and asks for their names.
- **Cybersecurity Topics:** Provides 14 topics covering online safety.
- **Keyword Recognition:** Responds to selected cybersecurity keywords.
- **Interactive Chat:** Allows users to type messages and receive responses.
- **Chat History:** Displays previously recorded conversations.
- **Clear Chat:** Clears messages from the visible conversation.
- **Random Security Tips:** Displays useful cybersecurity advice.
- **Greeting Sound:** Attempts to play a WAV sound file when the application starts.
- **User-Friendly Interface:** Uses a navy-blue and cream-white colour scheme.

## Cybersecurity Topics

CyberK covers the following 14 topics:

1. Multi-Factor Authentication
2. Social Engineering
3. Malware
4. Ransomware
5. Public Wi-Fi
6. Privacy
7. Social Media
8. Online Scams
9. Software Updates
10. Safe Downloading
11. Email Security
12. Device Security
13. Backups
14. Identity Theft

## Technologies Used

- **C#** – Implements the chatbot's functionality and responses.
- **WPF (Windows Presentation Foundation)** – Creates the graphical user interface.
- **XAML** – Defines the layout, controls, and visual styling.
- **Visual Studio** – Used to develop and run the application.

## Getting Started

### Requirements

- Windows operating system
- Visual Studio with the .NET desktop development workload
- A compatible .NET SDK
- The CyberK project source files

### Installation

1. Clone or download this repository from GitHub.
2. Open the project solution (`.sln`) in Visual Studio.
3. Restore any required NuGet packages if prompted.
4. Build the solution.
5. Run the application by pressing **F5**.

### Greeting Sound

The application can play a greeting sound using a WAV file. If you want to use this feature, update the sound file path in the C# code to match the location of your own `greeting.wav` file.

## How to Use CyberK

1. Launch the application.
2. Enter your name when prompted.
3. Click **Find Topics** to display the cybersecurity topic buttons.
4. Select a topic to read its explanation.
5. Type a cybersecurity question or keyword into the message box and click **Send**.
6. Use **Random Tip** to display a security tip.
7. Use **Chat History** to view recorded messages.
8. Use **Clear Chat** to clear the visible conversation.

## Project Structure

The main project files include:

- `MainWindow.xaml` – Defines the chatbot interface and visual layout.
- `MainWindow.xaml.cs` – Contains the chatbot logic, topic responses, keyword recognition, and button event handlers.
- `App.xaml` – Defines application-level configuration and startup settings.
- `App.xaml.cs` – Contains the application startup code.
- `greeting.wav` – Optional greeting sound file, if included in the project.

## Learning Objectives

This project demonstrates the use of C# programming, event handling, conditional statements, collections, keyword recognition, and graphical user interface development. It also promotes awareness of common cybersecurity risks and safe online practices.

## Limitations

CyberK uses predefined responses and basic keyword recognition. It does not use artificial intelligence to understand every question, and it may not respond correctly to messages that do not match its programmed keywords.

The chat history is maintained in memory while the application is running and is not automatically saved to a permanent database or file.

## Future Improvements

Possible improvements include:

- Adding more cybersecurity topics and responses.
- Improving keyword recognition.
- Saving chat history to a file or database.
- Adding more sound effects and accessibility features.
- Improving the chatbot's ability to understand different questions.

## Author

Developed as a programming project to demonstrate C# WPF development and cybersecurity awareness.

## License

This project is intended for educational purposes. Add a suitable open-source licence if you wish to permit others to reuse or modify the code.
