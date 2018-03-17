using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public enum AMMO_TYPE
    {
        AMMO1
    }

    Dictionary<AMMO_TYPE, int> ammoInvenotry = new Dictionary<AMMO_TYPE, int>();

    // Use this for initialization
    void Start () {
		ammoInvenotry.Add(AMMO_TYPE.AMMO1, 100);
	}
	
}
