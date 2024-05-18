using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Antidepressant : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    private AudioSource audioSource;
    [SerializeField] private float heal;
    private CapsuleCollider capsuleCollider;
    private MeshRenderer meshRenderer;
    private void Awake() 
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.TryGetComponent<Player>(out Player player))
        {
            GameManager.Instance.IncreaseSlider(-heal);
            Destroyyy();
        }
    }

    private void Destroyyy()
    {
        capsuleCollider.enabled = false;
        meshRenderer.enabled = false;
        //audioSource.Play();
        //particle.Play();

        transform.DOScale(transform.localScale , 1f)
            .OnComplete(() => {Destroy(gameObject);});
    }
}
