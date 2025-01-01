using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextCon : MonoBehaviour
{
    [SerializeField]
    GameObject uiText;
    [SerializeField]
    GameObject CM;
    void Start()
    {
        
    }

    void Update()
    {
        uiText.GetComponent<TextMeshProUGUI>().text = CM.GetComponent<CoinManager>().setCount. ToString();
    }
}
