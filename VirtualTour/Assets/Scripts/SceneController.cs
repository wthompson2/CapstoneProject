using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class SceneController 
{
    // public static void SceneSwitch()
    // {
    //     SceneManager.LoadScene(0);
     // }

     public static void nextLevel()
     {
        Debug.Log("called"); 
        SceneManager.LoadScene(getCurrentSceneIndex() + 1);
     }

    public static void Restart()
    {
        SceneManager.LoadScene(getCurrentSceneIndex());
    }

    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Title:
                SceneManager.LoadScene("TitleScene");
                break;

            case MenuName.Help:
                SceneManager.LoadScene("HelpScene");
                break;

            // case MenuName.Pause:
            //     SceneManager.LoadScene("PauseScene");
            //     break;

            case MenuName.Character:
                SceneManager.LoadScene("CharacterSelectScene");
                break;

            case MenuName.Play:
                SceneManager.LoadScene("PKIScene");
                break;
        }
    }

    public static int getCurrentSceneIndex()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        return currentSceneIndex;
    }

}
