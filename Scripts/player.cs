using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public GameObject playerPref;
    public Vector3 Location;
    public string playerLocation;
    public float Health { get; set; }
    public float Stamina { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(addHealth());
    }

    // Update is called once per frame
    void Update()
    {
        Location = playerPref.transform.position;
        string x = playerPref.transform.position.x.ToString();
        string y = playerPref.transform.position.y.ToString();
        string z = playerPref.transform.position.z.ToString();
        playerLocation = x + ", " + y + ", " + z;
    }
    IEnumerator addHealth()
    {
        while (true)
        { // loops forever...
            if (Health < 1f)
            { // if health < 100...
                Health += .05f; // increase health and wait the specified time
                yield return new WaitForSeconds(1);
            }
            else
            { // if health >= 100, just yield 
                yield return null;
            }
        }
    }
}
