using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSlime",menuName ="CreateNewSlimeSO")]
public class SlimeSO : ScriptableObject
{
    [Header("State Name")]
    public string slimeName;

    [Header("Basic Attributes")]
    public float velocity;
    public float jumpVelocity;
    public float damage;
    public float abilityCooldown;
    [Header("Size Scale In Transform")]
    public float sizeX, sizeY;

    [Header("Animator to fit situation")]
    Animator animator;

    [Header("Icon Image")]
    public Sprite icon;

    [Header("Projectile Prefub")]
    public GameObject shotPrefub;

    [Header("Shoot cooldown")]
    public float shootCooldown;


}
