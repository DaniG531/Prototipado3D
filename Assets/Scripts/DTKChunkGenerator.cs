using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKChunkGenerator : MonoBehaviour
{
    public GameObject m_chunkSpawnerPrefab;
    public GameObject m_initialChunk;
    public GameObject m_finalChunk;
    public int m_chunkCount = 10;
    public float m_chunkSize = 30;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(m_initialChunk, new Vector3(0, 0, m_chunkSize * 0), Quaternion.identity);

        for (int i = 1; i < m_chunkCount; i++)
        {
            Instantiate(m_chunkSpawnerPrefab, new Vector3(0, 0, m_chunkSize * i), Quaternion.identity);
        }

        Instantiate(m_finalChunk, new Vector3(0, 0, m_chunkSize * 0), Quaternion.identity);
    }

}
