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

        checkIngameResumeButton();

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
        SceneManager.LoadScene(1); //0 main menu, 1 level1
    }
    private void buttonResumeClicked()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    private void checkIngameResumeButton()
    {
        if (inGame == true)
        {
            buttonResume.enabled = true;
            buttonResume.gameObject.SetActive(true);
        }
        else
        {
            buttonResume.enabled = false;
            buttonResume.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
