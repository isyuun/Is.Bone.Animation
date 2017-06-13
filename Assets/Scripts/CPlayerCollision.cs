using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerCollision : CHumanCollision
{
    public CPlayerHealth _playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(this.GetMethodName() + ":" + collision + ":" + collision.tag);

        if (collision.tag.Equals("Zombie"))
        {
            Hit();
        }
    }

    protected override void Hit()
    {
        base.Hit();
        _playerHealth.HpDown();
    }
}

