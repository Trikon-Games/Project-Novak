using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameMap : MonoBehaviour
{
    public Biome biome;
    public GameObject rect;
    public GameObject PlayerLocIcon;
    public GameObject Map;
    public GameObject player;
    private GameObject playerLocat;
    // Start is called before the first frame update
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(GenCoroutine());
    }

    IEnumerator GenCoroutine()
    {
        //Print the time of when the function is first called.


            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(5);
        loadMap();   //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }    // Update is called once per frame
    void Update()
    {
        
        playerLocat.transform.position = new Vector3(player.transform.position.x, player.transform.position.z, 99999);
    }
    public void loadMap()
    {
        playerLocat = Instantiate(PlayerLocIcon, new Vector3(0, 0, 99999), Quaternion.Euler(0, 0, 0), Map.transform) as GameObject;
        RectTransform rectran2 = playerLocat.GetComponent<RectTransform>();
        playerLocat.name = "PlayerPos";
        rectran2.sizeDelta = new Vector2(5, 5);
        Image image1 = playerLocat.GetComponent<Image>();
        image1.color = new Color32(255, 255, 255, 255);
        Debug.Log("Started Map Gen at" + Time.time);
        foreach (Biomes bio in biome.biomeList)
        {
            int x = bio.x;
            int y = bio.y;
            int w = bio.recc.Width;
            int h = bio.recc.Height;

            GameObject newLoc = Instantiate(rect, new Vector3(x, y, 99998), Quaternion.Euler(0, 0, 0), Map.transform) as GameObject;
            RectTransform rectran = newLoc.GetComponent<RectTransform>();
            Text biomeText = newLoc.GetComponentInChildren<Text>();
            rectran.sizeDelta = new Vector2(w, h);
            Image image = newLoc.GetComponent<Image>();
        }
    }
}
