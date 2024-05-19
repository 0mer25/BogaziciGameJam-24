using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float movementSpeed;
    private Rigidbody rb;
    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() 
    {
        rb.velocity = transform.forward * movementSpeed;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<Player>(out Player player))
        {
            GameManager.Instance.IncreaseSlider(damage , true);
            Destroy(gameObject);
        }

        if(other.TryGetComponent<WallSpawner>(out WallSpawner wall))
        {
            wall.SpawnEnemy(transform.position.x , transform.position.z);
            Destroy(gameObject);
        }
    }
}
