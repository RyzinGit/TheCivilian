using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    //main menu buttons
    public Button buttonStart;
    public Button buttonQuit;
    public Button buttonResume;

    public bool inGame;

    // Start is called before the first frame update
    void Start()
    {

        //inGame = false;

        buttonStart.onClick.AddListener(() => buttonStartClicked());
        buttonQuit.onClick.AddListener(() => buttonQuitClicked());
        buttonResume.onClick.AddListener(() => buttonResumeClicked());


    }

    private void buttonQuitClicked()
    {
        Application.Quit();
    }

    private void buttonStartClicked()
    {
        SceneManager.LoadScene(0);
    }
    private void buttonResumeClicked()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame == true)
        {
            buttonResume.enabled = true;
        }
        else
        {
            buttonResume.enabled = false;
        }
    }
}
