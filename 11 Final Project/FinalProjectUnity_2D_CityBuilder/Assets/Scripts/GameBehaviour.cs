using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Script for managing the process of buying the houses 
// with particle effects in the game excluding the utilities and people
public class GameBehaviour : MonoBehaviour
{
    public GameObject UpgradesCover, NoHigherLevelSign, NoMoneySign;
    public GameObject BuyHouse, UpgradingHouse, ParticleSystem;
    public MoneyText MoneyText;
    public Text HousePriceTag;
    public int Upgrades, AmountToUpgrade;
	
    // Managing the clicking of the mouse or the touching on the screen
	void Update (){
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)){
                Debug.Log(hit.transform.name);
                if (hit.transform.tag == "House"){
                    UpgradingHouse = hit.transform.gameObject;
                    AmountToUpgrade = UpgradingHouse.GetComponent<Houses>().Level == 0 ? 1 : 5;
                    
                    if (UpgradingHouse.GetComponent<Houses>().Level <= 1){
                        UpgradesCover.SetActive(true);
                        HousePriceTag.text = "$ " + UpgradingHouse.GetComponent<Houses>().Price;
                    } else{
                        NoHigherLevelSign.SetActive(true);
                        Invoke("NoHigherLevel", 1.0f);
                    }
                }
                if (hit.transform.name == "BuyHouse"){
                    HouseManagement();
                }
                if (hit.transform.name == "LeaveHouse"){
                    UpgradesCover.SetActive(false);
                }
            }
        }
        if (MoneyText.Money >= UpgradingHouse.GetComponent<Houses>().Price){
            BuyHouse.GetComponent<Collider>().enabled = true;
            BuyHouse.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        } else{
            BuyHouse.GetComponent<Collider>().enabled = false;
            BuyHouse.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 172);
        }
        if (Upgrades >= 84){
            SceneManager.LoadScene("Win");
        }
    }

    // Function managing the houses upgrades...
    public void HouseManagement(){
        UpgradesCover.SetActive(false);

        if (MoneyText.Money >= UpgradingHouse.GetComponent<Houses>().Price){
            MoneyText.Money -= UpgradingHouse.GetComponent<Houses>().Price;
            UpgradingHouse.GetComponent<Houses>().Level += 1;
            Upgrades += 1;
            Vector3 HousePosition = new Vector3(UpgradingHouse.transform.position.x, UpgradingHouse.transform.position.y, 2);
            Instantiate(ParticleSystem, HousePosition, ParticleSystem.transform.rotation, ParticleSystem.transform.parent);
        } else{
            NoMoneySign.SetActive(true);
            UpgradesCover.SetActive(false);
            Invoke("NoMoney", 1.0f);
        }
    }

    // Functions for deactivating signs
    private void NoHigherLevel(){
        NoHigherLevelSign.SetActive(false);
    }
    private void NoMoney(){
        NoMoneySign.SetActive(false);
    }
}
