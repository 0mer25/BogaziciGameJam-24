using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallX : WallSpawner
{
    public override void SpawnEnemy(float currentXPos , float currentZPos)
    {
        GameObject enemyOne = Instantiate(enemyPrefab , new Vector3(currentXPos , 1f , spawnPos.position.z) , transform.rotation);
    }
}
