using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Sarsıntının yoğunluğu
    public float shakeIntensity = 0.3f;
    // Sarsıntının süresi
    public float shakeDuration = 0.5f;

    private Vector3 originalPosition;
    private Coroutine shakeCoroutine;

    void Start()
    {
        // Kameranın orijinal pozisyonunu sakla
        originalPosition = transform.localPosition;
    }

    public void StartShake(float duration)
    {
        // Eğer zaten bir sarsıntı devam ediyorsa, onu durdur
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
            transform.localPosition = originalPosition;
        }
        // Yeni sarsıntı coroutine'ini başlat
        shakeCoroutine = StartCoroutine(Shake(duration));
    }

    private IEnumerator Shake(float duration)
    {
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * shakeIntensity;
            float y = Random.Range(-1f, 1f) * shakeIntensity;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        // Sarsıntı süresi dolduğunda, kamerayı orijinal pozisyonuna döndür
        transform.localPosition = originalPosition;
        shakeCoroutine = null;
    }
}
