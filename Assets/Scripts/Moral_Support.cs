using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Moral_Support : MonoBehaviour
{

    [SerializeField] public List<GameObject> visitors = new List<GameObject>(); 
    [SerializeField] public GameObject panel;
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] public float wiggle_room; // distance offset between this obj and visitor

    [SerializeField][Range(1, 5)] public float exponential_power;
    [SerializeField] public List<string> texts = new List<string>();

    [SerializeField] public float activation_time = 2.0f; // amount of time to activate
    private float timer = 0.0f;
    private bool is_displaying_message = false;

    void Start()
    {
        text = panel.GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        Vector2 this_pos_xz = new Vector2(transform.position.x, transform.position.z);

        bool any_visitor_on_tile = false;

        foreach (GameObject current_visitor in visitors)
        {
            if (current_visitor == null) continue;

            Vector2 visitor_pos_xz = new Vector2(current_visitor.transform.position.x, current_visitor.transform.position.z);
            float current_distance = Vector2.Distance(this_pos_xz, visitor_pos_xz);

            if (current_distance < wiggle_room)
            {
                any_visitor_on_tile = true;
                break;
            }
        }

        if (any_visitor_on_tile)
        {
            if (!is_displaying_message)
            {
                timer += Time.deltaTime;

                if (timer >= activation_time && texts.Count > 0)
                {
                    text.text = GetExpRandText();
                    panel.SetActive(true);
                    is_displaying_message = true;
                }
            }
            else
            {
                if (!panel.activeSelf)
                {
                    panel.SetActive(true);
                }
            }
        }
        else
        {
            panel.SetActive(false);
            is_displaying_message = false;
            timer = 0.0f;
        }
    }

    private string GetExpRandText()
    {
        float exp_random_float = Mathf.Pow(Random.value, exponential_power);
        int index = Mathf.FloorToInt(exp_random_float * texts.Count);

        if (index >= texts.Count)
        {
            index = texts.Count - 1;
        }
        return texts[index];
    }
}