using UnityEngine;

public class Allbullet : MonoBehaviour
{
    public float damage;
    public int per;
    Rigidbody2D rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Init(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;

        if (per > -1)
        {
            rigid.velocity = dir;

        }
    }
    public void Init(float damage, int per, Vector2 dir)
    {
        this.damage = damage;
        this.per = per;



        rigid.AddForce(dir, ForceMode2D.Impulse);


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster") || per == -1)
            return;
        per--;
        if (per == -1)
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }

    }


}

