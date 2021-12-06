using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] Text txt;

    int target;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.EndLevel);
        

        target = Player.instance.Target;
        score = Player.instance.Score;

        //Reset player stats
        Player.instance.ResetPlayerStats();

        

        ////Load next scene                        
        if (score >= target)
        {
            ///Player reach the last level
            if(Player.instance.Level == 4)
            {
                txt.text = "Congratulation!";
                StartCoroutine(DelayLoadScene(1));
            }
            else
            {
                txt.text = "You made it to the next level!";
                StartCoroutine(DelayLoadScene(4));
            }
            
        }
        else
        {

            txt.text = $"Noob!\nTarget: {target}\nYour score: {score}";
            StartCoroutine(DelayLoadScene(1));
        }

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayLoadScene(int i)
    {        
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(i);
    }
}