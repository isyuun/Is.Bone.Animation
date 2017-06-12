using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CZombieGenerator : CGenerator
{
    public int _zombieCount = 0; // 좀비 생성 카운트

    protected override GameObject MakePrefab(Transform genPosition, int meteorType)
    {
        GameObject zombie = base.MakePrefab(genPosition, meteorType);
        if (zombie != null)
        {
            zombie.GetComponent<CSortingOrder>().InitSorting(_zombieCount);
        }
        return zombie;
    }
}
