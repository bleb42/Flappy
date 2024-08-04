using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletSpawner[] _bulletSpawners;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endGameScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.Died += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.Died -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;

        foreach (var spawner in _bulletSpawners)
            spawner.ReleaseAll();

        _enemySpawner.StopSpawning();
        _enemySpawner.ReleaseAll();
        _endGameScreen.Open();
        _endGameScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        _bird.Reset();

        foreach (var spawner in _bulletSpawners)
            spawner.ReleaseAll(); ; 
     
        Time.timeScale = 1;
        _enemySpawner.StartSpawning();
    }
}
