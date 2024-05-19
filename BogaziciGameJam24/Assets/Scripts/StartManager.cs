using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] GameObject music;
    [SerializeField] GameObject cam;
    [SerializeField] float zPos;
    private void Awake() 
    {
        DontDestroyOnLoad(music);

        transform.DOScale(1f , .5f)
            .OnComplete(() =>
            {
                audioSource.Play();
            });

        cam.transform.DOMoveZ(zPos , 14f)
            .OnComplete(() => {SceneManager.LoadScene(2);});
    }

    
}
