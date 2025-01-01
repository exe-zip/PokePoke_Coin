using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    GameObject mainCoin;
    public Vector3 coinOffset;
    public int coinCount;
    bool onceFlag;

    public int setCount;

    public void SetCountPlus(){
        setCount++;
    }
    public void SetcountMinus(){
        if(setCount > 1){
            setCount--;
        }
    }

    public void CoinReset(){
        coinOffset = new Vector3(-0.38f, 1f, 0.2f);
        coinCount = 0;
        onceFlag = true;
    }

    public void CountPlus(){
        if(coinCount < setCount - 1){
            coinCount++;
        }
    }

    void Start()
    {
        CoinReset();
        setCount = 1;
    }

    void Update()
    {
        if(mainCoin.GetComponent<CoinThrow>().coinState > 0 && onceFlag){
            if(setCount != 1){
            coinCount++;
            onceFlag = false;
            }
        }
        
        if(coinCount > 6){
            coinOffset.z = 0.2f + ((coinCount - 3) / 3) * 0.38f;
        }
    }
}
