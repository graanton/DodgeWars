using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _swipeSpeed;
    [SerializeField] private Transform _changePlayerPoint;

    public void LoadMainScene(int mainScene)
    {
        SceneManager.LoadScene(mainScene);
    }
    public void StartGoingToChangePlayers()
    {
        DisableMenuPanel();
        StartCoroutine(GoingToChangePlayer());
    }
    
    private void DisableMenuPanel()
    {
        _mainMenuPanel.SetActive(true);
    }

    private void EnableMenuPanel()
    {
        _mainMenuPanel.SetActive(false);
    }

    private IEnumerator GoingToChangePlayer()
    {
        while (Vector3.Distance(_camera.position, _changePlayerPoint.position) != 0)
        {
            _camera.position = Vector3.Lerp(_camera.position, _changePlayerPoint.position, _swipeSpeed * Time.fixedDeltaTime);
            yield return null;
        }
        
    }
}
