using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MonsterSpawner spawner;
    public float speed = 0f;
    public float maxSpeed = .000001f;
    private Rigidbody2D rb2d;
    private SpriteRenderer render;
    private Collider2D colaider;
    private Animator anim;
    public bool enfermo = false;
    public GameObject area;

    public Vector3 gameObjectSreenPoint;
    public Vector3 mousePreviousLocation;
    public Vector3 mouseCurLocation;
    public Vector3 force;
    public Vector3 objectCurrentPosition;
    public Vector3 objectTargetPosition;


    void OnMouseOver () 
    {
        if(Input.GetMouseButtonDown(1)){
          if (enfermo){
            spawner.numeroContagios--;
          }else{
            spawner.numeroContagios++;
            spawner.start = true;
          }
            enfermo = !enfermo;
        }

        if (Input.GetMouseButtonDown(0)){

          //This grabs the position of the object in the world and turns it into the position on the screen
         gameObjectSreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
         //Sets the mouse pointers vector3
         mousePreviousLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObjectSreenPoint.z);

          /* var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
          var mouseDir = mousePos - gameObject.transform.position;
          mouseDir.z = 0.0f;
          mouseDir = mouseDir.normalized;
          rb2d.AddForce(mouseDir * speed, ForceMode2D.Impulse);
          float limitSpeedX = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
          float limitSpeedY = Mathf.Clamp(rb2d.velocity.y, -maxSpeed, maxSpeed);
          rb2d.velocity = new Vector2(limitSpeedX, limitSpeedY); */
        }
    }

    void OnMouseDrag()
     {
         mouseCurLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, gameObjectSreenPoint.z);
         force = mouseCurLocation - mousePreviousLocation;//Changes the force to be applied
         mousePreviousLocation = mouseCurLocation;
     }

     public void OnMouseUp()
     {
         //Makes sure there isn't a ludicrous speed
         if (rb2d.velocity.magnitude > maxSpeed)
            force = rb2d.velocity.normalized * maxSpeed;
        rb2d.velocity = force;
        float limitSpeedX = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
          float limitSpeedY = Mathf.Clamp(rb2d.velocity.y, -maxSpeed, maxSpeed);
          rb2d.velocity = new Vector2(limitSpeedX, limitSpeedY); 
     }

    void empujar(int direccion){
          if (direccion == 0){
            rb2d.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
          }
          if (direccion == 2){
            rb2d.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
          }
          if (direccion == 3){
            rb2d.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
          }
          if (direccion == 4){
            rb2d.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
          }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        colaider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
      anim.SetBool("sano", !enfermo);
      if (enfermo){
          colaider.enabled = true;
          area.SetActive(true);
        } else {
          colaider.enabled = false;
          area.SetActive(false);
        }

        if (spawner.numeroPersonas == spawner.numeroContagios && spawner.numeroPersonas > 1){
          Time.timeScale = 0;
        }
    }

    void FixedUpdate(){

        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.997f;
        fixedVelocity.y *= 0.997f;
        rb2d.velocity = fixedVelocity;
      
    }

}
