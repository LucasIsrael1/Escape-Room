using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    public static PauseSystem instance;

    private InputAction pauseAction;
    private bool isPaused = false;

    [SerializeField] private GameObject pauseMenu;

    void Start()
    {
        instance = this;
        pauseMenu.SetActive(false);
    }

    void OnEnable()
    {
        pauseAction = InputSystem.actions.FindAction("Pause");
        pauseAction.performed += OnPause;
        pauseAction.Enable();
    }

    void OnDisable()
    {
        pauseAction.performed -= OnPause;
        pauseAction.Disable();
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void ResetLevel()
    {
        if (isPaused) TogglePause();
        LevelManager.instance.LoadScene(SceneManager.GetActiveScene().name);
    }
}
