using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DTKHealth : MonoBehaviour
{
    public float m_maxHealth = 10.0f;
    [HideInInspector]
    public float m_currentHealth = 10.0f;

    public UnityEvent OnHealthChangedEvent;
    public UnityEvent OnDieEvent;
    public UnityEvent OnHealEvent;
    public UnityEvent OnDamagedEvent;

    // Start is called before the first frame update

    void Start()
    {
        m_currentHealth = m_maxHealth;
    }

    // Update is called once per frame
    public void Damage(float damageAmount)
    {
        m_currentHealth -= damageAmount;
        OnHealthChanged();

        if (m_currentHealth <= 0.0f)
        {
            Kill();
        }

        if (OnDamagedEvent != null)
        {
            OnDamagedEvent.Invoke();
        }
    }

    


    public void Heal(float healAmount)
    {
        m_currentHealth += healAmount;
        OnHealthChanged();
        if (OnHealEvent != null) { OnHealEvent.Invoke(); }
    }

    public void Kill()
    {
        m_currentHealth = 0;
        OnHealthChanged();
        UIManager.Instance.OpenMenu(2);
        if (OnDieEvent != null) { OnDieEvent.Invoke(); }
    }

    public void RestoreHealth()
    {
        m_currentHealth = m_maxHealth;
        OnHealthChanged();
    }

    void OnHealthChanged()
    {
        m_currentHealth = Mathf.Clamp(m_currentHealth, 0, m_maxHealth);
        if (OnHealthChangedEvent != null) { OnHealthChangedEvent.Invoke(); }
        UIManager.Instance.UpdateHealthBar(m_currentHealth / m_maxHealth);
    }
}
