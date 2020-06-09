using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
   public player ply = new player();
    public GameObject health;
    public GameObject stamina;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float h = ply.Health;

        health.transform.localScale = new Vector3(h,1,1);
        float s = ply.Stamina;
 
        stamina.transform.localScale = new Vector3(1, 1, 1);
    }
}
