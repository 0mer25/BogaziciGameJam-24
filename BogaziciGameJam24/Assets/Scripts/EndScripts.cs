using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EndScripts : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] float zPos;

    private void Awake() {
        transform.DOScale(1f , 2f)
            .OnComplete(() => 
            {
                cam.transform.DOMoveZ(zPos , 2.5f)
                    .OnComplete(() => 
                    {
                        SceneManager.LoadScene(0);
                    });
            });
    }
}
