using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
    Button button;
    private void Awake() 
    {
        button = GetComponent<Button>();
        
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
