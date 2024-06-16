using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource CoinFX;
    void OnTriggerEnter(Collider other)
    {
        CoinFX.Play();
        CollectableControl.coinCount += 1;
        this.gameObject.SetActive(false) ;
    }
}
