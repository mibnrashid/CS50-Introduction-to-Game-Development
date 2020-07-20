using UnityEngine;
using UnityEngine.UI;

// Script for writing the money
public class MoneyText : MonoBehaviour
{
    public int Money;
    private Text text;

    void Start()
    {
        // Get text component
        text = GetComponent<Text>();
    }

    void Update()
    {
        // Make sure money doesnt go more than 100000 for size issue
        if (Money >= 100000){
            Money = 99999;
        }

        // Write the money
        text.text = "" + Money;
    }
}
