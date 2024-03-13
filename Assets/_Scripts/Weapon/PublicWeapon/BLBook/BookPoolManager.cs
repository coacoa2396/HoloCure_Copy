using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPoolManager : MonoBehaviour
{
    public GameObject[] prefabs;    // 프리팹을 보관할 변수                        // 인스펙터에서 초기화
    List<GameObject>[] pools;       // 각 프리팹을 넣어서 관리할 리스트의 배열

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
            pools[index] = new List<GameObject>();
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
