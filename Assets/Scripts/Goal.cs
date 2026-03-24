using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField] public LevelsNavigation gmln_scr;
    [SerializeField] public GameObject block;
    public bool goal_achieved = false;
    [SerializeField] public float wiggle_room; // distance offset between goal and block

    private void Check_Goal()
    {
        Vector2 goal_pos_xz = new Vector2(transform.position.x, transform.position.z);
        Vector2 block_pos_xz = new Vector2(block.transform.position.x, block.transform.position.z);
        
        if (Vector2.Distance(goal_pos_xz, block_pos_xz) < wiggle_room)
        {
            goal_achieved = true;
            gmln_scr.Check_Goals();
        }
        else
        {
            goal_achieved = false;
        }
    }

    void Update()
    {
        Check_Goal();
    }
}
