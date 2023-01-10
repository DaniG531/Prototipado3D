using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnMyEvent : UnityEvent<int>{}

public class EventTest : MonoBehaviour
{
    OnMyEvent m_MyEvent = null;

    void Start()
    {
        if (m_MyEvent == null)
            m_MyEvent = new OnMyEvent();

        m_MyEvent.AddListener(Ping);
        m_MyEvent.AddListener(Ping1);
        m_MyEvent.AddListener(Ping2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            m_MyEvent.Invoke(15);

    }

    void Ping (int i)
    {
        Debug.Log(string.Format("Ping {0}", i));
    }
    void Ping1(int i)
    {
        Debug.Log(string.Format("Ping1 {0}", i));
    }
    void Ping2(int i)
    {
        Debug.Log(string.Format("Ping2 {0}", i));
    }
}
