using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabid;
    public float damage;
    public float speed;
    public int level;
    
    [Header("# Colldown #")]
    [Range(0.1f, 5)]
    [SerializeField] public float Colldown;
    float colldown;
    [Header("# Levelup # Bouns")]
    [Range(1, 2)]
    [SerializeField] public float damagebouns;
    [Range(1, 2)]
    [SerializeField] public int weaponslot;
    [Range(0.8f, 1)]
    [SerializeField] public float colldownbouns;

    [Header("# Axe setting #")]
    [SerializeField] public float Angle;
    
    // Update is called once per frame
    PlayerStats player;
    WaitForSeconds wait = new WaitForSeconds(3f);
    WaitForSeconds axewait = new WaitForSeconds(0.5f);
    private void Awake()
    {
        player = GetComponentInParent<PlayerStats>();
        
    }
    private void Start()
    {
        Init();
    }
    void Update()
    {
        switch (id)
        {
            case 0: //ȸ����
                transform.Rotate(Vector3.forward * speed * Time.deltaTime);
                break;
            case 1: //���̾
                colldown -= Time.deltaTime;
                //Debug.Log(colldown);
                if (colldown < 0) 
                    
                {
                    colldown = Colldown;
                    shoot();
                }
                break;
            case 2: //����
                colldown -= Time.deltaTime;
                Debug.Log(colldown);
                if(colldown < 0)
                {
                    colldown = Colldown; 
                    StartCoroutine(axeinterval());

                   
                }
                break;
            default:
                break;
        }
        if(Input.GetButtonDown("Jump")) //������.
        {
            Levelup(damagebouns, weaponslot,colldownbouns);
        }
    }

    public void Levelup(float damage , int level , float colldown)
    {
       this.damage *= damage;
        this.level += level;
        this.Colldown *= colldown;
        if(id == 0)
            rollattack();
    }
    public void Init()
    {

        switch (id)
        {
            case 0: //ȸ����
                speed = -150;
                rollattack();
                break;
            case 1: //���̾
                speed = 15f;
                
                break;
            default:
                break;
        }
    }
    public void rollattack()
    { 
    for(int i =0; i < level; i++)
        {
            Transform shovel;
            if (i < transform.childCount)
            {
                shovel = transform.GetChild(i);
            }
            else
            {
               shovel= SGameManager.instance.pool.Get(prefabid).transform;
                shovel.parent = transform;
            }
            shovel.parent = transform;

            shovel.localPosition = Vector3.zero;    
            shovel.localRotation = Quaternion.identity;

            Vector3 rovec = Vector3.forward * 360 * i / level;
            shovel.Rotate(rovec);
            shovel.Translate(shovel.up * 1.5f, Space.World);
            shovel.GetComponent<Allbullet>().Init(damage, -1, Vector3.zero);// -1�� ���Ѵ�  //�������̴��̶� �Ѿ��ÿ��� �ʿ�������� ���Ͱ� ���� 0������
        }
    }

   public  void shoot()
    {
        if (!player.scan.selecttarget)
            return;
        //transform.LookAt(player.scan.selecttarget.position);
        Vector3 targetpos = player.scan.selecttarget.position;
        Vector3 dir = targetpos - transform.position;
        dir = dir.normalized;
        Transform fireball = SGameManager.instance.pool.Get(prefabid).transform;
        fireball.position = transform.position;
        fireball.parent = transform;
        //fireball.rotation = Quaternion.identity;
        fireball.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        fireball.GetComponent<Allbullet>().Init(damage, level, dir * speed);
        StartCoroutine(couritine(fireball));
    }
    IEnumerator couritine(Transform value) // ������Ȱ��ȭ
    {
        yield return wait;
       value.gameObject.SetActive(false);
    }
    IEnumerator axeinterval()
    {
        float interval = colldown / 10;
        axewait = new WaitForSeconds(interval);
        for (int i = 0; i < level; i++)
        {
            
            
            yield return axewait;

            thorw();
        }
        
    }

    public void thorw()
    {
        Transform axe = SGameManager.instance.pool.Get(prefabid).transform;
        axe.position = transform.position;
        axe.parent = transform;
        Vector2 dir = new Vector2(Random.Range(-Angle, Angle+1), 100).normalized;
        axe.GetComponent<Allbullet>().Init(damage,-1, dir * speed); //-1�� ���Ѱ����������.
        StartCoroutine (couritine(axe));
    }
   ////public  float knockback() //�˹��ġ�� ������ ���ϴ� ��  //�������� �ִ°� �ƴѵ�?
   // {
   //    float value =this.damage ;
   //     return value;
   // }


}