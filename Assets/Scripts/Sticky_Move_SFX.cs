using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]

public class Sticky_Move_SFX : MonoBehaviour
{

    [Header("Audio Settings")]
    [SerializeField] public AudioSource audio_source;
    [SerializeField] public AudioClip sfx_move;
    [SerializeField] public float start_time = 0.1f;
    [SerializeField] public float end_time = 1f;

    [SerializeField] public float distance = 1f;

    private Vector3 previous_position;

    void Start()
    {
        previous_position = transform.position;

        if (audio_source == null)
        {
            audio_source = GetComponent<AudioSource>();
        }

        if (sfx_move != null)
        {
            audio_source.clip = sfx_move;
        }
    }
    void Update()
    {
        float distance_moved = Vector3.Distance(transform.position, previous_position);

        // If obj is moving (at all)
        if (distance_moved > 0.001f)
        {
            if (!audio_source.isPlaying)
            {
                PlaySFX();
            }
            if (audio_source.time >= end_time)
            {
                audio_source.Stop();
            }
        }
        else
        {
            if (audio_source.isPlaying)
            {
                audio_source.Stop();
            }
        }

        // If obj moved more than a certain distance
        if (distance_moved >= distance)
        {
            previous_position = transform.position;
            audio_source.Stop();
        }
    }

    private void PlaySFX()
    {
        if (audio_source != null && audio_source.clip != null)
        {
            audio_source.time = start_time;
            audio_source.Play();
        }
    }

}
