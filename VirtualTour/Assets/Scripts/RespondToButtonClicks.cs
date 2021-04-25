using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespondToButtonClicks : MonoBehaviour
{
    private static int characterSelection = 0;

    public void HandleBackButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Back button has been clicked.");
        SceneController.GoToMenu(MenuName.Title);
    }

    public void HandleHelpButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Help button has been clicked.");
        SceneController.GoToMenu(MenuName.Help);
    }

    public void HandleCharacterButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Character button has been clicked.");
        SceneController.GoToMenu(MenuName.Character);
    }

    public void HandlePlayButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Play button has been clicked.");
        SceneController.GoToMenu(MenuName.Play);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Quit button has been clicked.");
        SceneController.GoToMenu(MenuName.Title);
    }

    // Select button clicks
    public void HandleSelect1ButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Select1 button has been clicked.");
        characterSelection = 1;
    }

    public void HandleSelect2ButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Select2 button has been clicked.");
        characterSelection = 2;
    }

    public void HandleSelect3ButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Select3 button has been clicked.");
        characterSelection = 3;
    }

    public void HandleSelect4ButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Select4 button has been clicked.");
        characterSelection = 4;
    }


    // CharacterSelection getter method
    public static int getCharacterSelection()
    {
        return characterSelection;
    }

    // public void HandleEndButtonOnClickEvent()
    // {
    //     UnityEngine.Debug.Log("Quit button has been clicked.");
    //     Application.Quit();
    // }
}
