AppGamiFy

AppGamiFy is an alpha-stage application designed to assist students in preparing for the Baccalaureate or exams in Romanian, Mathematics, or Informatics. The app offers educational content and a unique gamified learning experience, all within an intuitive and user-friendly interface.
Table of Contents

    Features
    System Requirements
    Installation
    Usage
    Security
    License
    Acknowledgments

Features

    Exam Preparation:
        Access resources and tools tailored for Baccalaureate exam preparation in Romanian, Mathematics, and Informatics.
        Take up to 10 quizzes for each specialty to test your knowledge.
        View and download comprehensive PDFs for each specialty by clicking the "Documentatie" button within the app, providing in-depth study material.

    User Accounts:
        Register and log in with secure password encryption.
        Note: The application includes terms and conditions during account creation that are primarily for illustrative purposes and may not be fully defined.

    Gamified Learning:
        Earn points for completing quizzes and other activities.
        View a weekly diagram displaying the points you've earned.
        Achieve milestones and unlock achievements by meeting specific requirements.
        Compete on leaderboards specific to each specialty: Romanian, Mathematics, and Informatics.
        Access a secret game mode intended as a premium feature, allowing users to learn through interactive gameplay.

    Additional Resources:
        Access curated YouTube videos for each specialty directly through the application.

    User-Friendly Interface:
        Navigate the application effortlessly with an intuitive and responsive design.

System Requirements

    Operating System: Windows 7 or 10.
    .NET Framework: Ensure the appropriate version is installed.
    Storage: At least 512 MB of available space.
    Memory: 256 MB of RAM.
    Processor: Dual Core CPU.

Installation

    Clone the Repository:

    git clone https://github.com/alexbelokamensky/Hackathon_Project.git
    cd Hackathon_Project

    Open the Solution:

    Open the AppGamiFy.sln file in Visual Studio.

    Build and Run:

    Press F5 in Visual Studio to build and run the application.

Usage

    Registration and Login:
        Register a new account or log in with existing credentials to access the app's features.

    Exam Preparation:
        Navigate through the app to find resources and tools tailored for Baccalaureate exam preparation in Romanian, Mathematics, and Informatics.
        Take quizzes to assess your knowledge in each specialty.
        Access and download comprehensive PDFs for each specialty by clicking the "Documentatie" button within the app, providing in-depth study material.

    Gamified Features:
        Earn points by completing quizzes and other activities.
        View your weekly progress through the points diagram.
        Check the leaderboards to see how you rank against others in each specialty.
        Access educational YouTube videos directly through the app.

    Secret Game Mode:

        To access the secret game mode, click on the 'Activate' button within the app and enter the activation code.

        The code is generated using an SHA-256 uppercase hash of the following format:

        {username.ToLower() + "premium?forever"}

        Replace username with your actual username in lowercase, concatenate it with the string "premium?forever", and then compute the SHA-256 uppercase hash of the resulting string. Convert the hash to uppercase to obtain the activation code.

        The secret game mode is inspired by the [Fighting Game](https://github.com/AkoForU/Fighting-Game) project and features a makeup exam where you need to answer questions quickly. For each correct answer within 10 seconds, you deal -10 damage to the opponent. For each incorrect answer, the main character receives -10 damage. If the main character's health reaches 0, a losing animation is displayed; otherwise, a winning animation is shown. You can view these animations in the project itself.

Security

The application uses SHA-256 encryption to secure user passwords and generate activation codes for the secret game mode, ensuring secure access to premium features.
License

This project is licensed under the MIT License.
Acknowledgments

Special thanks to the development team:

    AkoForU: Project Leadership and Code Development
    SanaBel: Code Development
    Leonid_XAM_666: Design
