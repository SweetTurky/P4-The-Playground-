using System.Collections;
using UnityEngine;

public class VolumeInterpolation : MonoBehaviour
{
    public AudioSource audioSource;
    public float minVolume = 0.01f;
    public float maxVolume = 1f;
    public float minDuration = 0.5f;
    public float maxDuration = 3f;
    public float currentVolume;

    private Coroutine volumeCoroutine;

    private void Start()
    {
        // Start the volume interpolation coroutine
        volumeCoroutine = StartCoroutine(InterpolateVolume());
    }

    private IEnumerator InterpolateVolume()
    {
        while (true)
        {
            // Generate a random target volume and duration
            float targetVolume = Random.Range(minVolume, maxVolume);
            float duration = Random.Range(minDuration, maxDuration);

            // Calculate the step size for each frame
            float step = (targetVolume - audioSource.volume) / (duration / Time.deltaTime);

            // Interpolate the volume gradually over time
            while (Mathf.Abs(audioSource.volume - targetVolume) > 0.01f)
            {
                audioSource.volume += step;
                yield return null;
            }

            // Snap the volume to the target value to avoid rounding errors
            audioSource.volume = targetVolume;

            // Wait for a short pause before starting the next interpolation
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        }
    }

    private void Update()
    {
        currentVolume = audioSource.volume;
    }

    private void OnDestroy()
    {
        // Stop the volume interpolation coroutine when the script is destroyed
        if (volumeCoroutine != null)
        {
            StopCoroutine(volumeCoroutine);
        }
    }
}
