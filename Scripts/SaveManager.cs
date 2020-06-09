using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public string savname;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void loadSave()
    {

    }
    public void createSave(string name, int seed)
    {
        if (name == "")
        {
            savname = "world" + Random.Range(0, 100); ;
        }
        else
        {
            savname = name;
        }
        string dir = @"Saves/" + savname;
        Directory.CreateDirectory(dir);
        using (System.IO.StreamWriter file =
          new System.IO.StreamWriter(dir + "/seed", true))
        {
            int see = PlayerPrefs.GetInt("Seed");
            file.WriteLine(see);
            Debug.Log(dir + see);
        }
        PlayerPrefs.SetString("GameSave", savname);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
