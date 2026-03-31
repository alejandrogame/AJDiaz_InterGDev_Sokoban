using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class Move_SFX : MonoBehaviour
{
    
    [Header("Audio Settings")]
    [SerializeField] public AudioSource audio_source;
    [SerializeField] public AudioClip sfx_move;
    [SerializeField] public float start_time;

    [Header("Movement Check Values")]
    [SerializeField] public float timer = 0.25f;
    [SerializeField] public float distance = 0.05f; 

    private Vector3 lastPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;

        if (audio_source == null)
        {
            audio_source = GetComponent<AudioSource>();
        }

        if (sfx_move != null)
        {
            audio_source.clip = sfx_move;
        }

        StartCoroutine(CheckForMovement());
    }

    private IEnumerator CheckForMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);

            float distance_moved = Vector3.Distance(transform.position, lastPosition);

            if (distance_moved > distance)
            {
                if (!audio_source.isPlaying)
                {
                    PlaySFX();
                }
            }
            else
            {
                if (audio_source.isPlaying)
                {
                    audio_source.Stop();
                }
            }
            lastPosition = transform.position;
        }
    }

    private void PlaySFX()
    {
        if (audio_source != null && sfx_move != null && !audio_source.isPlaying)
        {
            audio_source.time = start_time;
            audio_source.Play();
        }
    }
}
