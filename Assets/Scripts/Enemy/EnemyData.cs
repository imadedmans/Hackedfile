using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Object", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public new string name;
    public int healthPoints;
    public PlayerBulletCollisionTable[] enemyScripts;
}
