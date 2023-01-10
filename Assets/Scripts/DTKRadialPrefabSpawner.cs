using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKRadialPrefabSpawner : DTKPrefabSpawner
{
    public float m_radius;
    public int m_count = 0;
    public bool m_flatSwitch = true;

    // Start is called before the first frame update
    private void Start()
    {
        if (m_spawnOnStart)
        {
            for (int i = 0; i < m_count; i++)
            {
                SpawnPrefab();
            }
        }
    }

    public override void SpawnPrefab()
    {
        int randomIdx = Random.Range(0, m_prefabList.Count);
        if (m_prefabList[randomIdx] == null)
        {
            return;
        }

        Vector3 offset = Random.insideUnitSphere * m_radius;
        if (m_flatSwitch)
        {
            offset.y = 0.0f;
        }

        GameObject spawnedObject = Instantiate(m_prefabList[randomIdx], transform.position + new Vector3(offset.x, offset.y, offset.z), transform.rotation);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "PrefabIcon", true);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, m_radius);
    }
}
