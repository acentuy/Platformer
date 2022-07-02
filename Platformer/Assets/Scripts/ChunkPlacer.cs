using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk[] Chunks;
    public Chunk FirstChunk;

    private List<Chunk> spawnerChunks = new List<Chunk>();
    private void Start()
    {
        spawnerChunks.Add(FirstChunk);
    }

    private void Update()
    {
        if (Player.position.z > spawnerChunks[spawnerChunks.Count - 1].End.position.z - 3) SpawnChunk();
    }
    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(Chunks[Random.Range(0, Chunks.Length)]);
        newChunk.transform.position = spawnerChunks[spawnerChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnerChunks.Add(newChunk);
    }
}
