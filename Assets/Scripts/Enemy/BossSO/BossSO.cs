using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewBoss",menuName ="CreateNewBossSO")]
public class BossSO : ScriptableObject
{
    public GameObject minions;
    public GameObject projectilePrefub;
    public float spawnCooldown;
    public float attackCooldown;
    public float lives;
    public int points;
}
