using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public List<Sounds> _bgmSounds;
    public List<Sounds> _seSounds;
    public AudioSource _bgmSourceA; 
    public AudioSource _bgmSourceB;
    public AudioSource _seSource;

    [System.Serializable]
    public class Sounds
    {
        [Header("(サウンド名)")] 
        public string _name;
        public AudioClip _clip;
        [Range(0f, 1f)] public float _volume = 1f;
        [Range(0f, 1f)] public float _pitch = 1f;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _bgmSourceA = gameObject.AddComponent<AudioSource>();
        _bgmSourceB = gameObject.AddComponent<AudioSource>();
        _seSource = gameObject.AddComponent<AudioSource>();
    }

    public void IsPlayBGM(string name)
    {
        Sounds bgm = _bgmSounds.Find(sound => sound._name == name);
        if (bgm != null)
        {
            _bgmSourceA.clip = bgm._clip;
            _bgmSourceA.volume = bgm._volume;
            _bgmSourceA.pitch = bgm._pitch;
            _bgmSourceA.loop = true;
            _bgmSourceA.Play();
            Debug.Log("BGM再生中");
        }
        else
        {
            Debug.Log("見つかりません");
        }
    }

    public void IsPlaySE(string name)
    {
        Sounds se = _seSounds.Find(sound => sound._name == name);
        if (se != null)
        {
            _seSource.PlayOneShot(se._clip, se._volume);
        }

    }

    public void IsStopBGM()
    {
        _bgmSourceA.Stop();
    }

    public IEnumerator FadeIn(string name, float duration, float targetVolume)　　//フェードイン処理
    {
        Sounds bgm = _bgmSounds.Find(sound => sound._name == name);
        if (bgm != null)
        {
            _bgmSourceA.clip = bgm._clip;
            _bgmSourceA.volume = 0;
            _bgmSourceA.pitch = bgm._pitch;
            _bgmSourceA.loop = true;
            _bgmSourceA.Play();
        }
        else
        {
            Debug.Log("見つかりません");
        }

        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            _bgmSourceA.volume = Mathf.Lerp(0f, targetVolume, currentTime / duration);
            yield return null;
        }
    }

    public IEnumerator FadeOut(float duration)    //フェードアウト処理
    {
        float startVolume = _bgmSourceA.volume;
        float currentTime = 0f;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            _bgmSourceA.volume = Mathf.Lerp(startVolume, 0f, currentTime / duration);
            yield return null;
        }

        _bgmSourceA.Stop();
    }

}
