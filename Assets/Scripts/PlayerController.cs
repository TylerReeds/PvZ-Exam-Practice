using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Projectile_Behaviour ProjectilePrefab;
    public Transform LaunchOffset; 

    private Rigidbody2D rb;
    private Vector2 playerMove; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Vector2 projDirection = new Vector2(1, 0);
        GameObject proj = ObjectPool.poolInstance.GetProjectile();
        proj.transform.position = LaunchOffset.transform.position;
        proj.transform.rotation = LaunchOffset.transform.rotation;
        proj.SetActive(true);
        proj.GetComponent<Projectile_Behaviour>().SetMoveDirection(projDirection);
    }

    private void FixedUpdate()
    {
        rb.velocity = playerMove * moveSpeed;
    }
}
