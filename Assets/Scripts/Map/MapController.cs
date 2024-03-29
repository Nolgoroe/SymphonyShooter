using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] List<GameObject> terrainChunks;
    [SerializeField] Player player;
    [SerializeField] float checkerRadius;
    [SerializeField] Vector2 noTerrainPosition;
    [SerializeField] LayerMask terrainMask;
    [SerializeField] ChunkData currentChunk;


    [SerializeField] List<ChunkData> spawnedChunks;
    [SerializeField] ChunkData latestChunkSpawned;
    [SerializeField] float maxChunkDistanceToPlayer;
    float distanceToChunk;


    void Start()
    {
        player = FindObjectOfType<Player>();

        InvokeRepeating("ChunkOptemization", 0, 1);
    }

    void Update()
    {
        ChunkChecker();
    }

    private void ChunkChecker()
    {
        if(!currentChunk)
        {
            return;
        }

        if(player.ReturnCurrentMoveDirection().x > 0/* && player.ReturnMoveDirection().y == 0*/) // right
        {
            Vector3 pointToCheck = currentChunk.ReturnDirectionToPosition(Directions.Right).pointPosition.position;
            if (!Physics2D.OverlapCircle(pointToCheck, checkerRadius, terrainMask))
            {
                noTerrainPosition = pointToCheck;

                SpawnChunk();
            }
        }
        if(player.ReturnCurrentMoveDirection().x < 0 /*&& player.ReturnMoveDirection().y == 0*/) // left
        {
            Vector3 pointToCheck = currentChunk.ReturnDirectionToPosition(Directions.Left).pointPosition.position;
            if (!Physics2D.OverlapCircle(pointToCheck, checkerRadius, terrainMask))
            {
                noTerrainPosition = pointToCheck;

                SpawnChunk();
            }
        }
        if(/*player.ReturnMoveDirection().x == 0 &&*/ player.ReturnCurrentMoveDirection().y > 0) // up
        {
            Vector3 pointToCheck = currentChunk.ReturnDirectionToPosition(Directions.Up).pointPosition.position;
            if (!Physics2D.OverlapCircle(pointToCheck, checkerRadius, terrainMask))
            {
                noTerrainPosition = pointToCheck;

                SpawnChunk();
            }
        }
        if(/*player.ReturnMoveDirection().x == 0 &&*/ player.ReturnCurrentMoveDirection().y < 0) // down
        {
            Vector3 pointToCheck = currentChunk.ReturnDirectionToPosition(Directions.Down).pointPosition.position;
            if (!Physics2D.OverlapCircle(pointToCheck, checkerRadius, terrainMask))
            {
                noTerrainPosition = pointToCheck;

                SpawnChunk();
            }
        }
        if(player.ReturnCurrentMoveDirection().x > 0 && player.ReturnCurrentMoveDirection().y > 0) // right Up
        {
            Vector3 pointToCheck = currentChunk.ReturnDirectionToPosition(Directions.RightUp).pointPosition.position;
            if (!Physics2D.OverlapCircle(pointToCheck, checkerRadius, terrainMask))
            {
                noTerrainPosition = pointToCheck;

                SpawnChunk();
            }
        }
        if(player.ReturnCurrentMoveDirection().x > 0 && player.ReturnCurrentMoveDirection().y < 0) // right Down
        {
            Vector3 pointToCheck = currentChunk.ReturnDirectionToPosition(Directions.RightDown).pointPosition.position;
            if (!Physics2D.OverlapCircle(pointToCheck, checkerRadius, terrainMask))
            {
                noTerrainPosition = pointToCheck;

                SpawnChunk();
            }
        }
        if(player.ReturnCurrentMoveDirection().x < 0 && player.ReturnCurrentMoveDirection().y > 0) // left up
        {
            Vector3 pointToCheck = currentChunk.ReturnDirectionToPosition(Directions.LeftUp).pointPosition.position;
            if (!Physics2D.OverlapCircle(pointToCheck, checkerRadius, terrainMask))
            {
                noTerrainPosition = pointToCheck;

                SpawnChunk();
            }
        }
        if(player.ReturnCurrentMoveDirection().x < 0 && player.ReturnCurrentMoveDirection().y < 0) // left down
        {
            Vector3 pointToCheck = currentChunk.ReturnDirectionToPosition(Directions.LeftDown).pointPosition.position;
            if (!Physics2D.OverlapCircle(pointToCheck, checkerRadius, terrainMask))
            {
                noTerrainPosition = pointToCheck;

                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        int random = Random.Range(0, terrainChunks.Count);
        GameObject go = Instantiate(terrainChunks[random], noTerrainPosition, Quaternion.identity);

        ChunkData data;
        go.TryGetComponent<ChunkData>(out data);

        if(data)
        {
            latestChunkSpawned = data;
            spawnedChunks.Add(data);
        }
    }

    private void ChunkOptemization()
    {
        foreach (ChunkData chunk in spawnedChunks)
        {
            distanceToChunk = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (distanceToChunk > maxChunkDistanceToPlayer)
            {
                chunk.gameObject.SetActive(false);
            }
            else
            {
                chunk.gameObject.SetActive(true);
            }
        }
    }
    public void SetCurrentChunk(GameObject chunk)
    {
        if (chunk == null)
        {
            currentChunk = null;
            return;
        }

        chunk.TryGetComponent<ChunkData>(out currentChunk);
    }
    public GameObject ReturnCurrentChunk()
    {
        return currentChunk.gameObject;
    }
}
