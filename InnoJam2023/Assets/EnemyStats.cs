using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float baseSpeed;
    public float baseHealth;
    public float baseDamage;
    public float baseReward;

    public float BaseSpeed
    {
        get => baseSpeed;
        set => baseSpeed = value;
    }

    public float BaseHealth1
    {
        get => baseHealth;
        set => baseHealth = value;
    }

    public float BaseDamage
    {
        get => baseDamage;
        set => baseDamage = value;
    }

    public float BaseReward
    {
        get => baseReward;
        set => baseReward = value;
    }
    
    
}
