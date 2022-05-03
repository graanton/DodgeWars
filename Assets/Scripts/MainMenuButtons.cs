using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private Button _backButton;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _swipeSpeed;
    [Header("Player viewer and Player")]
    [SerializeField] private GameObject[] _playerPrefabs;
    [SerializeField] private Transform[] _playerChangePoints;
    [SerializeField] private GameObject _swipePlayerButtonsContainer;
    [SerializeField] private GameObject _choicePlayerButton;

    private GameObject _currentChoicesPlayer;

    private int _currentPlayer;

    private Vector3 _startPoint;
    private Vector3 _currentTarget;

    private void Start()
    {
        _backButton.onClick.AddListener(GoToMainMenu);

        _startPoint = _camera.position;
        _currentTarget = _startPoint;

        _currentChoicesPlayer = _playerPrefabs[0];
    }

    private void GoToMainMenu()
    {
        ResetTarget();
        EnableMenuPanel();
        DisableBackButton();
        DisableSwipeButtons();
        DisabelChoiceButton();
    }

    public void LoadMainScene()
    {
        SampleScene.Load(_currentChoicesPlayer);
    }
    public void StartGoingToChangePlayers()
    {
        _currentTarget = _playerChangePoints[_currentPlayer].position;
        EnableSwipeButtons();
        DisableMenuPanel();
        EnableBackButton();
        EnabelChoiceButton();
    }
    
    private void EnableBackButton()
    {
        _backButton.gameObject.SetActive(true);
    }

    private void DisableBackButton()
    {
        _backButton.gameObject.SetActive(false);
    }

    private void DisableMenuPanel()
    {
        _mainMenuPanel.SetActive(false);
    }

    private void EnableMenuPanel()
    {
        _mainMenuPanel.SetActive(true);
    }

    private void ResetTarget()
    {
        _currentTarget = _startPoint;
    }

    private void EnableSwipeButtons()
    {
        _swipePlayerButtonsContainer.SetActive(true);
    }

    private void DisableSwipeButtons()
    {
        _swipePlayerButtonsContainer.SetActive(false);
    }

    private void EnabelChoiceButton()
    {
        _choicePlayerButton.SetActive(true);
    }

    private void DisabelChoiceButton()
    {
        _choicePlayerButton.SetActive(false);
    }

    public void SwipeRight()
    {
        _currentPlayer++;
        _currentPlayer %= _playerChangePoints.Length;
        _currentTarget = _playerChangePoints[_currentPlayer].position;
    }

    public void SwipeLeft()
    {
        _currentPlayer--;
        if (_currentPlayer < 0)
        {
            _currentPlayer = _playerChangePoints.Length - 1;
        }
        _currentTarget = _playerChangePoints[_currentPlayer].position;
    }

    public void ChoiceCurrentPlayer()
    {
        _currentChoicesPlayer = _playerPrefabs[_currentPlayer];
        GoToMainMenu();
    }

    private void Update()
    {
        _camera.position = Vector3.Lerp(_camera.position, _currentTarget, _swipeSpeed * Time.deltaTime);
    }
}
