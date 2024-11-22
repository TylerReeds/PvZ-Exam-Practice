using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Zombies : MonoBehaviour
{
    public float Speed = 4.5f;
    public int Health = 30;
    // Update is called once per frame
    void Update()
    {
      transform.position += transform.right * Time.deltaTime * Speed;

      if (Health <= 0)
        {
            Debug.Log("Zombie Died");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health = Health - 10; 
    }
}