using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public static ZombieSpawner instance; // Singleton Design Pattern
    public GameObject zombiePrefab;
    public float spawnTime = 2.0f;

    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;
    public Transform Spawn4;
    public Transform Spawn5;


    // Start is called before the first frame update
    void Start()
    {
        if (instance != this && instance != null)
        {
            instance = this;
        }
        StartCoroutine("SpawnZombies");
    }

    public void spawnZombie()
    {
        GameObject z = Instantiate(zombiePrefab) as GameObject;
        int chance = Random.Range(0, 5);
        Debug.Log(chance);
        spawnTime -= 0.05f;
        if (spawnTime <= 0.3f)
        {
            spawnTime = 0.3f;
        }
        Debug.Log(spawnTime);

        if (chance == 0)
        {
            z.transform.position = Spawn1.transform.position;
        }
        else if (chance == 1)
        {
            z.transform.position = Spawn2.transform.position;
        }
        else if (chance == 2)
        {
            z.transform.position = Spawn3.transform.position;
        }
        else if (chance == 3)
        {
            z.transform.position = Spawn4.transform.position;
        }
        else if (chance == 4)
        {
            z.transform.position = Spawn5.transform.position;
        }
    }

    IEnumerator SpawnZombies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnZombie();
        }
    }
}
