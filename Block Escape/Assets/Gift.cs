using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Gift : MonoBehaviour
{

    [SerializeField] GameObject floatingText;

    Button gift;

    [SerializeField] string currentDate;

    // Start is called before the first frame update
    void Start()
    {
        gift = GetComponent<Button>();

        currentDate = System.DateTime.Now.Date.ToString("yyyy-MM-dd");

        gift.interactable = !currentDate.Equals(Player.instance.date);

    }

    public void AddDiamonds()
    {
        GetComponent<AudioSource>().Play();
        Player.instance.balance += 50;
        FindObjectOfType<SelectionHandler>().balance.text = Player.instance.balance.ToString();
        floatingText.SetActive(true);
        GetComponent<Button>().interactable = false;
        Player.instance.date = currentDate;
    }
}
