using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Enemy Wave Config")]

public class WaveConfig : ScriptableObject
{
   [SerializeField] GameObject EnemyPrefab;
   [SerializeField] GameObject PathPrefab;
   [SerializeField] float TimeBetweenSpawns = 0.5f;
   [SerializeField] float MoveSpeed = 2f;
   [SerializeField] int NumberOfEnemies = 7;

   public GameObject GetEnemyPrefab() {return EnemyPrefab;}
   public List<Transform> GetWaypoints()
   {
     var WaveWayPoints =new List<Transform>();
     foreach (Transform Child in PathPrefab.transform)
     {
       WaveWayPoints.Add(Child);
     }
     return WaveWayPoints;
   }
   public float GetTimeBetweenSpawns() {return TimeBetweenSpawns;}
   public float GetMoveSpeed() {return MoveSpeed;}
   public int GetNumberOfEnemies() {return NumberOfEnemies;}
}
