using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public string targetTag;
    bool isHolding;

    //Getter
    public bool IsHolding(){
        return isHolding;
    }
    //isTriggerのコライダーに何かが侵入してきたときに動くメソッド
    //引数:侵入してきたcollider
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == targetTag){
            isHolding=true;
        }
    }
    //isTriggerなコライダーから物が出ていったときに動くメソッド
    void OnTriggerExit(Collider other){
        isHolding=false;
    }

    //isTriggerなコライダーに物が接触している間中動くメソッド
    void OnTriggerStay(Collider other){
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
        
        Vector3 direction=other.gameObject.transform.position-transform.position;
        direction.Normalize();

        if(other.gameObject.tag==targetTag){
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f,ForceMode.Acceleration);
        }else{
            r.AddForce(direction * 80.0f,ForceMode.Acceleration);

        }
    }
}
