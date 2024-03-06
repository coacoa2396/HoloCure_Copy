using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    int hp;
    int maxHp;
    int atk;
    public int HP { get { return hp; } set { hp = value; } }
    public int MaxHP { get { return maxHp; } set { maxHp = value; } }
    public int ATK { get { return atk; } set { atk = value; } }

    protected abstract void TakeDamage(int damage);

    protected virtual void Tracing(PlayerController player)
    {

    }

    protected virtual void Hit(PlayerController player)
    {

    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (!(collision.gameObject.transform.tag == "Player"))
            return;

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        Hit(player);
    }
}
