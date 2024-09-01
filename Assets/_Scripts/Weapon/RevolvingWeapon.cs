using UnityEngine;

public class RevolvingWeapon : Weapon, IActiveCheck
{
    public int id;
    public int prefabId;    
    public int count;
    public float speed;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }

    public override void LevelUp()
    {
        base.LevelUp();
        count++;
        Devide();
    }

    public void Init()
    {
        speed = 150;
        Devide();
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
            bullet.GetComponent<BLBook>().Init(atk, -1);     // -1 is Infinity Per.
        }
    }
}
