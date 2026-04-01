using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Slide_Move_SFX : MonoBehaviour
{

    [Header("Audio Settings")]
    [SerializeField] public AudioSource audio_source;
    [SerializeField] public AudioClip sfx_move;
    [SerializeField] public float start_time = 0.1f;

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

        audio_source.loop = true;
    }

    void Update()
    {
        float frame_movement = Vector3.Distance(transform.position, previous_position);
        if (frame_movement > 0.001f)
        {
            if (!audio_source.isPlaying)
            {
                audio_source.time = start_time;
                audio_source.Play();
            }
        }
        else
        {
            if (audio_source.isPlaying)
            {
                audio_source.Stop();
            }
        }
        previous_position = transform.position;
    }
}
