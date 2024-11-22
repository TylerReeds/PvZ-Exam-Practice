using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGoal : Subject
{ 
    private UIManager uiManager;

    public bool IsGameOver
    {
        get { return GameOver; }
    }
    [SerializeField] private bool GameOver = false;

    void Awake()
    {
        uiManager = gameObject.AddComponent<UIManager>();
    }

    void OnEnable()
    {
        if (uiManager)
            Attach(uiManager);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            GameOver = true;
            NotifyObservers();
        }
    }
    private void Update()
    {
        if (GameOver == true)
        {
            Application.Quit();
        }
    }

}

