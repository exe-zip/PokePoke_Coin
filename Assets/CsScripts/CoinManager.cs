using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    GameObject mainCoin;
    [SerializeField]
    GameObject countUI;
    public Vector3 coinOffset;
    public int coinCount;
    bool onceFlag;
    bool miskyMode;
    bool miskyFlag;

    public int setCount;

    public void MiskyBool(){
        miskyMode = !miskyMode;
    }

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
        if(miskyMode)setCount = 1;
    }

    public void CountPlus(bool side){
        if(miskyMode && side){
            setCount++;
            coinCount++;
        }
        else if(coinCount < setCount - 1){
            coinCount++;
        }
    }

    void Start()
    {
        CoinReset();
        setCount = 1;
        miskyMode = false;
        miskyFlag = true;
    }

    void Update()
    {
        if(miskyMode && miskyFlag){
            setCount = 1;
            miskyFlag = false;
        }
        else if(!miskyMode && !miskyFlag){
            miskyFlag = true;
            countUI.SetActive(true);
        }

        if(miskyMode){
            countUI.SetActive(false);
            if(mainCoin.GetComponent<CoinThrow>().coinState == 1 && onceFlag){
                setCount++;
            }
        }
        else{
            
        }

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
