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

    public void HandlePlayButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Play button has been clicked.");
        SceneController.GoToMenu(MenuName.Play);
        // GameObject.FindGameObjectWithTag("TitleTheme").GetComponent<Music>().StopMusic();
    }

    public void HandleQuitButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Quit button has been clicked.");
        SceneController.GoToMenu(MenuName.Title);
        // GameObject.FindGameObjectWithTag("EndTheme").GetComponent<Music>().StopMusic();
    }

    public void HandleEndButtonOnClickEvent()
    {
        UnityEngine.Debug.Log("Quit button has been clicked.");
        Application.Quit();
    }
}
