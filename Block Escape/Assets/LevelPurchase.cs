using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelPurchase : MonoBehaviour
{

    Button purchase;


    

    void Start()
    {
        purchase  = GetComponent<Button>();
        

    }

    public void BuyLvl()
    {
        if(Player.instance.balance >= 300)
        {
            GetComponent<AudioSource>().Play();
            Player.instance.balance -= 300;
            Player.instance.unlockedList[Player.instance.selectedLevel] = true ;    
        }
    }

    
   
}
