using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStoneGenerator : CGenerator
{
    protected override GameObject MakePrefab(Transform genPosition, int meteorType)
    {
        if (genPosition.childCount > 0)
        {
            return null;
        }
        return base.MakePrefab(genPosition, meteorType);
    }
}
