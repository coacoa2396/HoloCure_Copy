using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterReposition : MonoBehaviour
{
    Collider2D coll;
    [SerializeField] PlayerController player;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);        

        if (coll.enabled)
        {
            Vector3 distance = playerPos - myPos;
            Vector3 randomPos = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
            transform.Translate(randomPos + distance * 2);
        }
    }
}
