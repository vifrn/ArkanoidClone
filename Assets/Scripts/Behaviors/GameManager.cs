using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private BrickSpawner spawner;

    private void Awake()
    {
        spawner = GetComponentInChildren<BrickSpawner>();
    }
    public void Start()
    {
        
    }
}
