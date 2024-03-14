using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPoolManager : MonoBehaviour
{
    public GameObject[] prefabs;    // �������� ������ ����                        // �ν����Ϳ��� �ʱ�ȭ
    List<GameObject>[] pools;       // �� �������� �־ ������ ����Ʈ�� �迭

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