using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private Slider slider;
    private void Awake() 
    {
        slider.value = 50f;
    }



    public void IncreaseSlider(float amount)
    {
        slider.value += amount;

        // değişiklikleri kontrol et
    }
}
