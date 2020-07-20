using UnityEngine;

// Script for managing the behaiviour of the house
public class Houses : MonoBehaviour
{
    public Sprite Level0, Level1, Level2;
    public int Level, Price, Income;
    public MoneyText MoneyText;

    void Start(){
        // Keep getting income every half of a second
        InvokeRepeating("GettingMoney", 0.0f, 0.5f);
    }

    void Update(){
        // Change sprite, price and income according to the level of house
        if (Level == 0){
            GetComponent<SpriteRenderer>().sprite = Level0;
            Price = 1000;
            Income = 0;
        } else if (Level == 1){
            GetComponent<SpriteRenderer>().sprite = Level1;
            Price = 5000;
            Income = 5;
        } else{
            GetComponent<SpriteRenderer>().sprite = Level2;
            Price = 0;
            Income = 30;
        }
    }

    private void GettingMoney(){
        // Get income according to income
        MoneyText.Money += Income;
    }
}
