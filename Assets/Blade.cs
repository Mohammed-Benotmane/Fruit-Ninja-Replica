using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;
    GameObject currentBladeTrail;
    bool isCutting = false;
    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circle;
    Vector2 previousPosition;
    public float minCuttingVelocity = .001f;    

    void Start(){
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            StartCutting();
        }else if(Input.GetMouseButtonUp(0)){
            StopCutting();
        }   

        if(isCutting){
            UpdateCut();
        }    
    }

    void UpdateCut(){
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;
        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if(velocity > minCuttingVelocity){
            circle.enabled = true;
        }else{
            circle.enabled = false;
        }
    }

    void StartCutting(){
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab,transform);
        circle.enabled = false;
        
    }

    void StopCutting(){
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circle.enabled = false;
    }

}
