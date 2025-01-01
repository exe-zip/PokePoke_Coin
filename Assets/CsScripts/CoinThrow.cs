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
    [SerializeField]
    float forceDebuff;
    float torqueBuff;
    void Start()
    {
        rigit = GetComponent<Rigidbody>();
        rigit.isKinematic = true;
        forceDebuff = 0.4f;
        torqueBuff = 10f;
    }

    void OnMouseDown(){
        rigit.isKinematic = true;

        startPoint = Input.mousePosition;
    }
    void OnMouseDrag()
    {
        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);
        
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        deltaPoint = Input.mousePosition;
        throwVec = (deltaPoint - startPoint) * forceDebuff;
        throwForce = new Vector3(throwVec.x, throwVec.y, throwVec.y);

        torqueVec = (deltaPoint - startPoint) * torqueBuff;
        torqueForce = new Vector3(torqueVec.y, torqueVec.x, torqueVec.z);

        startPoint = Input.mousePosition;
    }
    void OnMouseUp(){
        rigit.isKinematic = false;

        rigit.AddForce(throwForce, ForceMode.Impulse);
        rigit.AddTorque(torqueForce, ForceMode.Acceleration);
    }
    void Update()
    {
        
    }
}
