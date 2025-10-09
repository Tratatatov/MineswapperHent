using UnityEngine;

public class SoundManager : MonoBehaviour, IPausable
{
    public static SoundManager Instance;

    [SerializeField] private SoundsConfig _soundsConfig;
    [SerializeField] private AudioSource _mainSoundtrack;
    [SerializeField] private AudioSource _sfxSource;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void SetPause()
    {
        _mainSoundtrack.Pause();
        _sfxSource.Pause();
    }

    public void UnPause()
    {
        _mainSoundtrack.UnPause();
        _sfxSource.UnPause();
    }

    public void MuteMusic(bool mute)
    {

        
    }
    
    public void MuteSFX(bool mute)
    {
        
    }
    
    public void MuteGlobal(bool mute)
    {
        MuteMusic(mute);
        MuteMusic(mute);
    }
    
    public void SetMusicVolume(float value)
    {
        
    }
    
    public void SetSFXVolume(float value)
    {
        
    }
    
    public void SetGlobalVolume(float value)
    {
        
    }
}

public interface IPausable
{
    void SetPause();
    void UnPause();
}

