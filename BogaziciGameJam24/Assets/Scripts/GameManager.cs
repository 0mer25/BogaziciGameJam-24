using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private Player player;
    [SerializeField] private Slider slider;
    [SerializeField] private AudioClip start;
    [SerializeField] private List<AudioClip> twenty;
    [SerializeField] private List<AudioClip> sixty;
    [SerializeField] private List<AudioClip> eigthy;
    [SerializeField] private AudioClip end;
    private AudioSource audioSource;
    [SerializeField] CinemachineVirtualCamera cam;
    [SerializeField] Material mat;
    [SerializeField] List<Material> matss;
    [SerializeField] List<GameObject> images;
    [SerializeField] private GameObject controls;
    [SerializeField] private Volume volume;
    private Vignette vignette;
    private void Awake() 
    {
        if (volume.profile.TryGet<Vignette>(out Vignette vignetteComponent))
        {
            vignette = vignetteComponent;
        }
        transform.DOScale(1f , 1f)
            .OnComplete(() => {controls.SetActive(false);});
        audioSource = GetComponent<AudioSource>();
        slider.value = 50f;
        SetColorAndImages();
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void IncreaseSlider(float amount , bool negative)
    {
        float value = slider.value;
        slider.value += amount;
        SetColorAndImages();
        
        if(slider.value <= 0f)
        {
            PlaySound(start);
            EndGame(true);
            return;
        }
        else if(slider.value >= 80f)
        {
            PlaySound(end);
            EndGame(false);
            return;
        }

        
        if(negative)
        {
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain += 0.05f;
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain += 0.05f;

            if(value < 20f && slider.value >= 20f)
                PlaySound(twenty[1]);
            else if(value < 40f && slider.value >= 40f)
                PlaySound(sixty[1]);
            else if(value < 60f && slider.value >= 60f)
                PlaySound(eigthy[1]);
        }
        else
        {
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain -= 0.07f;
            cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain -= 0.07f;

            if(value > 20f && slider.value <= 20f)
                PlaySound(twenty[0]);
            else if(value > 40f && slider.value <= 40f)
                PlaySound(sixty[0]);
            else if(value > 60f && slider.value <= 60f)
                PlaySound(eigthy[0]);
        }
    }
    private void EndGame(bool win)
    {
        player.enabled = false;
        if(win)
        {
            transform.DOScale(1f , 1.5f)
                .OnComplete(() => {SceneManager.LoadScene(3);});
        }
        else
        {
            transform.DOScale(1f , 1.5f)
                .OnComplete(() => {SceneManager.LoadScene(4);});
        }
    }

    public void SetColorAndImages()
    {
        if(slider.value >= 0f && slider.value <= 20f)
        {
            vignette.color.value = matss[0].color;
            mat.color = matss[0].color;
            images[0].SetActive(false);
        }
        else if(slider.value > 20f && slider.value <= 40f)
        {
            vignette.color.value = matss[1].color;
            mat.color = matss[1].color;
            images[0].SetActive(true);
            images[1].SetActive(false);
        }
        else if(slider.value > 40f && slider.value <= 60f)
        {
            vignette.color.value = matss[2].color;
            mat.color = matss[2].color;
            images[1].SetActive(true);
            images[2].SetActive(false);
        }
        else if(slider.value >= 60f)
        {
            vignette.color.value = matss[3].color;
            mat.color = matss[3].color;
            images[2].SetActive(true);
        }
    }

}
