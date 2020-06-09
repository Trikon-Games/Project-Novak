using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionMenu : MonoBehaviour
{
    public Canvas FunctionM;
    public Canvas Map;
    public Canvas Character;
    public Canvas Inventory;
    public Canvas Options;
    public bool MenusClosed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MenuProcCheck();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (FunctionM.enabled == false)
            {
                FunctionM.enabled = true;
            }
            else if (FunctionM.enabled == true)
            {
                FunctionM.enabled = false;
            }
      
        }
    }
    public void MenuProcCheck()
    {

    }

}
