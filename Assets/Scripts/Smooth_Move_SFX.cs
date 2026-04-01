using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Smooth_Move_SFX : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] public AudioSource audio_source;
    [SerializeField] public AudioClip sfx_move;
    [SerializeField] public float start_time = 0.1f;

    [Header("Movement Settings")]
    [SerializeField] public float movementThreshold = 0.01f; // Super small to detect stops instantly

    private Vector3 lastPosition;

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

        audio_source.loop = false;
    }

    void Update()
    {
        // 1. Calculate how far it moved since the EXACT LAST FRAME
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        // 2. IF MOVED: Play sound if it's not already playing
        if (distanceMoved > movementThreshold)
        {
            if (!audio_source.isPlaying)
            {
                audio_source.time = start_time;
                audio_source.Play();
            }
        }
        // 3. IF STOPPED: Kill the sound on a dime!
        else
        {
            if (audio_source.isPlaying)
            {
                audio_source.Stop();
            }
        }

        // Always update the position at the end of the frame
        lastPosition = transform.position;
    }
}