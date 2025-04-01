using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private Button _resetButton;
    [SerializeField] private ResetScreen _resetScreen;
    [SerializeField] private BulletReseter _bulletReseter;

    private void Start()
    {
        StartGame();
    }

    private void OnEnable()
    {
        _resetButton.onClick.AddListener(StartGame);
        _player.GameIsOver += GameOver;
    }

    private void OnDisable()
    {
        _resetButton.onClick.RemoveListener(StartGame);
        _player.GameIsOver -= GameOver;
    }

    private void StartGame() 
    {
        _resetScreen.gameObject.SetActive(false);
        Time.timeScale = 1f;
        _enemyGenerator.StartGenerating();
        _player.Reset();
    }

    private void GameOver() 
    {
        _bulletReseter.Reset();
        Time.timeScale = 0;
        _enemyGenerator.StopGenerating();
        _resetScreen.gameObject.SetActive(true);
    }
}