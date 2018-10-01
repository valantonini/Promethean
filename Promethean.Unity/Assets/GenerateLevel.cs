using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Promethean.Core;
using AStar;
public class GenerateLevel : MonoBehaviour
{
    public GameObject tile;

    // Use this for initialization
    void Start()
    {

        // var xLength = tile.GetComponent<Renderer>().bounds.size.x;
        // var zLength = tile.GetComponent<Renderer>().bounds.size.z;

        // Instantiate(tile, new Vector3(0, 0, 0), new Quaternion());
        // Instantiate(tile, new Vector3(xLength * 1, 0, zLength * 1), new Quaternion());
        GenerateRandomLevel();
    }

    void GenerateRandomLevel()
    {

        var options = new Options()
        {
            RandomSeed = 534011718,// new System.Random(1).Next(),
            Border = 2
        };

        Debug.Log($"Seed:{options.RandomSeed}");

        var generator = new LevelGenerator(options);
        var level = generator.Generate();
        var renderedLevel = level.Render();
        var xLength = tile.GetComponent<Renderer>().bounds.size.x;
        var zLength = tile.GetComponent<Renderer>().bounds.size.z;

        for (var x = 0; x < renderedLevel.GetLength(0); x++)
        {
            for (var y = 0; y < renderedLevel.GetLength(1); y++)
            {
                var value = renderedLevel[x, y];
                if (value == Tile.Empty)
                {
                    continue;
                }
                else
                {
                    var currentTile = Instantiate(tile, new Vector3(xLength * x, 0, zLength * y), new Quaternion());

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
