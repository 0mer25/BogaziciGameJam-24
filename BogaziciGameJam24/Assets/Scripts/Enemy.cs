using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    private void CollisionWithWall()
    {

    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("wall"))
        {
            CollisionWithWall();
            return;
        }

        if(other.gameObject.TryGetComponent<Player>(out Player player))
        {
            GameManager.Instance.IncreaseSlider(damage);
            Destroy(gameObject);
        }
    }
}
