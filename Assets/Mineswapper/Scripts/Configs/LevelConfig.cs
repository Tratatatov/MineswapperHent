using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Scriptable Objects/LevelConfig")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _minesCount = 0;
    [SerializeField] private int _levelWidth = 10;
    [SerializeField] private int _levelHeight = 10;

    public int MinesCount { get => _minesCount; }
    public int LevelWidth { get => _levelWidth; }
    public int LevelHeight { get => _levelHeight; }
}
