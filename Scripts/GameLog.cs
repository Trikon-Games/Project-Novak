using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameLog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Log(object arg)
    {
        Debug.Log(arg);
        File.AppendAllText("log.txt",
                   DateTime.Now.ToString() + arg + Environment.NewLine);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
