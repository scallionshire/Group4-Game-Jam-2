using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PuzzleManager : MonoBehaviour
{
    public struct PuzzlePiece {
        public Vector3Int position;
        public bool isCorrect;
    }

    public Tilemap tilemap;
    public TileBase blockTile;
    public TileBase correctPositionTile;
    public List<bool> correctBlocks;

    void Start()
    {
        tilemap = GameObject.Find("Tilemap_Blocks").GetComponent<Tilemap>();
        correctBlocks = new List<bool>()
            {
                false,
                false,
                false,
                false,
                false,
            };
    }

    void Update()
    {
        // Check for puzzle completion
        if (IsPuzzleSolved())
        {
            // Puzzle is solved, provide feedback and handle progression
            Debug.Log("Puzzle Solved!");
            // TODO: Go back to scene and trigger unlock
        }
    }

    bool IsPuzzleSolved()
    {
        // Iterate through each cell in the tilemap
        foreach (bool block in correctBlocks)
        {
            if (!block)
            {
                // Check for the right tile here
                Debug.Log("Missing tile: ");
                return false;
            } else {
                Debug.Log("got it!");
            }
        }

        // If the loop completes without returning false, the puzzle is solved
        return true;
    }
}