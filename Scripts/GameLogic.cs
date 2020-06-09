using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public player ply = new player();
    public float health;
    // Start is called before the first frame update
    void Start()
    {
      
        ply.Health = .50f;
        ply.Stamina = 1;
    }

    // Update is called once per frame
    void Update()
    {

        health = ply.Health;
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
