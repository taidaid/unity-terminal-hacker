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
    int passwordIndex;

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
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Invalid input!");
        }
    }

    private void RunWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine(winMessage);
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        passwordIndex = UnityEngine.Random.Range(0, passwords[level].Length);
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter your password");
    }

    void CheckPassword(string input)
    {
        if(level == 1)
        {
            if(input == passwords[0][passwordIndex])
            {
                RunWinScreen();
            }
            else
            {
                Terminal.WriteLine(incorrectPasswordMessage);
            }
        }
        else if(level == 2)
        {
            if(input == passwords[1][passwordIndex])
            {
                RunWinScreen();
            }
            else
            {
                Terminal.WriteLine(incorrectPasswordMessage);
            }
        }
        else if(level == 3)
        {
            if(input == passwords[2][passwordIndex])
            {
                RunWinScreen();
            }
            else
            {
                Terminal.WriteLine(incorrectPasswordMessage);
            }
        }
    }
}
