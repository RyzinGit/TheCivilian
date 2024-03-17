using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float power;
    private Rigidbody2D rb;
    public float liteTime;
    public GameObject projectileExplotion;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Explosion(liteTime);
    }
    public void MoveToDirection(Vector3 direction)
    {
        rb.AddForce(direction);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explotion();
    }
    public void Explotion()
    {
        //make projectile explosion effect
        Destroy(gameObject);
    }
    public void Explosion(float time)
    {
        Destroy(gameObject, liteTime);
    }
}
