using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehaviour : MonoBehaviour
{
    public GameObject fruitSliced;
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Blade"){
            Vector3 direction = (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Instantiate(fruitSliced, transform.position, rotation);
            Destroy(gameObject);

        }
    }
}
