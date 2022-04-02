using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int EnemyHealth = 300;
    [SerializeField] float ShotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 1.5f;
    [SerializeField] float ProjectileSpeed = 10f;
    [SerializeField] GameObject EnemyLaser;
    [SerializeField] [Range(0,1)] float EnemyDeathVolume = 0.5f;
    public AudioClip EnemyDeath;
    [SerializeField] [Range(0,1)] float EnemyLaserVolume = 0.5f;
    public AudioClip EnemyLaserclip;
    EnemySpawner Scoree;
    Player Death;

    void Start()
    {
      ShotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
      CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
       ShotCounter = ShotCounter - Time.deltaTime;
       if(ShotCounter <= 0f)
       {
        AudioSource.PlayClipAtPoint(EnemyLaserclip, Camera.main.transform.position, EnemyLaserVolume);
        GameObject Laser =  Instantiate(
         EnemyLaser,
         transform.position,
         Quaternion.identity
         ) as GameObject ;
        Laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-ProjectileSpeed);
        ShotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
       }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerLaser") == true)
        {
            EnemyHealth = EnemyHealth - 100;
            Destroy(collision.gameObject);
        }

      if(EnemyHealth<1)
      {
        Scoree=GameObject.FindGameObjectWithTag("SCORE").GetComponent<EnemySpawner>();
        Scoree.ScoreCounter();
        AudioSource.PlayClipAtPoint(EnemyDeath, Camera.main.transform.position, EnemyDeathVolume);
        Destroy(gameObject);
      }
    }
}
