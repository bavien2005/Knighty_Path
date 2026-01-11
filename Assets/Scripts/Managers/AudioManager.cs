using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioBackground;

    [SerializeField] private AudioSource audioEffect;

    [SerializeField] private AudioClip audioClipBackground;

    [SerializeField] private AudioClip audioJumClip;

    [SerializeField] private AudioClip audioCoinClip;

    private PlayerController playerController;

    private PlayerCollision playerCollision;

    public static AudioManager _instance;

    private void Awake()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        playerCollision = FindAnyObjectByType<PlayerCollision>();

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (audioBackground == null)
        {
            audioBackground = gameObject.AddComponent<AudioSource>();
        }

        if (audioEffect == null)
        {
            audioEffect = gameObject.AddComponent<AudioSource>();
        }

    }

    private void Start()
    {
        PlayBackgroundMusic();
    }


    public void PlayBackgroundMusic()
    {
        if (audioBackground == null || audioClipBackground == null)
        {
            return;
        }
        if (!audioBackground.isPlaying)
        {
            audioBackground.clip = audioClipBackground;
            audioBackground.Play();
        }
    }

    public void PlayJumpSound()
    {
        if (audioEffect == null || audioJumClip == null)
        {
            return;
        }
        audioEffect.PlayOneShot(audioJumClip);
    }

    public void PlayCoinSound()
    {
        if (audioEffect == null || audioCoinClip == null)
        {
            return;
        }
        audioEffect.PlayOneShot(audioCoinClip);
    }

    public void StopAllSounds()
    {
        if (audioBackground != null && audioBackground.isPlaying)
        {
            audioBackground.Stop();
        }
        if (audioEffect != null && audioEffect.isPlaying)
        {
            audioEffect.Stop();
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            PlayBackgroundMusic();
        }
    }

}
