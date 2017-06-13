using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHumanCollision : _MonoBehaviour
{
    // 모든 본 부위의 스프라이트 렌더러를 참조
    protected SpriteRenderer[] _spriteRenderers;

    // Use this for initialization
    protected virtual void Start()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public virtual void Hit(bool isSword)
    //public override void Hit(bool isSword)
    {
        //Debug.Log(this.GetMethodName() + ":" + isSword);

        // 피격 효과를 수행함
        StartCoroutine("HitAnimCoroutine");
    }

    protected virtual void Hit()
    {
        //Debug.Log(this.GetMethodName());

        // 피격 효과를 수행함
        StartCoroutine("HitAnimCoroutine");
    }

    // 피격 색상 변경 지연 처리
    protected IEnumerator HitAnimCoroutine()
    {
        // Color color = new Color(R, G, B, A);
        //SetColor(Color.red); // 붉은색 피격 효과를 설정함
        SetColor(new Color(1f, 0f, 0f)); // 붉은색 피격 효과를 설정함 (1 => 255)

        yield return new WaitForSeconds(0.1f); // 0.1초 지연함

        SetColor(Color.white); // 원래 색상으로 설정함
    }

    // 색상 변경
    protected void SetColor(Color color)
    {
        // 본 스프라이들의 색상을 지정한 색상으로 변경함
        foreach (SpriteRenderer sr in _spriteRenderers)
        {
            sr.color = color;
        }
    }
}
