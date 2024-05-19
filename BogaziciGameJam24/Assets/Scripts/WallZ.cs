using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallZ : WallSpawner
{
    public override void SpawnEnemy(float currentXPos , float currentZPos)
    {
        GameObject enemyOne = Instantiate(enemyPrefab , new Vector3(spawnPos.position.x , 1f , currentZPos) , transform.rotation);
    }
}
