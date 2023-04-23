using UnityEngine;

public class RandomAudioFade : MonoBehaviour
{
    public AudioSource audioSource;
    public float minVolume = 0.02f; // minimum volume threshold
    public float maxVolume = 1f;
    public float minFadeDuration = 1f;
    public float maxFadeDuration = 5f;
    public float volumeChangeSpeed = 0.1f;

    private float targetVolume;
    private float currentVolume;
    private float fadeStartTime;
    private float fadeDuration;

    void Start()
    {
        currentVolume = audioSource.volume;
    }

    void Update()
    {
        if (Time.time > fadeStartTime + fadeDuration)
        {
            // Start a new fade
            targetVolume = Random.Range(minVolume, maxVolume);
            fadeDuration = Random.Range(minFadeDuration, maxFadeDuration);
            fadeStartTime = Time.time;
        }

        // Calculate the new volume level
        float t = Mathf.Clamp01((Time.time - fadeStartTime) / fadeDuration);
        float newVolume = Mathf.Lerp(currentVolume, targetVolume, t);
        currentVolume = Mathf.Lerp(currentVolume, newVolume, volumeChangeSpeed * Time.deltaTime);

        // Ensure the current volume is above the minimum threshold
        if (currentVolume < minVolume)
        {
            currentVolume = minVolume;
        }

        // Set the audio source volume to the new volume level
        audioSource.volume = currentVolume;
    }
}




