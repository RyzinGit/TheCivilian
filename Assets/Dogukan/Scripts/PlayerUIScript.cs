using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIScript : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _healthCountTMP;
    private TextMeshProUGUI _rescuedCivilianCountTMP;

    void Start()
    { 
        _healthCountTMP = GameObject.Find("healthCountTMP").GetComponent<TextMeshProUGUI>();
        _rescuedCivilianCountTMP = GameObject.Find("rescuedCivCountTMP").GetComponent<TextMeshProUGUI>();
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



}
