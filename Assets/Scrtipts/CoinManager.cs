using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
   [SerializeField] public GameObject CoinPrefab;
   [SerializeField] public List<Coin> CoinsList = new List<Coin>();
   [SerializeField] public Text CoinsText;
    void Start()
    {
        for(int i=0; i<50; i++)
        {
            Vector3 position = new Vector3(Random.Range(-20f, 20f), 0.5f, Random.Range(-20f, 20f)); 
           GameObject newCoin =  Instantiate(CoinPrefab, position, Quaternion.identity);
            CoinsList.Add(newCoin.GetComponent<Coin>());
            UpdateText(); 
        }
    }
    public void CollectCoin(Coin coin)
    {   
        CoinsList.Remove(coin);
        Destroy(coin.gameObject);
        CoinsText.text = "Осталось собрать" + CoinsList.Count.ToString();
        UpdateText(); 
    }

    private void UpdateText()
    {
        CoinsText.text = "Осталось собрать" + " " + CoinsList.Count.ToString();
    }

    public Coin GetClosest(Vector3 point)
    {
        Coin closestCoin = null; 
        float minDistance = Mathf.Infinity; 
        for (int i= 0; i < CoinsList.Count; i++) {
            float distance = Vector3.Distance(point, CoinsList[i].transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                closestCoin = CoinsList[i]; 
            }
        }
        return closestCoin; 
    }
}
        