using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public CoinManager _coinManager;
     void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Coin>())
        {
            _coinManager.CollectCoin(other.GetComponent<Coin>());   
        }
    }
}
