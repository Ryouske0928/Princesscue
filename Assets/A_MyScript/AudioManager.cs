using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public List<Sounds> _bgmSounds;
    public List<Sounds> _seSounds;
    public AudioSource _bgmSource;
    public AudioSource _seSource;

    [System.Serializable]
    public class Sounds
    {
        [Header("(ƒTƒEƒ“ƒh–¼)")] 
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
        _bgmSource = gameObject.AddComponent<AudioSource>();
        _seSource = gameObject.AddComponent<AudioSource>();
    }

    public void IsPlayBGM(string name)
    {
        Sounds bgm = _bgmSounds.Find(sound => sound._name == name);
        if (bgm != null)
        {
            _bgmSource.clip = bgm._clip;
            _bgmSource.volume = bgm._volume;
            _bgmSource.pitch = bgm._pitch;
            _bgmSource.loop = true;
            _bgmSource.Play();
            Debug.Log("BGMÄ¶’†");
        }
        else
        {
            Debug.Log("Œ©‚Â‚©‚è‚Ü‚¹‚ñ");
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
        _bgmSource.Stop();
    }
}
