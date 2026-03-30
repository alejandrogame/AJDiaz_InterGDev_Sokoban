using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Moral_Support : MonoBehaviour
{

    [SerializeField] public GameObject visitor;
    [SerializeField] public float wiggle_room; // distance offset between this obj and visitor

    private bool is_displaying_message = false;

    void Update()
    {
        Vector2 this_pos_xz = new Vector2(transform.position.x, transform.position.z);
        Vector2 visitor_pos_xz = new Vector2(visitor.transform.position.x, visitor.transform.position.z);

        if (Vector2.Distance(this_pos_xz, visitor_pos_xz) < wiggle_room)
        {
            if (!is_displaying_message)
            {
                Debug.Log("whattup my brotha");
                is_displaying_message = true;
            }
        }
        else
        {
            is_displaying_message = false;
        }
    }
}
