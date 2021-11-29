using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] puntos;
    public GameObject esfera;
    private Rigidbody2D rb2d;

    public float speed = 10000f;
    public int numeroPersonas = 0;
    public int numeroContagios = 0;
    public float segundos = 0;
    public bool start = false;
    int spawnIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {

      if (start){
        segundos += Time.deltaTime;
      }
      if (Input.GetKeyDown("space"))
        {
          numeroPersonas++;
            SapwnAEsfera();
        }

        if (Input.GetKeyDown(KeyCode.R))
         {
          Time.timeScale = 1;
             Application.LoadLevel(0);
         }

    }

    // Update is called once per frame
    void SapwnAEsfera()
    {
        if (spawnIndex ==  puntos.Length){
          spawnIndex = 0;
        }
        GameObject gameObj = Instantiate(esfera, new Vector3(puntos[spawnIndex].position.x, puntos[spawnIndex].position.y, 0), Quaternion.identity);
        rb2d = gameObj.GetComponent<Rigidbody2D>();
        
        if(spawnIndex == 0){
          rb2d.AddForce(Vector2.right * speed);
          rb2d.AddForce(Vector2.down * speed);
        }
        
        if(spawnIndex == 1){
          rb2d.AddForce(Vector2.right * speed);
          rb2d.AddForce(Vector2.down * speed);
        }

        if(spawnIndex == 2){
          rb2d.AddForce(Vector2.left * speed);
          rb2d.AddForce(Vector2.down * speed);
        }

        if(spawnIndex == 3){
          rb2d.AddForce(Vector2.right * speed);
          rb2d.AddForce(Vector2.up * speed);
        }

        if(spawnIndex == 4){
          rb2d.AddForce(Vector2.right * speed);
          rb2d.AddForce(Vector2.down * speed);
        }
        spawnIndex++;
    }
}
