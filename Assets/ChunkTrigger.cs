using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    [SerializeField] MapController controller;
    [SerializeField] GameObject connectedChunk;

    void Start()
    {
        controller = FindAnyObjectByType<MapController>();
        connectedChunk = transform.parent.gameObject;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Inside Chunk");
            controller.SetCurrentChunk(connectedChunk);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Outside Chunk");

            controller.SetCurrentChunk(null);
        }
    }
}
