using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinThrow : MonoBehaviour
{
    float objPosZ;
    bool dragflag;
    void Start()
    {
        objPosZ = transform.position.z;  
        dragflag = false; 
    }

    void OnMouseDown(){
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void OnMouseUp(){
        GetComponent<Rigidbody>().isKinematic = false;
    }
    void OnMouseDrag()
    {
        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    void Update()
    {
        
    }
}
