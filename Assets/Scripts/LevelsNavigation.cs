using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsNavigation : MonoBehaviour
{

    [SerializeField] private float scene_change_timer = 5f;
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
        scene_change_timer -= Time.deltaTime;

        if (scene_change_timer <= 0)
        {
            LoadNextLevel();
            scene_change_timer = 5f;
        }
    }
}
