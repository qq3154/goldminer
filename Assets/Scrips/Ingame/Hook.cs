using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer;

public class Hook : MonoBehaviour
{
    [Header("Input")]            
    [SerializeField] private GameObject ExplodeVFX;
    [SerializeField] private float _rotateSpeed = 2;
    [SerializeField] private float _speed;
    
    [Header("ShareData")]
    [SerializeField] ItemConfigMap itemConfigMap;    

    public enum State
    {
        Rotate,
        Shoot,
        Rewind,
        NewBehavior,

    }
    
    LineRenderer _lineRenderer;

    Item item;

    float _angle = 0;
    Vector3 _orginalPos;
    State _gameState;             
    bool isHookEmpty;

    private void Awake()
    {
        _orginalPos = transform.position;
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.startWidth = 0.022f;
        _gameState = State.Rotate;
    }


    // Start is called before the first frame update
    void Start()
    {
        
        this.PostEvent(EventID.OnHookRotate);
    }

    // Update is called once per frame
    void Update()
    {
        CheckState();        
    }

    void UpdateState(State _state)
    {
        _gameState = _state;
    }

    void CheckState()
    {
        switch (_gameState)
        {
            case State.Rotate:           
                Rotate();
                break;

            case State.Shoot:          
                Shoot();
                break;

            case State.Rewind:
                Rewind();                             
                break;

            default:
                Observer.Common.Assert(false, $"Not handle for [{_gameState.ToString()}]");
                break;
        }
    }

    void Rotate()
    {
        _angle += _rotateSpeed;
        if (_angle >= 80 || _angle <= -80)
        {
            _rotateSpeed *= -1;

        }
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward * Time.deltaTime);


        ////Start shoot the hook, call the event OnHookShoot, update state to Shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.PostEvent(EventID.OnHookShoot);
                      
            _orginalPos = transform.position;                                 
            Line_Renderer(0, 0);
            
            UpdateState(State.Shoot);
        }
        isHookEmpty = true;
        
    }

    void Shoot()
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        
        transform.position -= transform.up * _speed * Time.deltaTime;
        Line_Renderer(1, -0.1f);

        
        //// if hook reach it end, return the hook, call event OnHookFail, update state to Rewind
        if (Mathf.Abs(transform.position.x) > 4f || transform.position.y < -2.3f)
        {
            this.PostEvent(EventID.OnHookFail);

            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            UpdateState(State.Rewind);
                
        }
    }

    void Rewind()
    {

        transform.position = Vector3.MoveTowards(
            transform.position,
            _orginalPos,
            _speed * Time.deltaTime * Player.instance.Strenght);

        Line_Renderer(1, -0.1f);

        //Use bomb, call event OnUseBomb
        if (Input.GetKeyDown(KeyCode.DownArrow) && !isHookEmpty && Player.instance.Bomb != 0) 
        {
            this.PostEvent(EventID.OnUseBomb);
                                
            GameObject clone = Instantiate(gameObject);
            clone.transform.position = gameObject.transform.position;            
            ExplodeAnimation(clone);
            
            _speed = 2;                         //set the speed of the hook to normal            
            isHookEmpty = true;                 //not calculate score

        }

        ////Hook return to start position, call event OnScore to calculate score
        if (transform.position.y >= _orginalPos.y)
        {                        
            if (!isHookEmpty)
            {
                this.PostEvent(EventID.OnScore,item);                                                
            }

            ////Update state to Rotate, call event OnHookRotate
            this.PostEvent(EventID.OnHookRotate);
            UpdateState(State.Rotate);            
            transform.position = _orginalPos;   // return to the original position           
            _speed = 2;                         //set the speed of the hook back to normal
        }
    }
    
    ////Get the detail of grabbed item, call event OnGrabItem
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

        item.ID = collision.gameObject.GetComponent<ItemConfig>().GetID();
        item.Detail = itemConfigMap.GetValueFromKey(item.ID);        
        
        
        this.PostEvent(EventID.OnGrabItem, item);

        isHookEmpty = false;               
        _speed /= item.Detail.ItemWeight;

        if (item.ID == ItemConfig.ItemID.TNT)
        {             
            TNTexplode(collision.gameObject);                
        }
        else
        {

        }

        Destroy(collision.collider.gameObject);                    
        UpdateState(State.Rewind);            
        
        
    }


    void Line_Renderer(int i, float zPostion)
    {
        Vector3 currPos = transform.position;
        currPos.z = zPostion;
        _lineRenderer.SetPosition(i, currPos);
    }

    void ExplodeAnimation(GameObject obj)
    {
        GameObject clone = Instantiate(ExplodeVFX);
        clone.transform.position = obj.transform.position;
        clone.GetComponent<Animator>().Play("Explode");
        Destroy(clone, 0.4f);
        Destroy(obj);
    }
    

    void TNTexplode(GameObject gameobj)
    {
        Collider2D[] nearBy = Physics2D.OverlapCircleAll(gameobj.gameObject.transform.position, 1, 1 << LayerMask.NameToLayer("Item"));
        
        // spawn explode prefab
        ExplodeAnimation(gameobj);
        foreach (Collider2D item in nearBy) 
        {
            
            if (item.gameObject.name != "Hook&Rope")
            {
                if (item.gameObject.GetComponent<ItemConfig>().GetID() != ItemConfig.ItemID.TNT)
                {
                    // spawn explode prefab
                    ExplodeAnimation(item.gameObject);
                    
                }
                else
                {
                    TNTexplode(item.gameObject);
                }
            }

        }
    }

}
