using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMovement : _MonoBehaviour {
    public float _speed; // 속도

    public bool _isRightFace; // 시선

    protected Animator _animator;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // 캐릭터 수평 반전
    public void Flip()
    {
        // Transform의 스케일 벡터 받음
        Vector3 scale = transform.localScale;
        // 시선 반전
        scale.x = scale.x * (-1); // scale.x *= -1;
        transform.localScale = scale;

        // 시선값 반전
        _isRightFace = !_isRightFace;
    }

}
