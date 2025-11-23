using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private BrickSpawner spawner;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;

    public int life { private set; get; } = 3;
    public float score { set; get; } = 0;

    private static GameManager sInstance;
    public static GameManager GetInstance() { return sInstance; }

    private float multiplier = 1;


    private void Awake()
    {
        spawner = GetComponentInChildren<BrickSpawner>();
        sInstance = this;
    }
    public void Start()
    {
        
    }

    private void Update()
    {
        if (life == 0) 
        {
            Debug.Log("Game over");
        }

        if (!spawner.HasAnyBrickLeft()) 
        {
            Debug.Log("You win!");
        }
    }

    public void ScoreBonus (float multiplier, float duration) 
    {
        
    }

    public void Score(GameObject brick) 
    {
        score += 100 * multiplier;
        scoreText.text = String.Format("{000000}", score); //000100 for example
        spawner.DoDamage(brick);
    }

    public void OutOfBounds()
    {
        life--;
        lifeText.text = String.Format("{00}", life);
    }


}
