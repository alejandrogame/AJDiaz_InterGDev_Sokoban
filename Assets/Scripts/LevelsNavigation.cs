using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsNavigation : MonoBehaviour
{

    [SerializeField] public Goal[] goals; // list of all goal objects
    
    public void Check_Goals()
    {
        bool ready_next = true;
        foreach (Goal goal in goals) {
            if (!goal.goal_achieved)
            {
                ready_next = false;
                break;
            }
        }
        if (ready_next)
        {
            LoadNextLevel();
        }
    }
    
    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                LoadNextLevel();
            }
        }
    }

}
