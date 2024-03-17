using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI _healthCountTMP;
    [SerializeField] private TextMeshProUGUI _rescuedCivilianCountTMP;

    //option buttons
    public Button buttonSound;
    public Button buttonMainMenu;

    //skill buttons
    public Button buttonDash;
    public Button buttonHeal;
    public Button buttonJump;

    [SerializeField] MainMenuScript _mainMenuScript;
    [SerializeField] DeathMenuScript _deathMenuScript;

    bool isSoundActive;

    void Start()
    { 
        buttonSound.onClick.AddListener(() => audioButtonClicked());
        buttonMainMenu.onClick.AddListener(() => mainMenuButtonClicked());

        buttonDash.onClick.AddListener(() => buttonDashClicked());
        buttonHeal.onClick.AddListener(() => buttonHealClicked());
        buttonJump.onClick.AddListener(() => buttonJumpClicked());

        
    }


    public void updateHealthUIText(float num)
    {
        _healthCountTMP.text = num.ToString();
    }
    public void updateRescuedCivUIText(float num)
    {
        _rescuedCivilianCountTMP.text = num.ToString();
    }

    private void audioButtonClicked()
    {
        AudioManager.instance.musicSource.mute = !AudioManager.instance.musicSource.mute;
        AudioManager.instance.sfxSource.mute = !AudioManager.instance.sfxSource.mute;
    }

    private void mainMenuButtonClicked()
    {
        Debug.Log("menu");

        Time.timeScale = 0;
        _mainMenuScript.inGame = true;
        _mainMenuScript.gameObject.SetActive(true);
    }

    private void buttonDashClicked()
    {
        Debug.Log("i am faster");
    }
    private void buttonHealClicked()
    {
        Debug.Log("i healed");
    }

    private void buttonJumpClicked()
    {
        Debug.Log("i can jump higher");
    }

    public void activateDeathMenu()
    {
        _deathMenuScript.gameObject.SetActive(true);
    }


}
