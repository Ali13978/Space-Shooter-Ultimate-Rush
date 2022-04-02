using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
  WaveConfig waveconfig;
  List<Transform> waypoints;
  int NextPosIndex = 0;
  Transform NextPos;
    bool Journeyfinish = false;
    // Start is called before the first frame update
    void Start()
    {
      waypoints = waveconfig.GetWaypoints();
      transform.position = waypoints[NextPosIndex].transform.position;
      NextPos = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Journeyfinish == true)
        {
            Destroy(gameObject);
        }
        else
        {
            Move();
        }
    }

    public void SetWaveConfig(WaveConfig WaveConfig)
    {
      this.waveconfig = WaveConfig;
    }

    void Move()
    {
        if (Journeyfinish == false)
        {
            if (transform.position == NextPos.position)
            {
                NextPosIndex++;
                if (NextPosIndex >= waypoints.Count)
                {
                    Journeyfinish = true;
                    return;
                }
                NextPos = waypoints[NextPosIndex];
            }
            else
            {
                var Speed = waveconfig.GetMoveSpeed() * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, NextPos.position, Speed);
            }
        }
    }
}
