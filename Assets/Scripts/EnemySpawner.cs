using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
  [SerializeField] List<WaveConfig> waves;
  [SerializeField] int WAVEINDEX;
  [SerializeField] bool looping = false;
  [SerializeField] int Score = 0;
  public TextMeshProUGUI Scorew;
  int HighScore = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {

        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping == true);

    }


    void Update()
    {
      Scorew.text = (Score.ToString());
    }

    private IEnumerator SpawnAllWaves()
    {
       for (WAVEINDEX = 0; WAVEINDEX <= 90; WAVEINDEX++)
       {
         if(WAVEINDEX >= waves.Count)
         {
           WAVEINDEX = 0;
         }

         var CurrentWave= waves[WAVEINDEX];
         yield return StartCoroutine (SpawnAllEnemiesInWave(CurrentWave));
       }
    }

    public void ScoreCounter()
    {
        if (!PlayerPrefs.HasKey("Score1"))
        {
            PlayerPrefs.SetInt("Score1", Score);
        }
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", HighScore);
        }

        Score = Score + 10;
        PlayerPrefs.SetInt("Score1", Score);

        if (Score>PlayerPrefs.GetInt("HighScore"))
        {
            HighScore = Score;
            PlayerPrefs.SetInt("HighScore", Score);
        }

    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig WaveConfig)
    {
      for (int i =1;i<=WaveConfig.GetNumberOfEnemies(); i++)
      {
        var newEnemy =Instantiate(WaveConfig.GetEnemyPrefab(),
        WaveConfig.GetWaypoints()[0].transform.position,
        Quaternion.identity);
        newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(WaveConfig);
        yield return new WaitForSeconds(WaveConfig.GetTimeBetweenSpawns());
      }
    }
}
