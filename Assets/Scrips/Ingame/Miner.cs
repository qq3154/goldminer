using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer;

public class Miner : MonoBehaviour
{
    [SerializeField] float range;

    Animator animator;

    bool _ismove = false;
    float DirX;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        this.RegisterListener(EventID.OnHookRotate, (param) => OnHookRotate());
        this.RegisterListener(EventID.OnHookShoot, (param) => OnHookShoot());
        this.RegisterListener(EventID.OnUseBomb, (param) => OnUseBomb());
        this.RegisterListener(EventID.OnGrabItem, (param) => OnGrabItem((Item)param));

    }

    // Update is called once per frame
    void Update()
    {        
        if (_ismove)
        {
            if (Mathf.Abs(transform.position.x) <= range)
            {
                DirX = Input.GetAxis("Horizontal");
                this.transform.position += new Vector3(DirX, 0, 0) * Time.deltaTime * Player.instance.MoveSpeed;
            }

            if (this.transform.position.x > range)
            {
                Vector3 pos = transform.position;
                pos.x = range;
                transform.position = pos;
            }
            if (this.transform.position.x < -range)
            {
                Vector3 pos = transform.position;
                pos.x = -range;
                transform.position = pos;
            }
        }
    }

    void OnHookRotate()
    {
        _ismove = true;
        animator.Play("Idle");
        
    }    

    void OnHookShoot()
    {
        _ismove = false;
        animator.Play("Pulling");
    }
    
    void OnUseBomb()
    {
        animator.Play("Explode");
    }
    

    void OnGrabItem(Item item)
    {
        if( item.ID  == ItemConfig.ItemID.TNT)
        {
            animator.Play("Angry");
        }
        if(item.Detail.ItemWeight > 5 && Player.instance.Strenght == 1)
        {
            animator.Play("HeavyPulling");
        }
        
    }
   
}
