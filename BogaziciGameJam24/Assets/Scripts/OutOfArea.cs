using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<Player>(out Player player))
        {
            GameManager.Instance.IncreaseSlider(-1f , true);
            player.transform.position = Vector3.zero;
        }
    }
}
