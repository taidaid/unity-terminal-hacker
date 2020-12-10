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

    private string[] level1Passwords = new string[] { "goat", "eagle", "truck", "horns", "stable" };
    private string[] level2Passwords = new string[] { "headline", "broadcast", "anchorage", "television", "satellite"};
    private string[] level3Passwords = new string[] { "confidential", "priveleged", "espionage", "geopolitical", "authentication" };

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
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
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
        Terminal.WriteLine("Please enter your password");
    }

    void CheckPassword(string input)
    {
        if(level == 1)
        {
            if(Array.Exists(level1Passwords, el => el == input))
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
            if(Array.Exists(level2Passwords, el => el == input))
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
            if(Array.Exists(level3Passwords, el => el == input))
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
