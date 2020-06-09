using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject MapImg;
    // Start is called before the first frame update
    void Start()
    {
        ImportMap();
    }
    public void ImportMap()
    {
        Debug.Log(Application.persistentDataPath);
        byte[] bytes = File.ReadAllBytes("sprite.png");
        Texture2D texture = new Texture2D(4096, 4096, TextureFormat.RGBA32, false); ;
        texture.filterMode = FilterMode.Trilinear;
        texture.LoadImage(bytes);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 4096, 4096), new Vector2(0.5f, 0.0f), 1.0f);

        MapImg.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
