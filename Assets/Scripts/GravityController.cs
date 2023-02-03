using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    const float Gravity=9.81f;
    public float gravityScale=1.0f;
    void Update()
    {
        Vector3 vector=new Vector3();
        //GetAxisは-1~1の値を返す
        vector.x=Input.GetAxis("Horizontal");
        vector.z=Input.GetAxis("Vertical");

        //zキーを押している間true
        if(Input.GetKey("z")){
            vector.y=1.0f;
        }else{
            vector.y=-1.0f;
        }
        //normalizedは長さを１にする。（方向キー同時押しで重力が強くなることを防止)
        Physics.gravity=Gravity*vector.normalized*gravityScale;
        
    }
}
