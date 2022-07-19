using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gift : MonoBehaviour
{

    [SerializeField] GameObject floatingText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddDiamonds()
    {
        GetComponent<AudioSource>().Play();
        Player.instance.balance += 50;
        FindObjectOfType<SelectionHandler>().balance.text = Player.instance.balance.ToString();
        floatingText.SetActive(true);
        GetComponent<Button>().interactable = false;
    }
}
