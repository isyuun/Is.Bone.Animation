using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CZombieCollision : CHumanCollision
{
    private CZombieMovement _zombieMovement;

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        _zombieMovement = GetComponent<CZombieMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public override void Hit(bool isSword)
    {
        //Debug.Log(this.GetMethodName() + ":" + isSword);

        // 좀비를 피격한 무기가 칼이 아닐 경우
        if (!isSword) return;

        // 피격 효과를 수행함
        StartCoroutine("HitAnimCoroutine");

        _zombieMovement.Flip(); // 방향을 전환함
        _zombieMovement.SpeedUp(2.5f); // 2.5배 속도로 이동 속도를 증가 시킴
    }

}
