using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Gift : MonoBehaviour
{

    [SerializeField] GameObject floatingText;
    private float startTime;

    // Start is called before the first frame update
    private void Awake() {
        GetComponent<Button>().interactable = false;

    }

    public void AddDiamonds()
    {
        GetComponent<AudioSource>().Play();
        Player.instance.balance += 50;
        FindObjectOfType<SelectionHandler>().balance.text = Player.instance.balance.ToString();
        floatingText.SetActive(true);
        GetComponent<Button>().interactable = false;
    }
    public void MakeInteractable(){
        GetComponent<Button>().interactable = true; 

    }    

    
}
