using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    public GameObject fruitSliced;
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Blade"){
            Instantiate(fruitSliced, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
