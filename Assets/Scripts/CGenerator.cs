using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGenerator : _MonoBehaviour {
    // 생성 위치들
    public Transform[] _genPositions;

    // 생성 지연 시간들
    public float _minGenDealyTime;

    public float _maxGenDealyTime;

    // 생성 오브젝트 프리팹
    public GameObject[] _genPrefabs;

    // Use this for initialization
    protected virtual void Start()
    {
        StartCoroutine("GenCoroutine");
    }

    private IEnumerator GenCoroutine()
    {
        while (true)
        {
            int genPosNum = Random.Range(0, _genPositions.Length);

            Transform genPosition = _genPositions[genPosNum];

            int meteorType = Random.Range(0, _genPrefabs.Length);

            MakePrefab(genPosition, meteorType);

            float delayTime = Random.Range(_minGenDealyTime, _maxGenDealyTime);

            yield return new WaitForSeconds(delayTime);
        }
    }

    protected virtual GameObject MakePrefab(Transform genPosition, int meteorType) 
    {
        GameObject prefab = Instantiate(_genPrefabs[meteorType], genPosition.position, Quaternion.identity);
        prefab.transform.SetParent(genPosition);
        return prefab;
    }
}
