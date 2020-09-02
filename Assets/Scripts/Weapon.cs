using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] loadout;
    public Transform weaponParent;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Equip(0);
    }

    void Equip (int p_ind)
    {
        GameObject t_newEquipment = Instantiate(loadout[p_ind], weaponParent.position, weaponParent.rotation, weaponParent) as GameObject;
        t_newEquipment.transform.localPosition = Vector3.zero;
        t_newEquipment.transform.localEulerAngles = Vector3.zero;
    }
}
