using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinThrow : MonoBehaviour
{
    [SerializeField]
    GameObject CountUI;
    [SerializeField]
    GameObject MistyUI;
    [SerializeField]
    GameObject CoinUI;
    [SerializeField]
    GameObject UIM;
    Rigidbody rg;
    Vector3 startPoint;
    Vector3 deltaPoint;
    Vector3 throwVec;
    Vector3 throwForce;
    Vector3 torqueVec;
    Vector3 torqueForce;
    Vector3 defPos;
    Vector3 objPos;
    Quaternion defRot;
    public bool throwFlag;
    float upForce;
    float forceDebuff;
    float torqueBuff;
    [SerializeField]
    float deltaStop;
    [SerializeField]
    public int coinState;

    public void ResetTF(){
        CountUI.SetActive(true);
        MistyUI.SetActive(true);
        CoinUI.SetActive(false);

        rg.isKinematic = true;

        transform.position = defPos;
        transform.rotation = defRot;

        coinState = 0;

        throwFlag = false;

        GetComponent<MeshCollider>().enabled = true;
    }
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.maxAngularVelocity = 1000f;
        

        defPos = transform.position;
        defRot = transform.rotation;
        
        rg.isKinematic = true;

        forceDebuff = 0.0001f;
        upForce = 0.008f;

        coinState = 0;

        throwFlag = false;
    }

    void OnMouseDown(){
        if(!throwFlag){
            rg.isKinematic = true;

            torqueBuff = Random.Range(1f,2f);

            startPoint = Input.mousePosition;

            objPos = Camera.main.WorldToScreenPoint(transform.position);
        }
    }
    void OnMouseDrag()
    {
        if(!throwFlag){
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);
        
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            deltaPoint = Input.mousePosition;
            throwVec = (deltaPoint - startPoint) * forceDebuff;
            throwForce = new Vector3(throwVec.x, upForce, throwVec.y);

            torqueVec = (deltaPoint - startPoint) * torqueBuff;
            torqueForce = new Vector3(torqueVec.y, torqueVec.x, torqueVec.z);

            startPoint = Input.mousePosition;
        }
    }
    void OnMouseUp(){
        if(!throwFlag){
            if(throwForce.z > 0.0003f){
                CountUI.SetActive(false);
                MistyUI.SetActive(false);
                CoinUI.SetActive(true);

                rg.isKinematic = false;

                throwFlag = true;

                rg.AddForce(throwForce, ForceMode.Impulse);
                rg.AddTorque(torqueForce, ForceMode.VelocityChange);
            }
            else{
                ResetTF();
            }
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

        if(deltaStop > 100f){
            GetComponent<MeshCollider>().enabled = false;
            if(transform.up.y > 0f){
                rg.isKinematic = true;
                coinState = 1;
                UIM.GetComponent<CoinCount>().CountUp1();
            }
            else{
                rg.isKinematic =true;
                coinState = 2;
                UIM.GetComponent<CoinCount>().CountUp2();
            }
        }
    }
}
