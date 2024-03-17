using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenuScript : MonoBehaviour
{
    //main menu buttons
    public Button buttonMainMenu;
    public Button buttonQuit;
    public Button buttonRestartLevel;

    // Start is called before the first frame update
    void Start()
    {

        //Death music

        buttonMainMenu.onClick.AddListener(() => buttonMainMenuClicked());
        buttonQuit.onClick.AddListener(() => buttonQuitClicked());
        buttonRestartLevel.onClick.AddListener(() => buttonRestartLevelClicked());


    }

    private void buttonQuitClicked()
    {
        Application.Quit();
    }

    private void buttonMainMenuClicked()
    {
        SceneManager.LoadScene(0); 
    }
    private void buttonRestartLevelClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
