using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    [SerializeField] private GameObject _enemyPrefab;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        int currentPlayerCount = NetworkServer.connections.Count;
        GameObject player = Instantiate(playerPrefab, startPositions[currentPlayerCount % startPositions.Capacity].position, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.Spawn(enemy);
    }
}
