using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCharsController : MonoBehaviour
{
    public GameObject hero;
    public GameObject villain;

    private Vector3 heroLocalPosition;
    private Vector3 villainLocalPosition;

    public float fightTime;
    public Vector3 offset;

    List<Action> fightSequences = new List<Action>();
    public bool isFighting = false;

    //for customization in every scene
    public bool addFightSequenceOne;
    public bool addFightSequenceTwo;
    public bool addFightSequenceTree;
    private void Awake()
    {
        heroLocalPosition = hero.transform.localPosition;
        villainLocalPosition = villain.transform.localPosition;

        //adding sequences to a list to picking random one
        if(addFightSequenceOne)
            fightSequences.Add(HeroFightSequenceOne);
        if(addFightSequenceTwo)
            fightSequences.Add(HeroFightSequenceTwo);
        //test
        MakeRandomFight();
    }

    //Instantiate projectile and spread
    public void BulletSpread()
    {
        Debug.Log("FİREE");
        AudioManager.instance.PlaySFXAtPosition("Explosion", hero.transform.position);
    }
    public void MakeRandomFight()
    {
        if (!isFighting)
        {
            int sequenceIndex = UnityEngine.Random.Range(0, fightSequences.Count);
            fightSequences[sequenceIndex]();
        }
        else
        {
            //we can invoke a delegate to inform objects which wanna make fight out side of class
            //, or we can make this call at end of fight to say fight is ready
            //if we did not make fight endlessly like we did in VillainFightSequences
            throw new Exception("fight is not ready");
        }


    }
    public void EndFight()
    {
        isFighting = false;
    }
    //Fight sequences
    //1st
    public void HeroFightSequenceOne()
    {
        LeanTween.moveLocal(hero, villainLocalPosition - offset, fightTime).setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => { 
                BulletSpread();
                LeanTween.moveLocal(hero, heroLocalPosition , fightTime).setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(VillainFightSequenceOne);
            });
    }
    public void VillainFightSequenceOne()
    {
        LeanTween.moveLocal(villain, heroLocalPosition + offset, fightTime).setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => {
                BulletSpread();
                LeanTween.moveLocal(villain, villainLocalPosition, fightTime).setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(() => { EndFight(); MakeRandomFight(); }); 
                //delete make random fight in .setOnComplete to stop endless fight
            });
    }
    //2nd
    public void HeroFightSequenceTwo()
    {
        LeanTween.moveLocal(hero, villainLocalPosition - offset, fightTime).setEase(LeanTweenType.easeInElastic)
            .setOnComplete(() => {
                BulletSpread();
                LeanTween.moveLocal(hero, heroLocalPosition, fightTime).setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(VillainFightSequenceTwo);
            });
    }
    public void VillainFightSequenceTwo()
    {
        LeanTween.moveLocal(villain, heroLocalPosition + offset, fightTime).setEase(LeanTweenType.easeInElastic)
            .setOnComplete(() => {
                BulletSpread();
                LeanTween.moveLocal(villain, villainLocalPosition, fightTime).setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(() => { EndFight(); MakeRandomFight(); });
            });
    }
    //3rd...
    
    
}
