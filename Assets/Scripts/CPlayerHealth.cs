using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerHealth : _MonoBehaviour
{
    public CGameManager _gameManager;
    public bool _isDie = false;

    public Image[] _hpImage;
    public int _hpCount = 3;

    public Animator _animator;

    Vector2 org;

    public void HpDown()
    {
        if (_isDie)
        {
            return;
        }
        _hpImage[--_hpCount].enabled = false;

        if (_hpCount <= 0)
        {
            Die();
        }
    }

    private void Reset()
    {
        Debug.Log(this.GetMethodName());
        _isDie = false;
        foreach (var item in _hpImage)
        {
            item.enabled = true;
        }
        _hpCount = 3;

        _animator.ResetTrigger("Die");
        _animator.SetBool("IsDie", _isDie);

        transform.position = this.org;

        DestroyPrefabs("Stone");
        DestroyPrefabs("Zombie");
    }

    private void DestroyPrefabs(String tag)
    {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject item in prefabs)
        {
            Destroy(item);
        }
    }

    private void Start()
    {
        this.org = transform.position;
        Reset();
    }

    public void DieAniComplete()
    {
        Debug.Log(this.GetMethodName());
        //_gameManager.EndGame();
    }

    private void Die()
    {
        Debug.Log(this.GetMethodName());
        _isDie = true;
        _animator.SetTrigger("Die");
        _animator.SetBool("IsDie", _isDie);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
        }        
    }
}
