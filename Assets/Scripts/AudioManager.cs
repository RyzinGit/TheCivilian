using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public List<Audio> musicAudios, sfxAudios;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        //primitive singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic(string name)
    {
        foreach (var audio in musicAudios)
        {
            if (audio.name == name)
            {
                musicSource.clip = audio.clip;
                musicSource.Play();
                return;
            }             
        }
    }
    public void PlaySFX(string name)
    {
        foreach(var audio in sfxAudios)
        {
            if(audio.name == name)
            {            
                sfxSource.PlayOneShot(audio.clip);
                return;
            }
        }
    }
    public void PlaySFXAtPosition(string name, Vector3 position)
    {
        foreach (var audio in sfxAudios)
        {
            if (audio.name == name)
            {   
                AudioSource.PlayClipAtPoint(audio.clip, position);
                return;
            }
        }
    }
    //music can stop when scene changing for hear sfx clearly, so we can start music after sfx finished
    //object which call coroutine, can be destroyed when changing scene or something
    //because of that coroutine have to start on this object, or other DontDestroyOnLoad object
    private IEnumerator StartMusicAfterSecsCor(float time)
    {
        yield return new WaitForSeconds(time);
        musicSource.Play();
    }
    public void StartMusicAfterSecs(float time)
    {
        StartCoroutine(StartMusicAfterSecsCor(time));
    }

}
//basic serializable class for audio references
[System.Serializable]
public class Audio
{
    public string name;
    public AudioClip clip;
}
