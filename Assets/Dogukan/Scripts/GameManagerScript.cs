using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] PlayerUIScript playerUIScript;
    [SerializeField] public float healthPoints;
    [SerializeField] public float rescuedCivCount;
    [SerializeField] public PlayerScript _player;
    [SerializeField] public AudioManager _audioManager;


    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 0;
    }

   
    void FixedUpdate()
    {
        playerUIScript.updateHealthUIText(healthPoints);
        playerUIScript.updateRescuedCivUIText(rescuedCivCount);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void setHealthPoints(float hp)
    {
        healthPoints = hp;
    }
    public void increaseRescuedCivilianCount()
    {
        rescuedCivCount++;
        //PlaySound
        //AudioManager.instance.PlaySFXAtPosition("Efek2Collect_", _player.transform.position);
        //_audioManager.PlaySFXAtPosition("Efek1Hit_", _player.transform.position);
        //_audioManager.PlaySFXAtPosition("Explosion", _player.transform.position);
        AudioManager.instance.PlaySFXAtPosition("Rescued", _player.transform.position);

        Debug.Log("a civilian was rescued ");

    }



}
