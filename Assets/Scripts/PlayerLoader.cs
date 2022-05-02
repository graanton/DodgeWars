using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class PlayerLoader : MonoBehaviour, ISceneLoadHandler<GameObject>   
{
    public GameObject playerPrefab { set; get; }
    [SerializeField] private GameObject _playerPrefabDefault;
    [SerializeField] private DynamicJoystick _moveControllerToPlayer;
    [SerializeField] private DynamicJoystick _attackControllerToPlayer;
    [SerializeField] private Button _dashButton;

    private GameObject spawnedPlayer;

    public void OnSceneLoaded(GameObject player)
    {
        playerPrefab = player;
        SpawnPlayer();
    }

    private void Awake()
    {
        if (playerPrefab == null)
        {
            playerPrefab = _playerPrefabDefault;
            SpawnPlayer();
        }
        _dashButton.onClick.AddListener(spawnedPlayer.GetComponent<PlayerMove>().StartDashing);
    }

    private void SpawnPlayer()
    {
        spawnedPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        PlayerMove moveComponent = spawnedPlayer.GetComponent<PlayerMove>();
        PlayerAttack attackComponent = spawnedPlayer.GetComponent<PlayerAttack>();

        moveComponent._moveController = _moveControllerToPlayer;
        attackComponent._attackController = _attackControllerToPlayer;
    }
}
