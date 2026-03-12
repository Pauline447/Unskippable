using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private AudioSource MusicSourceIntro;

    [SerializeField] private AudioSource AmbientSource;
    [SerializeField] private List<AudioSource> soundEffectSources;

    [Header("Music")]
    [SerializeField] private List<AudioClip> BackgroundMusic;
    [SerializeField] private float MainMusicVolume;
    [SerializeField] private bool PlayMusicOnStart;

    [Header("Sound Clips")]
    [SerializeField]
    private List<AudioClip> SoundEffects;

    private int m_currMusic;
    private List<AudioSource> m_sourcesSound;

    #region Singleton Pattern

    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Sound Manager error");
            }

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public void Start()
    {
        if (PlayMusicOnStart) PlayMusic(0);
        // (PlayAmbientOnStart) FadeInAmbient();

        m_sourcesSound = new List<AudioSource>();
    }

    public void PlayMusic(int musicIndex)
    {
        if (MusicSource != null)
        {
            MusicSource.volume = MainMusicVolume;
            MusicSource.clip = BackgroundMusic[musicIndex];
            MusicSource.Play();
            //FadeInMusic(musicIndex);
            m_currMusic = musicIndex;
        }
    }

    public void StopMusic()
    {
        if (MusicSource != null)
            MusicSource.Stop();
        //FadeOutMusic();
    }

    #region Fading In and Out

    private Coroutine musicFadeCoroutine;
    private Coroutine ambientFadeCoroutine;

    private IEnumerator FadeAudioSource(AudioSource source, float targetVolume, float duration, bool stopAfterFade = false)
    {
        float startVolume = source.volume;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / duration);
            yield return null;
        }

        source.volume = targetVolume;

        if (stopAfterFade && targetVolume == 0f)
            source.Stop();
    }

    //fading music
    public void FadeInMusic(int trackIndex, float duration = 10f)
    {
        if (MusicSource == null || trackIndex >= BackgroundMusic.Count) return;

        if (musicFadeCoroutine != null)
            StopCoroutine(musicFadeCoroutine);

        MusicSource.clip = BackgroundMusic[trackIndex];
        MusicSource.volume = 0f;
        MusicSource.Play();
        m_currMusic = trackIndex;

        musicFadeCoroutine = StartCoroutine(FadeAudioSource(MusicSource, MainMusicVolume, duration));
    }

    public void FadeOutMusic(float duration = 10f)
    {
        if (MusicSource == null || !MusicSource.isPlaying) return;

        if (musicFadeCoroutine != null)
            StopCoroutine(musicFadeCoroutine);

        musicFadeCoroutine = StartCoroutine(FadeAudioSource(MusicSource, 0f, duration, stopAfterFade: true));
    }

    #endregion

    public void PlaySoundEffectByName(string name, bool playOverOtherSound)
    {
        foreach (var sound in SoundEffects)
        {
            if (sound.name == name)
            {
                PlaySoundEffect(sound, playOverOtherSound);
                return;
            }
        }

    }

    public void StopAllSounds()
    {
        StopAllCoroutines();
        foreach (AudioSource soundSources in m_sourcesSound)
        {
            soundSources.Stop();
        }
    }
    private AudioSource m_currentSource;
    public void PlaySoundEffect(AudioClip sound, bool playOverOtherSound)
    {
        AudioSource currentSource = TryGetFreeSource(playOverOtherSound);
        currentSource.clip = sound;
        currentSource.Play();
        m_currentSource = currentSource;
        m_sourcesSound.Add(currentSource);
    }

    public AudioSource GetCurrentSoundSource()
    {
        return m_currentSource;
    }
    private AudioSource TryGetFreeSource(bool playOverOtherSound)
    {
        if (playOverOtherSound)
        {
            foreach (AudioSource source in soundEffectSources)
            {
                if (!source.isPlaying)
                {
                    return source;
                }
            }

            AudioSource newSource = Instantiate(soundEffectSources[0]);
            soundEffectSources.Add(newSource);
            newSource.clip = null;

            return newSource;
        }
        else
        {
            return soundEffectSources[0];
        }
    }
}

