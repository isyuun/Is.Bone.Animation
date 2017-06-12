using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputMovement : CMovement
{
    // Update is called once per frame
    private void Update()
    {
        // 수평 키입력 여부 체크
        float h = Input.GetAxisRaw("Horizontal");

        // 만약에 대기나 걷기 상태가 아니면 이동 처리 코드를 수행하지 말아라
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        //if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Swing"))
        //if ((stateInfo.IsName("Idle") == false) && (stateInfo.IsName("Walk") == false))
        if (!stateInfo.IsName("Idle") && !stateInfo.IsName("Walk"))
        {
            return;
        }

        // 삼항연산자 : (조건) ? 참결론 : 거짓결론
        bool isWalk = (h == 0) ? false : true;
        _animator.SetBool("Walk", isWalk);

        // 만약(if) 왼쪽으로 보고 있는데(_isRightFace == false)
        // 오른쪽 키를 누르거나 (h > 0) ||
        // 오른쪽으로 보고 있는데(_isRightFace == true) 왼쪽 키를 누르면 (h < 0)
        if ((h > 0 && !_isRightFace) || (h < 0 && _isRightFace))
        {
            Flip(); // 캐릭터를 반전 해라
        }

        // 이동
        transform.Translate(Vector2.right * h * _speed * Time.deltaTime);
    }
}
