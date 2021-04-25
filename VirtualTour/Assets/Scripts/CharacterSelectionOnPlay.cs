using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionOnPlay : MonoBehaviour
{
    private GameObject[] characterList;

    void Start()
    {
        characterList = new GameObject[transform.childCount];

        // Fill the array with models
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        // Toggle off their renderer
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }

        // Toggle which character starts
        if (RespondToButtonClicks.getCharacterSelection() == 1)
        {
            characterList[0].SetActive(true);
        }
        if (RespondToButtonClicks.getCharacterSelection() == 2)
        {
            characterList[1].SetActive(true);
        }
        if (RespondToButtonClicks.getCharacterSelection() == 3)
        {
            characterList[2].SetActive(true);
        }
        if (RespondToButtonClicks.getCharacterSelection() == 4)
        {
            characterList[3].SetActive(true);
        }
    }
}
