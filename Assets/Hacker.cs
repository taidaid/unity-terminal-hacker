using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
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
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome " + userName + ", choose your victim\n");
        Terminal.WriteLine("Press 1 for Hardberry Farm");
        Terminal.WriteLine("Press 2 for KHNW News");
        Terminal.WriteLine("Press 3 for National Security Agency\n");
        Terminal.WriteLine("Enter your selection: ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
