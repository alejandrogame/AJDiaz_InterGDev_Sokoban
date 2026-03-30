using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartPromptManager : MonoBehaviour
{

    #region Variables

    [SerializeField] private GameObject restart_prompt_UI;

    private bool is_prompting = false;

    private GameObject previous_selected;
    [SerializeField] private GameObject first_button;

    #endregion

    private void Start()
    {
        restart_prompt_UI.SetActive(false);
    }

    private void Update()
    {
        if (is_prompting)
        {
            GameObject current_selected = EventSystem.current.currentSelectedGameObject;

            if (current_selected != previous_selected)
            {
                previous_selected = current_selected;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }
    }

    public void Prompt()
    {
        restart_prompt_UI.SetActive(true);
        is_prompting = true;
        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(first_button);
            previous_selected = first_button;
        }
    }

    #region Button_Functions

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    #endregion

}
