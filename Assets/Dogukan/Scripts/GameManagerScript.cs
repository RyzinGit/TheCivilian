using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] PlayerUIScript playerUIScript;
    [SerializeField] private float healthPoints;
    [SerializeField] private float rescuedCivCount;



    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //setHealthPoints(Time.deltaTime);
        playerUIScript.updateHealthUIText(healthPoints);
        playerUIScript.updateRescuedCivUIText(rescuedCivCount);
    }

    public void setHealthPoints(float hp)
    {
        healthPoints = hp;
    }

}
