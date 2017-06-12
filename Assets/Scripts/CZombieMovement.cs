using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CZombieMovement : CMovement
{
    protected override void Start()
    {
        base.Start();

        // 좀비가 생성된 위치가 왼쪽일 경우
        if (transform.position.x < 0)
        {
            Flip(); // 캐릭터를 반전 시킴
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // 지정된 시선의 방향으로 이동함
        transform.Translate(Vector2.right *
            ((_isRightFace) ? 1 : -1) * _speed * Time.deltaTime);

        // 좀비의 위치가 10을 넘어가면 파괴하라
        if (Mathf.Abs(transform.position.x) > 10) Destroy(gameObject);
    }

    // 속도 업!!
    public void SpeedUp(float upValue)
    {
        _speed *= upValue;
        _animator.speed = 1.5f;
    }
}
