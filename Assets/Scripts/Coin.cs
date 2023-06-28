using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _amount;

    public int Amount => _amount;

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
