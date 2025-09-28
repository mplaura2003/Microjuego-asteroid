using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool IsPaused { get; private set; }

    public GameObject pausePanel;   
    public Button pauseButton;     
    public Button resumeButton;    

    [Header("Input")]
    public KeyCode toggleKey = KeyCode.Escape;

    void Awake()
    {
        
        Time.timeScale = 1f;
        AudioListener.pause = false;
        IsPaused = false;

        if (pausePanel) pausePanel.SetActive(false);
        if (pauseButton) pauseButton.onClick.AddListener(Pause);
        if (resumeButton) resumeButton.onClick.AddListener(Resume);

       
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if (IsPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        if (IsPaused) return;
        IsPaused = true;

        Time.timeScale = 0f;          
        AudioListener.pause = true;    

        if (pausePanel) pausePanel.SetActive(true);
        if (pauseButton) pauseButton.gameObject.SetActive(false);

       
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        if (!IsPaused) return;
        IsPaused = false;

        Time.timeScale = 1f;
        AudioListener.pause = false;

        if (pausePanel) pausePanel.SetActive(false);
        if (pauseButton) pauseButton.gameObject.SetActive(true);

    
       
    }
}