using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float baseSpeed;
    public float BaseHealth;
    public float baseDamage;

    public float BaseSpeed
    {
        get => baseSpeed;
        set => baseSpeed = value;
    }

    public float BaseHealth1
    {
        get => BaseHealth;
        set => BaseHealth = value;
    }

    public float BaseDamage
    {
        get => baseDamage;
        set => baseDamage = value;
    }
}
