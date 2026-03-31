using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Moral_Support : MonoBehaviour
{

    [SerializeField] public GameObject visitor;
    [SerializeField] public GameObject panel;
    [SerializeField] public TextMeshProUGUI text;
    [SerializeField] public float wiggle_room; // distance offset between this obj and visitor

    [SerializeField][Range(1, 5)] public float exponential_power;
    [SerializeField] public List<string> texts = new List<string>();

    private bool is_displaying_message = false;

    void Start()
    {
        text = panel.GetComponentInChildren<TextMeshProUGUI>();
    }
    void Update()
    {
        Vector2 this_pos_xz = new Vector2(transform.position.x, transform.position.z);
        Vector2 visitor_pos_xz = new Vector2(visitor.transform.position.x, visitor.transform.position.z);

        if (Vector2.Distance(this_pos_xz, visitor_pos_xz) < wiggle_room)
        {
            if (!is_displaying_message && texts.Count > 0)
            {
                text.text = GetExpRandText();
                panel.SetActive(true);
                is_displaying_message = true;
            }
        }
        else
        {
            panel.SetActive(false);
            is_displaying_message = false;
        }
    }

    private string GetExpRandText()
    {
        float exp_random_float = Mathf.Pow(Random.value, exponential_power); // get random #, values weighted more towards 0, less towards 1
        int index = Mathf.FloorToInt(exp_random_float * texts.Count); // translating to list indeces, all values except 1 will result in index less than 1 here
        if (index >= texts.Count) // in case index = 1
        {
            index = texts.Count - 1;
        }
        return texts[index];
    }
}
