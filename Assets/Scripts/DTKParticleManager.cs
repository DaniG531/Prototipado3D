using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTKParticleManager : MonoBehaviour
{
    public static DTKParticleManager m_instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public ParticleSystem SpawnParticle(GameObject prefab, Vector3 postition, Vector3 eulerangles, float scaleMult, bool destroyOnFinish = true, Transform parent = null)
    {
        ParticleSystem particle = Instantiate(prefab, postition, Quaternion.Euler(eulerangles), parent).GetComponent<ParticleSystem>();
        particle.transform.localScale *= scaleMult;

        if (destroyOnFinish)
        {
            Destroy(particle.gameObject, particle.main.duration);
        }

        return particle;
    }
}
