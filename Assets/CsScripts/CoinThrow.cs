using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField]
    float deltaStop;
    [SerializeField]
    int coinState;

    void ResetTF(){
        rigit.isKinematic = true;
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

        coinState = 0;
    }

    void OnMouseDown(){
        rigit.isKinematic = true;

        torqueBuff = Random.Range(2f,3f);

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

        if(transform.position.y < 0.01f && transform.position.y > 0f){
            deltaStop++;
        }
        else{
            deltaStop = 0f;
        }
        
        if(deltaStop > 500f){
            if(transform.up.y > 0f){
                coinState = 1;
            }
            else{
                coinState = 2;
            }
        }
        else{
            coinState = 0;
        }
    }
}
