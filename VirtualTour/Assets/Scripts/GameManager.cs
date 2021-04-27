using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public bool player1;

    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        if (player1)
        {
            player = Instantiate(player1Prefab);
        }
        else
        {
            player = Instantiate(player2Prefab);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
