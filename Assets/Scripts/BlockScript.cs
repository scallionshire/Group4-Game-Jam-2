using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public PuzzleManager puzzleManager;
    public int blockId;
    public BoxCollider2D boxCollider;
    public GameObject blockPrefab;
    // Start is called before the first frame update
    void Start()
    {
        puzzleManager = GameObject.Find("PuzzleManager").GetComponent<PuzzleManager>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            puzzleManager.correctBlocks[blockId] = true;
        }
        Debug.Log(collision.gameObject.name);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            puzzleManager.correctBlocks[blockId] = false;
        }
    }
}
