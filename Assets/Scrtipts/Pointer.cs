using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] public CoinManager CoinManager;
    [SerializeField] public Coin ClosesCoin; 
    void Update()
    {
        ClosesCoin = CoinManager.GetClosest(transform.position);
        Debug.DrawLine(transform.position, ClosesCoin.transform.position); 
    }
}
