using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer;

public class SoundManager : MonoSingleton<SoundManager>
{
    [Header("Input")]
    [SerializeField] public AudioClip StartLevel;
    [SerializeField] public AudioClip EndLevel;
    [SerializeField] public AudioClip HookShoot;
    [SerializeField] public AudioClip HookRewind;
    [SerializeField] public AudioClip Score;
    [SerializeField] public AudioClip GrabHighValueGold;
    [SerializeField] public AudioClip GrabDiamond;
    [SerializeField] public AudioClip GrabNothing;
    [SerializeField] public AudioClip Explode;
    [SerializeField] public AudioClip Buy;

    GameObject _loopSound;

    

    public override void Init()
    {
        this.RegisterListener(EventID.OnHookShoot, (param) => OnHookShoot());
        this.RegisterListener(EventID.OnHookFail, (param) => OnHookFail());
        this.RegisterListener(EventID.OnUseBomb, (param) => OnUseBomb());
        this.RegisterListener(EventID.OnHookRotate, (param) => OnHookRotate());
        this.RegisterListener(EventID.OnGrabItem, (param) => OnGrabItem((Item)param));
        this.RegisterListener(EventID.OnScore, (param) => OnScore((Item)param));
        this.RegisterListener(EventID.OnBuyItem, (param) => OnBuyItem());

        
    }

    public void PlaySound(AudioClip clip)
    {
        GameObject soundObject = new GameObject();
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
        Destroy(soundObject, 2);


    }
    public GameObject PlayLoopSound(AudioClip clip)
    {
        GameObject soundObject = new GameObject();
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.pitch = 0.7f;
        audioSource.PlayDelayed(0.2f);
        
        return soundObject;
    }
    public void EndLoopSound(GameObject LoopSoundObject)
    {
        Destroy(LoopSoundObject);
    }



    void OnHookRotate()
    {
        
        EndLoopSound(_loopSound);
    }


    void OnHookShoot()
    {
        
        PlaySound(HookShoot);
    }

    void OnHookFail()
    {
        
        PlaySound(GrabNothing);
    }

    void OnUseBomb()
    {
        
        PlaySound(Explode);
        EndLoopSound(_loopSound);
    }

    void OnGrabItem(Item item)
    {
        
        if (item.ID == ItemConfig.ItemID.Gold4)
        {
            
            PlaySound(GrabHighValueGold);
        }
        if (item.ID == ItemConfig.ItemID.Diamond)
        {
            
            PlaySound(GrabDiamond);
        }
        if (item.ID == ItemConfig.ItemID.TNT)
        {
            
            PlaySound(Explode);
        }
        else
        {
            _loopSound = PlayLoopSound(HookRewind);
        }
        
    }

    void OnScore(Item item)
    {
        if (item.ID != ItemConfig.ItemID.TNT)
        {
            
            PlaySound(Score);
        }
    }

    void OnBuyItem()
    {
        PlaySound(Buy);
    }
}
            