using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEntity : MonoBehaviour
{
    [Header("Desert Biome")]
    public GameObject[] mountain;
    public GameObject rock;
    public GameObject desertStorm;
    public GameObject[] grass;
    public GameObject[] tree;
    // Start is called before the first frame update
    void Start()
    {
        int seed = PlayerPrefs.GetInt("Seed");
        Random.seed = seed;
    }
    public void dustStorm(Vector3 pos)
    {
        
        Instantiate(desertStorm, pos, Quaternion.Euler(0, 0, 0));
        Debug.Log("Spawning Entity: " + desertStorm.ToString() + "@ " + pos.ToString());
      
    }
    public void Rock(Vector3 pos)
    {
       
        pos.x = pos.x + (Random.Range(5, 50));
        int rY = 90 * (Random.Range(2, 8));
        Instantiate(rock, new Vector3(pos.x, 2, pos.z), Quaternion.Euler(0, rY, 0));
    }
    public void Mountain(Vector3 pos)
    {
        if (Random.Range(0, 101) <= 6) // Rate at which Mountains will Spawn
        {



            if (pos.x >= 0)
            {
                pos.x = pos.x + (Random.Range(100, 200));
            }
            else if (pos.x < 0)
            {
                pos.x = pos.x + (Random.Range(-50, -100));
            }
            pos.x = pos.x + (Random.Range(100, 300));
            int rY = 90 * (Random.Range(2, 8));
            Instantiate(mountain[1], new Vector3(pos.x, 2, pos.z), Quaternion.Euler(0, rY, 0));
            mountain[1].name = "Mountain";
            Debug.Log("Spawning Entity: " + mountain[1].ToString() + "@ " + pos.ToString());
        }
        }
    public void Grass(Vector3 pos)
    {
        if (Random.Range(0, 101) <= 100) // Rate at which Mountains will Spawn
        {



            if (pos.x >= 0)
            {
                pos.x = pos.x + (Random.Range(0, 5));
            }
            else if (pos.x < 0)
            {
                pos.x = pos.x + (Random.Range(0, -5));
            }
            pos.x = pos.x + (Random.Range(100, 300));
            int rY = 90 * (Random.Range(2, 8));
            Instantiate(grass[1], new Vector3(pos.x, 3, pos.z), Quaternion.Euler(0, rY, 0));
            grass[1].name = "Grass";
            Debug.Log("Spawning Entity: " + mountain[1].ToString() + "@ " + pos.ToString());
        }
    }
    public void Tree(Vector3 pos)
    {
        Random.seed = Random.Range(999999, 9999999);
        if (Random.Range(0, 101) <= 100) // Rate at which 
        {
            pos.x = pos.x + (Random.Range(5, 50));
            pos.z = pos.z + (Random.Range(0, 30));

            int rY = 90 * (Random.Range(2, 8));
            int rand = Random.Range(0, 101);
            if (rand <= 50)
            {
                Instantiate(tree[1], new Vector3(pos.x, 0, pos.z), Quaternion.Euler(0, rY, 0));
                tree[1].name = "Grass";
                Debug.Log("Spawning Entity: " + tree[1].ToString() + "@ " + pos.ToString());

                Instantiate(tree[1], new Vector3(pos.x + Random.Range(6, 12), 0, pos.z + Random.Range(6, 12)), Quaternion.Euler(0, rY, 0));
                tree[1].name = "Grass";
                Debug.Log("Spawning Entity: " + tree[1].ToString() + "@ " + pos.ToString());
                
            }
            else
            {
                Instantiate(tree[0], new Vector3(pos.x, 0, pos.z), Quaternion.Euler(0, rY, 0));
                tree[1].name = "Grass";
                Debug.Log("Spawning Entity: " + tree[1].ToString() + "@ " + pos.ToString());

                Instantiate(tree[0], new Vector3(pos.x + Random.Range(6, 12), 0, pos.z + Random.Range(6, 12)), Quaternion.Euler(0, rY, 0));
                tree[1].name = "Grass";
                Debug.Log("Spawning Entity: " + tree[1].ToString() + "@ " + pos.ToString());
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
