using System;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip[] sfxSounds;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameManager.instance.OnNewChosenColor += PlayCorrectDing;
    }

    public void PlayCorrectDing(object s, EventArgs e)
    {
        sfxSource.clip = sfxSounds[0];
        sfxSource.Play();
    }
    public void PlayWrongBuzz()
    {
        sfxSource.clip = sfxSounds[1];
        sfxSource.Play();
    }
}
