using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextController : MonoBehaviour
{

    public Text txt;
    public MonsterSpawner spawn;

    // Start is called before the first frame update
    void Start()
    {
        
        txt = GameObject.Find("Texto").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "No. Personas: " +  spawn.numeroPersonas + "\nNo. Contagios: " +  spawn.numeroContagios + "\n\n" +  spawn.segundos + " seg.\ndesde el primer contagio";
    }
}
