using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolvingWeapon : Weapon, IActiveCheck
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    

    private void Start()
    {
        Init(); 
    }

    private void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }

        // test
        if (Input.GetKeyDown(KeyCode.Space))
        {           
            LevelUp(10, 1);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage += damage;
        this.count += count;

        if (id == 0)
        {            
            Devide();            
        }
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;
                Devide();
                break;
            default:
                break;
        }
    }

    
            
    void Devide()
    {
        for (int i = 0; i < count; i++)
        {
            Transform bullet;
            if (i < transform.childCount)
            {                
                bullet = transform.GetChild(i);
            }
            else
            {                
                bullet = BookManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }


            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<BLBook>().Init((int)damage, -1);     // -1 is Infinity Per.

        }
    }
}
