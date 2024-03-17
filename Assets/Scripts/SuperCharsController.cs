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
    public bool addFightSequenceFour;

    public GameObject bullet;

    //ASSETS, assets looks :(


    //For calling assets animations
    public static event Action AttackAnim;
    private void Awake()
    {

        heroLocalPosition = hero.transform.localPosition;
        villainLocalPosition = villain.transform.localPosition;

        //adding sequences to a list to picking random one
        if(addFightSequenceOne)
            fightSequences.Add(HeroFightSequenceOne);
        if(addFightSequenceTwo)
            fightSequences.Add(HeroFightSequenceTwo);
        if (addFightSequenceTree)
            fightSequences.Add(HeroFightSequenceThird);
        if(addFightSequenceFour)
            fightSequences.Add(HeroFightSequenceFourth);
        //test
        MakeRandomFight();
    }

    //Instantiate projectile and spread
    public void BulletSpread()
    {
        
        AttackAnim?.Invoke();
        AudioManager.instance.PlaySFXAtPosition("Explosion", hero.transform.position);
        var bullet = Instantiate(this.bullet, hero.gameObject.transform);
        bullet.transform.parent = null;
        bullet.transform.localPosition += offset/2;
        bullet.GetComponent<ProjectileSpawner>().FireProjectile();
        
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
        isFighting = true;
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
                //delete MakeRandomFight func in .setOnComplete to stop endless fight
            });
    }
    //2nd
    public void HeroFightSequenceTwo()
    {
        isFighting = true;
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
    //3rd
    public void HeroFightSequenceThird()
    {
        isFighting = true;
        LeanTween.moveLocal(hero, (heroLocalPosition + villainLocalPosition) /2 - offset /2, fightTime).setEase(LeanTweenType.easeInElastic)
            .setOnComplete(() => {
                BulletSpread();
                LeanTween.moveLocal(hero, heroLocalPosition, fightTime).setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(() => { EndFight(); MakeRandomFight(); });
            });
        LeanTween.moveLocal(villain, (heroLocalPosition + villainLocalPosition) /2 + offset /2, fightTime).setEase(LeanTweenType.easeInElastic)
            .setOnComplete(() => {
                LeanTween.moveLocal(villain, villainLocalPosition, fightTime).setEase(LeanTweenType.easeInOutSine);
            });

    }
    //4th
    public void HeroFightSequenceFourth()
    {
        isFighting = true;
        //close each other and fight
        LeanTween.moveLocal(hero, (heroLocalPosition + villainLocalPosition) / 2 - offset / 2, fightTime).setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => {
                BulletSpread();
                //move away a litle bit
                LeanTween.moveLocal(hero, new Vector3 (hero.transform.localPosition.x, hero.transform.localPosition.y -2), fightTime/3).setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(() => {
                    //again close each other and fight
                    LeanTween.moveLocal(hero, new Vector3(hero.transform.localPosition.x, hero.transform.localPosition.y + 2), fightTime / 2)
                    .setEase(LeanTweenType.easeInElastic).setOnComplete(() =>
                    {
                        BulletSpread();
                        //return original position
                        LeanTween.moveLocal(hero, heroLocalPosition, fightTime).setEase(LeanTweenType.easeInOutSine)
                        .setOnComplete(() => { EndFight(); MakeRandomFight(); });
                    });
                });
            });

        //villain part
        LeanTween.moveLocal(villain, (heroLocalPosition + villainLocalPosition) / 2 + offset / 2, fightTime).setEase(LeanTweenType.easeInOutSine)
            .setOnComplete(() => {
                LeanTween.moveLocal(villain, new Vector3(villain.transform.localPosition.x, villain.transform.localPosition.y + 2), fightTime / 3).setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(() => {
                    LeanTween.moveLocal(villain, new Vector3(villain.transform.localPosition.x, villain.transform.localPosition.y - 2), fightTime / 2)
                    .setEase(LeanTweenType.easeInElastic).setOnComplete(() =>
                    {
                        LeanTween.moveLocal(villain, villainLocalPosition, fightTime).setEase(LeanTweenType.easeInOutSine);
                    });
                });
            });
    }

}
