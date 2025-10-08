using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Настройки", fileName = "Конфиг звуков")]
public class SoundsConfig : ScriptableObject
{
    public SfxClips SfxClips;
    public BackgroundMusicClips BackgroundMusicClips;
}

[Serializable]
public class BackgroundMusicClips
{
    public AudioClip OnLevel;
    public AudioClip MainMenu;
}

[Serializable]

public class SfxClips
{
    public AudioClip OpenTile;
    public AudioClip TakeDamage;
    public AudioClip SetFlag;
    public AudioClip RemoveFlag;
}