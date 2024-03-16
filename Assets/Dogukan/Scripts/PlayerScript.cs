using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] GameManagerScript gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    ////    Debug.Log("i touched smth");

    //    if (collision.gameObject.CompareTag("Civilian"))
    //    {
    //        Debug.Log("i touched a civilian");
    //        rescueCivilian();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("i touched smth");
        Debug.Log(collision.gameObject);

        if(collision.CompareTag("Bullet"))
        {
            gameManagerScript.lowerHealthPoints();
        }

        if (collision.CompareTag("Civilian"))
        {
            //Debug.Log("i touched a civilian");
            rescueCivilian();
        }

        if(collision.CompareTag("NextLevelPortal"))
        {
            StartCoroutine(gameManagerScript.loadNextLevel(3.0f));
        }

    }

    private void rescueCivilian()
    {
        //Debug.Log("i rescued a civilian");

        //Animate player

        gameManagerScript.increaseRescuedCivilianCount();
    }

    public void killPlayer()
    {
        //death animation

        //stop movement

    }

}
