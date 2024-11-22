using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : Observer
{
    private EndGoal Goal;
    private bool GameOver; 

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(150, 150, 200, 400));

        // Display score
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Is Game Over" + GameOver);
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }
    public override void Notify(Subject subject)
    {
        if (!Goal)
            Goal = subject.GetComponent<EndGoal>();
        if (Goal)
        {
            GameOver = Goal.IsGameOver;
        }
    }
}

