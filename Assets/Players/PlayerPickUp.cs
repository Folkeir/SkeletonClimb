using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public int Coins { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        Pickupable pickup = other.GetComponent<Pickupable>();

        if (pickup != null)
        {
            pickup.Collect(this);
        }
    }
    public void AddCoin(int amount)
    {
        Coins += amount;

        Debug.Log(name + " has " + Coins + " coins!");
    }
    public void ShowCoinAmount()
    {

    }
}