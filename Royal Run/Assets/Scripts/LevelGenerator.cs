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
GameObject[] chunks = new GameObject[12];
void Start()
    {
        SpawnChunks();
    }
void Update()
    {
       MoveChunks(); 
    }

    void SpawnChunks()
    {
        for (int i = 0; i < startingChunkAmount; i++)
        {
            float spawnPositionZ = CalculateSpawnPositionZ(i);
            Vector3 chunkSpownPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
         GameObject newchunk =   Instantiate(ChunkPrefavb, chunkSpownPos, Quaternion.identity, chunkParent);
         chunks[i] = newchunk;  
        }
    }

    float CalculateSpawnPositionZ(int i)
    {
        float spawnPositionZ;
        if (i == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = transform.position.z + chunkLength * i;
        }

        return spawnPositionZ;
    }
    void MoveChunks()
    {
        for (int i = 0; i < chunks.Length; i++)
        {   
            chunks[i].transform.Translate(-transform.forward * (Time.deltaTime * moveSpeed));
            
        }
    }
}
