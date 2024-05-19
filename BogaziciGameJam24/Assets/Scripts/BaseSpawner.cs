using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 xPos;
    [SerializeField] private Vector2 zPos;
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] protected float cooldown;
    private float remaninTime;
    private void Awake() 
    {
        remaninTime = cooldown;
    }

    private void Update() 
    {
        if(remaninTime > 0)
            remaninTime -= Time.deltaTime;
        else
        {
            Spawn();
            remaninTime = cooldown;
        }    
    }

    protected void Spawn()
    {
        GameObject spawnObject = Instantiate(spawnPrefab , new Vector3(UnityEngine.Random.Range(xPos[0] , xPos[1]) , 1f , UnityEngine.Random.Range(zPos[0] , zPos[1])) , Quaternion.identity);
        spawnObject.transform.rotation = Quaternion.Euler(0f , Random.Range(0f , 360f) , 0f);
    }
}
