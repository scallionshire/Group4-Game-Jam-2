using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private Tilemap tileMap;
    // Start is called before the first frame update
    void Start()
    {
        tileMap = GameObject.Find("Tilemap_Blocks").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
