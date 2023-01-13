using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    public Transform GetStartingWaypoin(){
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWaypoints(){
        List<Transform> Waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            Waypoints.Add(child);
        }
        return Waypoints;
    }
    public float GetMoveSpeed(){
        return moveSpeed;
    }
    public int GetEnemyCount(){
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefab(int index){
        return enemyPrefabs[index];
    }

}
