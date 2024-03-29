﻿using System.Collections;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Explotion();
        }
            
    }
    public void Explotion()
    {
        ParticleSystem effect = Instantiate(projectileExplotion, gameObject.transform).GetComponent<ParticleSystem>();
        effect.Play();
        //to avoid rotation of projectiles after hit
        effect.gameObject.transform.parent = null;
        //explosion effect time is 0.5 sec
        Destroy(effect.gameObject,0.5f);
        Destroy(gameObject);
    }
    public void Explosion(float time)
    {
        //no need to show effect if projectile out of camera (probably)
        Destroy(gameObject, liteTime);
    }
}
