using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Script for managing the slider and its money
public class SliderManagement : MonoBehaviour
{
    public GameObject[] Utilities;
    public GameObject WarningSign;
    public MoneyText MoneyText;
    public Sprite BestMood, Happy, Normal, Angry, VeryAngry;
    public Image SliderHandle;
    public Slider MySlider;
    public float Satisfaction, current, total;
    public int Income;

    void Start()
    {
        // Get utilities
        Utilities = GameObject.FindGameObjectsWithTag("Utility");

        // Keep getting income every half of a second
        InvokeRepeating("MoneyManagement", 0.0f, 0.5f);
    }

    void Update()
    {
        // Get satisfaction by getting total and current
        Satisfaction = current = total = 0;
        for (int i = 0; i < Utilities.Length; i++){
            current += Utilities[i].GetComponent<Utilities>().current;
            total += Utilities[i].GetComponent<Utilities>().total;
        }
        Satisfaction = current == 0 ? 0 : current / total;
        Satisfaction = total == 0 ? 1 : current / total;
        MySlider.value = Satisfaction;
        
        // Change income and sprite according to the sliders value
        if (MySlider.value <= 0.1){
            SliderHandle.sprite = VeryAngry;
            Income = -(int)total * Random.Range(12, 21);
            WarningSign.SetActive(true);
            Losing();
        } else if (MySlider.value < 0.4){
            SliderHandle.sprite = Angry;
            Income = -(int)total * Random.Range(5, 16);
            float reversednumber = 0.5f - MySlider.value;
            Income -= (int)reversednumber * 10;
            WarningSign.SetActive(true);
            Losing();
        } else if (MySlider.value <= 0.6){
            SliderHandle.sprite = Normal;
            Income = (int)total * Random.Range(0, 3);
            Income -= (int)total * Random.Range(0, 2);
            WarningSign.SetActive(true);
            Losing();
        } else if (MySlider.value < 1){
            SliderHandle.sprite = Happy;
            Income = (int)total * Random.Range(2, 8);
            WarningSign.SetActive(false);
        } else{
            SliderHandle.sprite = BestMood;
            Income = (int)total * Random.Range(5, 21);
            WarningSign.SetActive(false);
        }
    }
    public void MoneyManagement(){
        // Get income
        MoneyText.Money += Income; 
    }
    public void Losing(){
        // Change to lose scene
        if (MoneyText.Money <= 0){
            SceneManager.LoadScene("Lose");
        }
    }
}
