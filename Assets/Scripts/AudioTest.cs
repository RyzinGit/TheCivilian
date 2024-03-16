using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    //how to use AudioManager guide
    void Start()
    {
        //AudioManager.instance.PlaySFX("CheckPoint");
        AudioManager.instance.StartMusicAfterSecs(3);
        AudioManager.instance.PlaySFXAtPosition("Explosion", new Vector3(12,6,0));
        StartCoroutine(InTimeTestCor(5));
    }
    private IEnumerator InTimeTestCor(float time)
    {
        yield return new WaitForSeconds(time);
        AudioManager.instance.musicSource.volume = 0.2f;
        yield return new WaitForSeconds(time);
        AudioManager.instance.musicSource.Stop();
        AudioManager.instance.PlaySFX("Explosion");
        AudioManager.instance.StartMusicAfterSecs(3);
        
        
    }
}
