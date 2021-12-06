using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Observer;
public class StartLevel : MonoBehaviour
{
    [SerializeField] Text txt;
    
    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {        

        SoundManager.instance.PlaySound(SoundManager.instance.StartLevel);        
        Player.instance.Target += 100 * Random.Range(8,13 + Player.instance.Level * 2);               
        txt.text = $"Your target:\n {Player.instance.Target}";
        Player.instance.Level++;
        StartCoroutine(DelayLoadScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(Player.instance.Level + 4);
    }
}
