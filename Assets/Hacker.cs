using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

   
    string[] level1Passwords = new string[5] { "goat", "eagle", "truck", "horns", "stable" };
    string[] level2Passwords = new string[5] { "headline", "broadcast", "anchorage", "television", "satellite"};
    string[] level3Passwords = new string[5] { "confidential", "priveleged", "espionage", "geopolitical", "authentication" };
    string[][] passwords;
    string password;

    Hacker()
    {
        passwords = new string[][] { level1Passwords, level2Passwords, level3Passwords };
    }

    private string incorrectPasswordMessage = " ** Incorrect Password **";
    private string winMessage = "You win!";

    // Start is called before the first frame update
    void Start()
    {
        print("Start method executes");
        ShowMainMenu("Taidai");
    }

    // Sets the initial text to the screen to instruct user what to do
    void ShowMainMenu(string userName)
    {
        print("ShowMainMenu method executes");
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        password = null;
        Terminal.WriteLine("Welcome " + userName + ", choose your victim\n");
        Terminal.WriteLine("Press 1 for Hardberry Farm");
        Terminal.WriteLine("Press 2 for KHNW News");
        Terminal.WriteLine("Press 3 for National Security Agency\n");
        Terminal.WriteLine("Enter your selection: ");
    }

    // Handle user input
    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMainMenu("Taidai");
        } else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }else if(currentScreen == Screen.Win)
        {
            ShowMainMenu("Taidai");
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Invalid input!");
        }
    }

    void RunWinScreen()
    {
        currentScreen = Screen.Win;
        password = null;
        Terminal.ClearScreen();
        Terminal.WriteLine(winMessage);
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        if(password == null)
        {
            SetRandomPassword();
        }
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    void SetRandomPassword()
    { 
        int passwordIndex = UnityEngine.Random.Range(0, passwords[level - 1].Length);
        password = passwords[level - 1][passwordIndex];
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            RunWinScreen();
        }
        else
        {
            Terminal.WriteLine(incorrectPasswordMessage);
            Terminal.WriteLine("You may type 'menu' at any time.");
            AskForPassword();
        }
    }
}
