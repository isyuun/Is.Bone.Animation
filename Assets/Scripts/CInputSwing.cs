using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInputSwing : _MonoBehaviour
{
    public Animator _animator;

    public Transform _attackPoint; // 공격 타격 위치 포인트

    public int _attackTargetMask; // 충돌 대상 레이어 마스크

    public CWeaponChange _weaponChange; // 무기 변경

    // Use this for initialization
    private void Start()
    {
        string[] maskName = { "Zombie", "Stone" };
        _attackTargetMask = LayerMask.GetMask(maskName);
    }

    // Update is called once per frame
    private void Update()
    {
        AnimatorStateInfo animState = _animator.GetCurrentAnimatorStateInfo(0);

        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKey(KeyCode.LeftControl)) &&
            (!animState.IsName("Swing")) && (!animState.IsName("Die")))
        {
            // 스윙 애니메이션을 실행 해라
            _animator.SetTrigger("Swing");
        }
        else
        {
            _animator.ResetTrigger("Swing");
        }
    }

    // 스윙 공격(타격) 애니메이션 이벤트
    public void SwingAttackAnimEvent()
    {
        // Collider2D 충돌대상 = Physics2D.OverlapCircle(
        //                          오버랩충돌체크위치, 검출범위, 검충대상레이어);

        // 지정한 공격 타겟 레이어를 가진 오브젝트와 공격 포인트를 기준으로
        // 충돌 되었는지를 검출함
        Collider2D[] hitCollision = Physics2D.OverlapCircleAll(_attackPoint.position, 0.4f, _attackTargetMask);

        // 충돌되는 오브젝트가 없음
        if (hitCollision == null) return;

        //Debug.Log(this.GetMethodName() + ":" + hitCollision + ":" + hitCollision.tag);

        // 개선3 : SendMessage(..)
        //hitCollision.SendMessage("Hit", _weaponChange._sword.activeSelf);
        foreach (Collider2D item in hitCollision)
        {
            item.SendMessage("Hit", _weaponChange._sword.activeSelf);
        }
    }
}
