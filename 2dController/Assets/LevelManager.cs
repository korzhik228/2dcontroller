using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject door; 
    private List<TileColorChanger> tiles = new List<TileColorChanger>();

    void Start()
    {
        tiles.AddRange(FindObjectsOfType<TileColorChanger>());
        TileColorChanger.OnTileColored += CheckAllTilesColored; 
    }

    private void CheckAllTilesColored(TileColorChanger tile)
    {
        bool allColored = true;
        foreach (var t in tiles)
        {
            if (!t.IsAccentColor())
            {
                allColored = false;
                break;
            }
        }

        if (allColored)
        {
            MoveDoor();
        }
    }

    private void MoveDoor()
    {
        GameObject doorObject = GameObject.FindGameObjectWithTag("Door");
        if (doorObject != null)
        {
            doorObject.transform.position = new Vector3(6.86f, 5.49f, -0.02611155f);
            Debug.Log("все окрашено, дверь открыта");
        }
    }
}