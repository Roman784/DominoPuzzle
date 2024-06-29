using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourcer : MonoBehaviour
{
    public void PlayOneShot(AudioClip clip, float volume)
    {
        AudioSource source = GetComponent<AudioSource>();

        source.volume = volume;
        source.PlayOneShot(clip);

        DontDestroyOnLoad(gameObject);
        Destroy(gameObject, clip.length);
    }
}
