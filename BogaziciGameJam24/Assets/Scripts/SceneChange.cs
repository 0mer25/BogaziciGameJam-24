using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private int sceneIndex;
    private Button button;
    private void Awake() 
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(() => 
        {
            SceneManager.LoadScene(sceneIndex);
        });
    }
}
