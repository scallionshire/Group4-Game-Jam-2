using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapPuzzle : MonoBehaviour
{
    public enum TileState
    {
        Empty,
        Block,
        CorrectTile,
    }

    public Tilemap tilemap;
    public TileBase blockTile;
    public TileBase correctPositionTile;

    void Start()
    {
        tilemap = GameObject.Find("Tilemap_Blocks").GetComponent<Tilemap>();
    }

    void Update()
    {
        // Check for puzzle completion
        if (IsPuzzleSolved())
        {
            // Puzzle is solved, provide feedback and handle progression
            Debug.Log("Puzzle Solved!");
        }
    }

    bool IsPuzzleSolved()
    {
        BoundsInt bounds = tilemap.cellBounds;

        // Iterate through each cell in the tilemap
        foreach (Vector3Int position in bounds.allPositionsWithin)
        {
            TileBase currentTile = tilemap.GetTile(position);
            
            if (currentTile != null) {
                Debug.Log(currentTile.name + ": " + position);
            } else {
                Debug.Log("null: " + position);
            }
            // Check if the tile is a block or correct position
            if (currentTile == blockTile || currentTile == correctPositionTile)
            {
                // Compare the current tile state with the correct state
                TileState correctState = GetCorrectState(position);

                if (GetTileState(currentTile) != correctState)
                {
                    // Puzzle is not solved, at least one tile is not in the correct state
                    return false;
                }
            }
        }

        // If the loop completes without returning false, the puzzle is solved
        return true;
    }

    TileState GetTileState(TileBase tile)
    {
        if (tile == null)
        {
            return TileState.Empty;
        }
        else if (tile == blockTile)
        {
            return TileState.Block;
        }
        else if (tile == correctPositionTile)
        {
            return TileState.CorrectTile;
        }

        return TileState.Empty; // Default to Empty if the tile is not recognized
    }

    TileState GetCorrectState(Vector3Int position)
    {
        // Implement your logic to determine the correct state based on the tile position
        // This might involve a predefined mapping or a more complex algorithm
        // Return the correct state for the given position
        return TileState.CorrectTile; // Placeholder, replace with your logic
    }
}