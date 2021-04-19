using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespondToButtonClicks : MonoBehaviour
{
    public void HandleBackButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Back button has been clicked.");
        SceneController.GoToMenu(MenuName.Title);
;    }

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

    // public void HandleEndButtonOnClickEvent()
    // {
    //     UnityEngine.Debug.Log("Quit button has been clicked.");
    //     Application.Quit();
    // }
}
