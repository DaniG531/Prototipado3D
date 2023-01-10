using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    float m_currentTime = 0.0f;
    [SerializeField]
    float m_startingTime = 120.0f;

    [SerializeField]
    TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        m_currentTime = m_startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        m_currentTime -= 1 * Time.deltaTime;
        countdownText.text = m_currentTime.ToString("F2");
        
        if (m_currentTime <= 0.0)
        {
            m_currentTime = 0.0f;
            UIManager.Instance.OpenMenu(2);
        }
    }

}
