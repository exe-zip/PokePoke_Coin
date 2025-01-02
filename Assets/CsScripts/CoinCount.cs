using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    [SerializeField]
    GameObject CounterText1;
    [SerializeField]
    GameObject CounterText2;
    int coinCount1;
    int coinCount2;

    public void CountUp1(){
        coinCount1++;
    }

    public void CountUp2(){
        coinCount2++;
    }

    public void CountReset(){
        coinCount1 = 0;
        coinCount2 = 0;
    }

    void Start()
    {
        CountReset();
    }

    void Update()
    {
        CounterText1.GetComponent<TextMeshProUGUI>().text = coinCount1.ToString();
        CounterText2.GetComponent<TextMeshProUGUI>().text = coinCount2.ToString();
    }
}
