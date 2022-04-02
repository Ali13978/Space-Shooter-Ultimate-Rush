using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  [Header("Movement")]
  [SerializeField] float moveSpeed = 10f;
  [SerializeField] float padding = 1f;
  [SerializeField] int PlayerHealth = 200;
  [Header("Player Laser")]
  [SerializeField] GameObject laserprefab;
  [SerializeField] float ProjectileSpeed = 10f;
  [SerializeField] float FiringPreiod = 0.1f;
  Coroutine FiringCoroutine;
  float xMin;
  float xMax;
  float yMin;
  float yMax;
  public AudioClip PlayerDeath;
  [SerializeField] [Range(0,1)] float PlayerDeathvolume = 0.5f;
      // Start is called before the first frame update
    void Start()
    {
      SetUpMoveBoundaries();
    }

    // Update is called once per frame

    void Update()
    {
      Move();
      Fire();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Enemy") == true)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Win");
        }

        if (collision.CompareTag("EnemyLaser") == true)
        {
            PlayerHealth = PlayerHealth - 100;
            Destroy(collision.gameObject);
        }

        if (PlayerHealth < 1)
        {
            AudioSource.PlayClipAtPoint(PlayerDeath, Camera.main.transform.position, PlayerDeathvolume);
            Destroy(gameObject);
            SceneManager.LoadScene("Win");
        }

    }

    private void SetUpMoveBoundaries()
    {
      Camera gameCamera = Camera.main;
      xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
      xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;

      yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y + padding;
      yMax = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y - padding;
    }

    private void Move()
    {
      var DeltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed ;
      var DeltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed ;

      var NewxPos = Mathf.Clamp(transform.position.x + DeltaX, xMin, xMax);
      var NewyPos = Mathf.Clamp(transform.position.y + DeltaY, yMin, yMax);
      transform.position = new Vector2(NewxPos,NewyPos);
    }

    private void Fire()
    {
      if (Input.GetButtonDown("Fire1"))
      {
        FiringCoroutine = StartCoroutine(FireContiniously());
      }
      if (Input.GetButtonUp("Fire1"))
      {
        StopCoroutine(FiringCoroutine);
      }
    }

    IEnumerator FireContiniously()
    {
      while (true)

      {
        GameObject laser = Instantiate(laserprefab,transform.position,Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,ProjectileSpeed);
        yield return new WaitForSeconds(FiringPreiod);
      }
    }
}
