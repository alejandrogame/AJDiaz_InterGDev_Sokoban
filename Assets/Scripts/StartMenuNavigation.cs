using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMenuNavigation : MonoBehaviour
{

    private GameObject previous_selected;
    [SerializeField] private GameObject first_button;

    private void Update()
    {
        GameObject current_selected = EventSystem.current.currentSelectedGameObject;

        if (current_selected != previous_selected)
        {
            previous_selected = current_selected;
        }
    }

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(first_button);
        previous_selected = first_button;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
