using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private Button _backButton;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _swipeSpeed;
    [SerializeField] private Transform _changePlayerPoint;

    private Vector3 _startPoint;
    private Vector3 _currentTarget;

    private void Start()
    {
        _startPoint = _camera.position;
        _currentTarget = _startPoint;
    }

    public void LoadMainScene(int mainScene)
    {
        SceneManager.LoadScene(mainScene);
    }
    public void StartGoingToChangePlayers()
    {
        _currentTarget = _changePlayerPoint.position;
        DisableMenuPanel();
    }
    
    private void DisableMenuPanel()
    {
        _mainMenuPanel.SetActive(false);
    }

    private void EnableMenuPanel()
    {
        _mainMenuPanel.SetActive(true);
    }

    private void Update()
    {
        _camera.position = Vector3.Lerp(_camera.position, _currentTarget, _swipeSpeed * Time.deltaTime);
    }
}
