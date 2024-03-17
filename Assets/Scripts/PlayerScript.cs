using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] GameManagerScript gameManagerScript;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            gameManagerScript.lowerHealthPoints();
        }

        if (collision.gameObject.CompareTag("Civilian"))
        {
            rescueCivilian();
        }

        if (collision.gameObject.CompareTag("NextLevelPortal"))
        {
            StartCoroutine(gameManagerScript.loadNextLevel(3.0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            gameManagerScript.lowerHealthPoints();
        }

        if (collision.CompareTag("Civilian"))
        {
            rescueCivilian();
        }

        if (collision.CompareTag("NextLevelPortal"))
        {
            StartCoroutine(gameManagerScript.loadNextLevel(3.0f));
        }

    }

    private void rescueCivilian()
    {
        //Animate player

        gameManagerScript.increaseRescuedCivilianCount();
    }

    public void killPlayer()
    {
        //death animation

        //stop movement

    }

}
