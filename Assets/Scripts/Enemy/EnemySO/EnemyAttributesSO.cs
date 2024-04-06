using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewEnemy",menuName ="Create New EnemyAttributes")]
public class EnemyAttributesSO : ScriptableObject
{
    [Header("Basic Atributes")]
    public float velocity;
    public float damage;
    public float lives;
    public int points;
    public GameObject smokeEffect;

    [Header("Flyer Attributes")]
    public float verticalVelocity;
    public bool isFly;
    public float verticalBound;

    [Header("PowerUps")]
    public GameObject powerUpDmg;
    public GameObject powerUpFood;

}
