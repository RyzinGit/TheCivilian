using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _healthCountTMP;
    private TextMeshProUGUI _rescuedCivilianCountTMP;

    //option buttons
    public Button buttonSound;
    public Button buttonMainMenu;

    //skill buttons
    public Button buttonDash;
    public Button buttonHeal;
    public Button buttonJump;

    [SerializeField] MainMenuScript _mainMenuScript;
    [SerializeField] DeathMenuScript _deathMenuScript;

    [SerializeField] AudioManager _audioManager;

    bool isSoundActive;

    void Start()
    { 
        _healthCountTMP = GameObject.Find("healthCountTMP").GetComponent<TextMeshProUGUI>();
        _rescuedCivilianCountTMP = GameObject.Find("rescuedCivCountTMP").GetComponent<TextMeshProUGUI>();

        buttonSound.onClick.AddListener(() => audioButtonClicked());
        buttonMainMenu.onClick.AddListener(() => mainMenuButtonClicked());

        buttonDash.onClick.AddListener(() => buttonDashClicked());
        buttonHeal.onClick.AddListener(() => buttonHealClicked());
        buttonJump.onClick.AddListener(() => buttonJumpClicked());

        //_mainMenuScript = GameObject.Find("MainMenuCanvas").GetComponent<MainMenuScript>();

        //_audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        //if(_audioManager = GameObject.Find("AudioManagerTest").GetComponent<AudioManager>())
        //{
        //    Debug.Log("bulundu " + _audioManager);
        //}
    }


    // Update is called once per frame
    void Update()
    {
        //updateHealthUIBox(1);
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
        Debug.Log("audio button clicked");

        //This may cause crash in build game?
        //isSoundActive = _audioManager.gameObject.activeSelf;
        //if (isSoundActive)
        //{
        //    _audioManager.gameObject.SetActive(!isSoundActive);
        //}
        //else
        //{
        //    _audioManager.gameObject.SetActive(!isSoundActive);
        //    _audioManager.StartMusicAfterSecs(0);
        //}

        _audioManager.musicSource.mute = !_audioManager.musicSource.mute;
        _audioManager.sfxSource.mute = !_audioManager.sfxSource.mute;

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
