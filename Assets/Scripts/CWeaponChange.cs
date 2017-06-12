using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWeaponChange : _MonoBehaviour
{
    public GameObject _pick; // 곡갱이
    public GameObject _sword; // 칼

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            WeaponChange();
        }
    }

    void WeaponChange()
    {
        _sword.SetActive(!_sword.activeSelf);
        _pick.SetActive(!_pick.activeSelf);
    }
}
