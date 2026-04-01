using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Smooth_Move_SFX : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] public AudioSource audio_source;
    [SerializeField] public AudioClip sfx_move;
    [SerializeField] public float start_time = 0.1f;

    [SerializeField] public float distance = 0.01f;

    private Vector3 last_position;

    void Start()
    {
        last_position = transform.position;

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
        float distanceMoved = Vector3.Distance(transform.position, last_position);

        if (distanceMoved > distance)
        {
            if (!audio_source.isPlaying)
            {
                audio_source.time = start_time;
                audio_source.Play();
                Debug.Log("smooth sfx play");
            }
        }
        else
        {
            if (audio_source.isPlaying)
            {
                audio_source.Stop();
            }
        }

        last_position = transform.position;
    }
}