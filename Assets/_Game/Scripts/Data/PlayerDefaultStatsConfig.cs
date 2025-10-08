using UnityEngine;

[CreateAssetMenu(fileName = "Статы дефолтные", menuName = "Настройки/Начальные бонусы дефолт")]
public class PlayerDefaultStatsConfig : ScriptableObject
{
    public int MaxTurns;
    public int MaxHp;
}