using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCoinCon : MonoBehaviour
{
    Rigidbody rg;
    bool endToss;
    [SerializeField]
    GameObject CM;
    int coinNum;
    bool onceFlag;
    MeshCollider coinCollider;
    void Start()
    {
        coinCollider = GetComponent<MeshCollider>();

        CM = GameObject.Find("CoinManager");

        endToss = false;
        onceFlag = true;

        coinNum = CM.GetComponent<CoinManager>().coinCount;

        rg = GetComponent<Rigidbody>();
        rg.maxAngularVelocity = 1000f;

        transform.eulerAngles = new Vector3(Random.Range(70f,110f), 0, 0);
        rg.AddTorque(0, 0.0005f, 0, ForceMode.Impulse);
    }

    void Update()
    {
        if(transform.position.y < 0.01f){
            endToss = true;
            rg.isKinematic = true;
        }

        if(endToss){
            coinCollider.enabled = false;

            Vector3 coinPos = CM.GetComponent<CoinManager>().coinOffset;

            for(int i = 0; i < coinNum / 3; i++){
                coinPos.z -= 0.38f; 
            }
            for(int j = 0; j < coinNum % 3; j++){
                coinPos.x += 0.38f;
            }

            if(onceFlag){
                CM.GetComponent<CoinManager>().CountPlus(transform.up.y > 0f);
                onceFlag = false;
            }

            transform.position += (coinPos - transform.position) * 0.1f;
        }
    }
}
