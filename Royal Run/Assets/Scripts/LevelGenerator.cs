using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class LevelGenerator : MonoBehaviour
{
[SerializeField] GameObject ChunkPrefavb;
[SerializeField] int startingChunkAmount = 12;
[SerializeField] Transform chunkParent;
[SerializeField] float chunkLength = 10f;
[SerializeField] float moveSpeed = 8f;
List<GameObject> chunks = new List<GameObject>();
void Start()
    {
        SpawnStartingChunks();
    }
void Update()
    {
       MoveChunks(); 
    }

    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunkAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();
        Vector3 chunkSpownPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject newChunk = Instantiate(ChunkPrefavb, chunkSpownPos, Quaternion.identity, chunkParent);
        chunks.Add(newChunk);
    }

    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;
        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
           spawnPositionZ = chunks[chunks.Count-1].transform.position.z  + chunkLength;
        }

        return spawnPositionZ;
    }
    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {   GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (Time.deltaTime * moveSpeed));
             
             if(chunk.transform.position.z < Camera.main.transform.position.z - chunkLength)
             {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
             }
        }
    }
}
