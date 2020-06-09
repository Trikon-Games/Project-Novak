﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainControllerSimple : MonoBehaviour {
    public float Seed;
    public Structures st;
    public Biome bio;
    [SerializeField]
    private GameObject terrainTilePrefab = null;
    [SerializeField]
    private Vector3 terrainSize = new Vector3(20, 1, 20);
 
  //  private float noiseScale = 3, cellSize = 1;
 
    private int radiusToRender = 10;
    [SerializeField]
    private Transform[] gameTransforms;
    [SerializeField]
    private Transform playerTransform;

    private Vector2 startOffset;
    public Dictionary<Vector2, GameObject> terrainTiles = new Dictionary<Vector2, GameObject>();
    private Vector2[] previousCenterTiles;
    private List<GameObject> previousTileObjects = new List<GameObject>();

    private void Start() {
        InitialLoad();
        int seed = PlayerPrefs.GetInt("Seed");
        Random.seed = seed;

    }

    public void InitialLoad() {
        DestroyTerrain();
        st.loadStructure();
        //choose a place on perlin noise (which loops after 256)
        startOffset = new Vector2(Random.Range(0f, 256f), Random.Range(0f, 256f));
    }
    

    private void Update() {
        //save the tile the player is on
        Vector2 playerTile = TileFromPosition(playerTransform.position);
        //save the tiles of all tracked objects in gameTransforms (including the player)
        List<Vector2> centerTiles = new List<Vector2>();
        centerTiles.Add(playerTile);
        foreach (Transform t in gameTransforms)
            centerTiles.Add(TileFromPosition(t.position));

        //if no tiles exist yet or tiles should change
        if (previousCenterTiles == null || HaveTilesChanged(centerTiles)) {
            List<GameObject> tileObjects = new List<GameObject>();
            //activate new tiles
            foreach (Vector2 tile in centerTiles) {
                bool isPlayerTile = tile == playerTile;
                int radius = isPlayerTile ? radiusToRender : 1;
                for (int i = -radius; i <= radius; i++)
                    for (int j = -radius; j <= radius; j++)
                        ActivateOrCreateTile((int)tile.x + i, (int)tile.y + j, tileObjects);
            }
            //deactivate old tiles
            foreach (GameObject g in previousTileObjects)
                if (!tileObjects.Contains(g))
                    g.SetActive(false);

            previousTileObjects = new List<GameObject>(tileObjects);
        }

        previousCenterTiles = centerTiles.ToArray();
    }

    //Helper methods below

    private void ActivateOrCreateTile(int xIndex, int yIndex, List<GameObject> tileObjects) {
      
        if (!terrainTiles.ContainsKey(new Vector2(xIndex, yIndex))) {
            tileObjects.Add(bio.CreateTile(xIndex, yIndex));
        } else {
            GameObject t = terrainTiles[new Vector2(xIndex, yIndex)];
            tileObjects.Add(t);
            if (!t.activeSelf)
                t.SetActive(true);
        }
    }

  

 
    private Vector2 TileFromPosition(Vector3 position) {
        return new Vector2(Mathf.FloorToInt(position.x / terrainSize.x + .5f), Mathf.FloorToInt(position.z / terrainSize.z + .5f));
    }

    private bool HaveTilesChanged(List<Vector2> centerTiles) {
        if (previousCenterTiles.Length != centerTiles.Count)
            return true;
        for (int i = 0; i < previousCenterTiles.Length; i++)
            if (previousCenterTiles[i] != centerTiles[i])
                return true;
        return false;
    }

    public void DestroyTerrain() {
        foreach (KeyValuePair<Vector2, GameObject> kv in terrainTiles)
            Destroy(kv.Value);
        terrainTiles.Clear();
    }



}