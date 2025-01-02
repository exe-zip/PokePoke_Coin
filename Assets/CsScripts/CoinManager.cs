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
    bool mistyMode;
    bool mistyFlag;

    public int setCount;

    public void MistyBool(){
        mistyMode = !mistyMode;
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
        if(mistyMode)setCount = 1;
    }

    public void CountPlus(bool side){
        if(mistyMode && side){
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
        mistyMode = false;
        mistyFlag = true;
    }

    void Update()
    {
        if(mistyMode && mistyFlag){
            setCount = 1;
            mistyFlag = false;
        }
        else if(!mistyMode && !mistyFlag){
            mistyFlag = true;
            countUI.SetActive(true);
        }

        if(mistyMode){
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
