using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Finished")]
    [SerializeField] private GameObject finishedScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        finishedScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            StartGame();
        }
    }

    #region Game Over
    public void GameOver() {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    #endregion

    #region Pause
    public void PauseGame(bool status) {
        pauseScreen.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void SoundVolume() {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume() {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion

    #region Start
    public void StartGame() {
        SceneManager.LoadScene(1);
    }
    #endregion

    #region Finished
    public void Finished() {
        finishedScreen.SetActive(true);
    } 
    #endregion
}
