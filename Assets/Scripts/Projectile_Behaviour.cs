using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Projectile_Behaviour : MonoBehaviour
{
    private Vector2 moveDirection; 
    public float Speed = 4.5f;

    private void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime * Speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Disable();
            Debug.Log("hit");
        }
    }
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
