using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WallSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected Transform spawnPos;
    public abstract void SpawnEnemy(float currentXPos , float currentZPos);
}
