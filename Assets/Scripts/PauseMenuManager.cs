using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    
    #region Variables

    [SerializeField] private GameObject pause_menu_UI;

    [Header("UI Sprites")]
    public Image img_button;
    public Sprite spr_play;
    public Sprite spr_pause;

    private bool is_paused = false;

    private GameObject previous_selected;
    [SerializeField] private GameObject first_button;

    #endregion

    private void Start()
    {
        pause_menu_UI.SetActive(false);
    }

    private void Update()
    {
        if (is_paused)
        {
            GameObject current_selected = EventSystem.current.currentSelectedGameObject;

            if (current_selected != previous_selected)
            {
                previous_selected = current_selected;
            }

            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void Press_Pause_Button()
    {
        if (is_paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        pause_menu_UI.SetActive(true);
        Time.timeScale = 0f;
        is_paused = true;
        img_button.sprite = spr_play;
        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(first_button);
            previous_selected = first_button;
        }
    }

    #region Button_Functions

    public void Resume()
    {
        pause_menu_UI.SetActive(false);
        Time.timeScale = 1f;
        is_paused = false;
        img_button.sprite = spr_pause;
    }

    public void Reset()
    {
        int current_scene_index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_scene_index);
        Time.timeScale = 1f;
    }

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
