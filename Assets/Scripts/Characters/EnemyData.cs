using UnityEngine;

public class EnemyData : ScriptableObject
{
    public string enemyName;

    public enum EnemyType
    {
        Normal,
        Elite,
        Boss
    }

    public int enemyMaxHealth;
    public int enemyAttackDamage;

    public Sprite enemySprite;
}
