using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsNavigation : MonoBehaviour
{

    [SerializeField] public Block[] blocks; // list of all block objects
    [SerializeField] public Goal[] goals; // list of all corresponding goal objects
    
    public void Check_Goals()
    {
        Debug.Log("gm checking goals");
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
