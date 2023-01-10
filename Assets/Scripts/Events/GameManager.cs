using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

//Don't pay attention
[System.Serializable]
public class OnGameStateChange : UnityEvent<GameState> { }

//Game States
//This indices MUST be the same as scene so we can check based on indices.
[System.Serializable]
public enum GameState
{
    kMAIN_MENU = 0,
    kGAME,
    kLEVEL1,
    kLEVELD
}

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public GameObject m_test;
    private Vector3 StartPos;
    public float Speed = 2;

    //Current saved state.
    [SerializeField]
    [ContextMenuItem("Change State", "_internalChangeState")]
    private GameState m_currentState;


    public GameState CurrentState
    {
        get { return m_currentState; }
    }


    //Actuall callback.
    //Don't pay attention
    private OnGameStateChange m_onGameStateChange;

    public override void Awake()
    {
        base.Awake();
        //Don't pay attention
        m_onGameStateChange = new OnGameStateChange();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_currentState = (GameState)SceneManager.GetActiveScene().buildIndex;

        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_currentState)
        {
            case GameState.kMAIN_MENU:
                MoveTestCube();
                break;

            case GameState.kGAME:
                MoveTestCube();
                break;

            
            case GameState.kLEVEL1:
                MoveTestCube();
                break;

            case GameState.kLEVELD:
                MoveTestCube();
                break;

            default:
                break;
        }

    }

    #region PUBLIC_FUNCTIONS
    public void RequestChangeState(GameState newState)
    {
        Debug.Log(string.Format("Going to State -> {0}", newState.ToString()));

        //Change state
        m_currentState = newState;

        switch (m_currentState)
        {
            case GameState.kGAME:
            case GameState.kMAIN_MENU:
            case GameState.kLEVEL1:
            case GameState.kLEVELD:
                //Change Scene
                SetStateScene(newState);
                break;


            default:
                break;
        }

        //Invoke event
        m_onGameStateChange.Invoke(newState);
    }

    public void MoveTestCube()
    {
        if (!m_test)
        {
            m_test = GameObject.Find("Test");

            if (!m_test)
            {
                //Debug.Log("No test obj in this scene");
                return;
            }
            Debug.Log("Got Test object.");
        }

        Vector3 newPosition = m_test.transform.position;
        newPosition.x = Mathf.Sin(Speed * Time.time);
        m_test.transform.position = newPosition;
    }

    public void SubscribeOnStateChange(UnityAction<GameState> listener)
    {
        m_onGameStateChange.AddListener(listener);
    }

    #endregion //PUBLIC_FUNCTIONS


    #region PRIVATE_FUNCTIONS

    private void SetStateScene(GameState newGameState)
    {
        string SceneName = SceneManager.GetActiveScene().name;
        int SceneIndx = (int)SceneManager.GetActiveScene().buildIndex;

        Debug.Log(string.Format("Changing scene to Scene {1} SceneId: {0}", SceneIndx, SceneName));

        SceneManager.LoadScene((int)newGameState);
    }

    #endregion //PRIVATE_FUNCTIONS


    /********************************************EDITOR FUNCTIONS******************************************/
#if UNITY_EDITOR

    private void _internalChangeState()
    {
        Debug.Log(string.Format("Changing state from editor to -> {0}", m_currentState.ToString()));

        RequestChangeState(m_currentState);
    }


#endif
}