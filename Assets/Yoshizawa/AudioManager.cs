using UnityEngine;

// 日本語対応
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance => _instance;
    public float BGMVolume { get => _bgm.volume; set => _bgm.volume = Mathf.Clamp01(value); }
    public float BGMPitch { get => _bgm.pitch; set => _bgm.pitch = Mathf.Clamp01(value); }
    public float SEVolume { get => _se.volume; set => _se.volume = Mathf.Clamp01(value); }
    public float SEPitch { get => _se.pitch; set => _se.pitch = Mathf.Clamp01(value); }

    [SerializeField] private AudioSource _bgm = null;
    [SerializeField] private AudioSource _se = null;

    private static AudioManager _instance = null;

    private void Awake()
    {
        if (!_instance) _instance = this;
        else Destroy(gameObject);

        if (!_bgm) _bgm = gameObject.AddComponent<AudioSource>();
        _bgm.playOnAwake = false;

        if (!_se) _se = gameObject.AddComponent<AudioSource>();
        _se.playOnAwake = false;
        _se.loop = false;
    }

    public void PlayBGM(AudioClip clip, bool isLoop = true)
    {
        if (clip)
        {
            _bgm.clip = clip;
            _bgm.loop = isLoop;
            _bgm.Play();
        }
    }

    public void StopBGM() => _bgm.Stop();

    public void PlaySE(AudioClip clip)
    {
        if(clip) _se.PlayOneShot(clip);
    }

    public void StopSE() => _se.Stop();
}
