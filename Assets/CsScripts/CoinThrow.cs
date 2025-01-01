using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinThrow : MonoBehaviour
{
    Rigidbody rigit;
    Vector3 startPoint;
    Vector3 deltaPoint;
    Vector3 throwVec;
    Vector3 throwForce;
    Vector3 torqueVec;
    Vector3 torqueForce;
    Vector3 defPos;
    Vector3 objPos;
    Quaternion defRot;
    float upForce;
    float forceDebuff;
    float torqueBuff;

    void ResetTF(){
        transform.position = defPos;
        transform.rotation = defRot;
    }
    void Start()
    {
        rigit = GetComponent<Rigidbody>();
        rigit.maxAngularVelocity = 1000f;
        

        defPos = transform.position;
        defRot = transform.rotation;
        
        rigit.isKinematic = true;

        forceDebuff = 0.0003f;
        upForce = 0.008f;
    }

    void OnMouseDown(){
        rigit.isKinematic = true;

        torqueBuff = Random.Range(2f,4f);

        startPoint = Input.mousePosition;

        objPos = Camera.main.WorldToScreenPoint(transform.position);
    }
    void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);
        
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        deltaPoint = Input.mousePosition;
        throwVec = (deltaPoint - startPoint) * forceDebuff;
        throwForce = new Vector3(throwVec.x, upForce, throwVec.y);

        torqueVec = (deltaPoint - startPoint) * torqueBuff;
        torqueForce = new Vector3(torqueVec.y, torqueVec.x, torqueVec.z);

        startPoint = Input.mousePosition;
    }
    void OnMouseUp(){
        Debug.Log(throwForce.y);
        if(throwForce.z > 0.0015f){
            rigit.isKinematic = false;
            rigit.AddForce(throwForce, ForceMode.Impulse);
            rigit.AddTorque(torqueForce, ForceMode.VelocityChange);
        }
        else{
            ResetTF();
        }
    }
    void Update()
    {
        if(transform.position.y < -1f){
            ResetTF();
        }
    }
}
