using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structures : MonoBehaviour
{
    public GameObject[] structures;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void loadStructure()
    {
        GameObject test = structures[1];
        int seed = PlayerPrefs.GetInt("Seed");
        Random.seed = seed;
        Vector3 Pos = new Vector3(Random.Range(0, 100), 5, Random.Range(0, 100));
        Debug.Log("Random : " + Random.Range(0, 100));
        Instantiate(test, Pos, test.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
