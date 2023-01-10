using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DTK_AUDIOSOURCE
{
    kmusic,
    ksfx,
    kambient,
    kui

}

public class AudioManager : MonoBehaviour
{
    public static AudioManager m_instance;
    public List<AudioSource> m_audioSource;
    public float m_masterVolume = 1.0f;
    public List<float> m_volume;
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
    public void PlayerClip(DTK_AUDIOSOURCE source, AudioClip clip, float volume)
    {
        m_audioSource[(int)source].PlayOneShot(clip, volume * m_volume[(int)source] * m_masterVolume);

    }


}