using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
 * A singleton devised to allow the playing of audio clips from a single source instead of having many audio sources in all gameobjects
 */

public class SoundManager : MonoBehaviour
{
    #region Singleton
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    AudioSource audioSource;
    [SerializeField] AudioClip deathAudioClip;
    [SerializeField] AudioClip gameOverAudioClip;
    [SerializeField] AudioClip victoryAudioClip;
    [SerializeField] AudioClip startAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }

    //Plays a clip that is parsed through when called
    public void PlayAudioClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayDeathAudioClip()
    {
        audioSource.PlayOneShot(deathAudioClip);
    }

    public void PlayGameOverAudioClip()
    {
        audioSource.PlayOneShot(gameOverAudioClip);
    }

    public void PlayVictoryAudioClip()
    {
        audioSource.PlayOneShot(victoryAudioClip);
    }

    public void PlayStartAudioClip()
    {
        audioSource.PlayOneShot(startAudioClip);
    }
}
