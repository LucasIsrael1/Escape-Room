using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSystem : MonoBehaviour
{
    public static GameOverSystem instance;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private FadeOverlay fadeOverlay;
    private LevelManager levelManager;
    private GameObject player;

    void Start()
    {
        instance = this;
        gameOverScreen.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void GameOver()
    {
        player.SetActive(false);
        SoundManager.PlaySound("lose");
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        gameOverScreen.SetActive(false);
        SoundManager.PlaySound("button");
        LevelManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        gameOverScreen.SetActive(false);
        SoundManager.PlaySound("button");
        LevelManager.LoadScene("Menu");
    }
}
