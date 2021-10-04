using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityManager : MonoBehaviour
{

    public GameObject obj1,obj2;

    Animator anim1,anim2;

    public float InteractionDistance;

    bool isFighting = false;
    
    void Start()
    {   
        // obj1=GameObject.Find("Cactus");
        // obj2=GameObject.Find("Cactus2");
        anim1=obj1.GetComponent<Animator>();
        anim2=obj2.GetComponent<Animator>();
        
        StartCoroutine("CheckDistance");
    }

    /*
    Each second, it marks isFighting to true or false by checking if the distance between objects
    is smaller than the given InteractionDistance
    */
    IEnumerator CheckDistance(){

        while(true){
           if(obj1.activeSelf && obj2.activeSelf){
            if(Vector3.Distance(obj1.transform.position,obj2.transform.position)<InteractionDistance){
                
                isFighting=true;
                
            }
            else{
                
                isFighting=false;
            }

           }else
            isFighting=false;

            
            yield return new WaitForSeconds(1);
        }


     }

    /*
    Each frame, based on if the object is active in scene and the isFighting attribute, plays a certain animation... walk/attack
    */
    void Update(){
        if(obj1.activeSelf)
            if(isFighting)
                anim1.Play("Base Layer.Attack");
            else
                anim1.Play("Base Layer.Walk");

        if(obj2.activeSelf)
            if(isFighting)
                anim2.Play("Base Layer.Attack");
            else
                anim2.Play("Base Layer.Walk");
    }
}
