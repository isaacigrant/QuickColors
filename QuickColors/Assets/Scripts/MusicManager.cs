using System;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] private AudioSource musicSource;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        musicSource.Play();
    }
}
