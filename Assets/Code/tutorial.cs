using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject moster;
    // public float startTimeBtwMonster;
    // private float timeBtwMonster;
    // public int numberOfMonsters;
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawner;
    public float waitTime = 2f;


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if(i== popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }
        if(popUpIndex==0)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow))
            {
                popUpIndex++;
            }
            else if (popUpIndex == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    popUpIndex++;
                    Debug.Log("Space key was pressed.");
                }
            }
            else if(popUpIndex==2)
            {
                if (waitTime <= 0)
                {
                    spawner.SetActive(true);
                }
                else{
                    waitTime -=Time.deltaTime;
                }
               
            }
        }
    }
}
