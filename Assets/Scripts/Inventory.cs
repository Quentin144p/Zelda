using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private bool asKey;
    [SerializeField] Image keyBoolean;

    private void Awake()
    {
        asKey = false;
    }

    public void TakeKey()
    {
        asKey = true;
        keyBoolean.color = Color.green;
    }
}
