using UnityEngine;
using UnityEngine.UI;

// Script for managing the behaiviour of the utility
public class Utilities : MonoBehaviour
{
    public MoneyText MoneyText;
    public Text myText;
    public float current, total;

    void Start()
    {
        // Set everything to 0 and get text component
        current = total = 0;
        myText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        // Make sure that the total doesnt go more than 99
        if (total >= 100){
            total = 99;
        }

        // Write the current and total
        myText.text = current + " / " + total;
    }
}
