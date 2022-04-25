using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MapSavingLoading : MonoBehaviour
{
    [SerializeField] private List<Map> item;

    private const string _mapDataName = "/Data/Maps.json";

    [ContextMenu("Load")]
    public void Load()
    {
        item.Add(JsonUtility.FromJson<Map>(File.ReadAllText(Application.streamingAssetsPath + _mapDataName)));
    }

    [ContextMenu("Save")]
    public void Save()
    {
        File.WriteAllText(Application.streamingAssetsPath + _mapDataName, JsonUtility.ToJson(item));
    }
    [System.Serializable]
    public class Map
    {
        public string name;
        public GameObject[] objectPrefabs;
    }
}
