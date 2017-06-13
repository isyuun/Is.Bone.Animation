using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStoneCollision : _MonoBehaviour
{
    public int _score;

    public void Hit(bool isNotPick) // ICollision 인터페이스 구현
    {
        //Debug.Log(this.GetMethodName() + ":" + isNotPick);

        if (isNotPick) return;

        GameObject.Find("GameManager").SendMessage("ScoreUp", _score);

        Destroy(gameObject);
    }
}
