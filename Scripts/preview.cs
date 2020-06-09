using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class preview : MonoBehaviour
{
    public Text count;
    public Text seedT;
    public GenerateBiomes t;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(t.biomes.Count);
        int seed = PlayerPrefs.GetInt("Seed");
        seedT.text = seed.ToString();
        count.text = t.countb.ToString();
    }
}
