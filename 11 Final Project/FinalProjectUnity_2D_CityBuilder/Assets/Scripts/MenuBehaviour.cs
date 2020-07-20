using UnityEngine;
using UnityEngine.UI;

// Script for managing the process of buying the utilities and upgrading
// them plus the people with particle effects
public class MenuBehaviour : MonoBehaviour
{
    public GameObject UpgradesCover, NoHigherUpgradeSign, NoMoneySign;
    public GameObject UpgradingUtility, ParticleSystem, Person, BuyUtility;
    public GameObject[] Utilities;
    public MoneyText MoneyText;
    public GameBehaviour GameBehaviour;
    public Text UtilityPriceTag;

    void Start()
    {
        // Get utilities
        Utilities = GameObject.FindGameObjectsWithTag("Utility");
    }

    // Managing the clicking of the mouse or the touching on the screen
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)){
                if (hit.transform.name == "BuyHouse"){
                    UpgradeUtilities();
                }
                if (hit.transform.tag == "Utility"){
                    UpgradingUtility = hit.transform.gameObject;
                    if (UpgradingUtility.GetComponent<Utilities>().current < UpgradingUtility.GetComponent<Utilities>().total){
                        UtilityPriceTag.text = "$ " + UpgradingUtility.GetComponent<Utilities>().total * 100;
                        UpgradesCover.SetActive(true);
                    } else{
                        NoHigherUpgradeSign.SetActive(true);
                        Invoke("NoHigherUpgrade", 1.0f);
                    }
                }
                if (hit.transform.name == "BuyUtility"){
                    UtilityManagement();
                }
                if (hit.transform.name == "LeaveUtility"){
                    UpgradesCover.SetActive(false);
                }
            }
        }
        if (MoneyText.Money >= UpgradingUtility.GetComponent<Houses>().Price){
            BuyUtility.GetComponent<Collider>().enabled = true;
            BuyUtility.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        } else{
            BuyUtility.GetComponent<Collider>().enabled = false;
            BuyUtility.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 172);
        }
    }

    // Manage the process of buying utilities
    public void UtilityManagement(){
        UpgradesCover.SetActive(false);

        if (MoneyText.Money >= UpgradingUtility.GetComponent<Utilities>().total * 10){
            MoneyText.Money -= (int)UpgradingUtility.GetComponent<Utilities>().total * 10;
            UpgradingUtility.GetComponent<Utilities>().current += 1;
            Vector3 UtilityPosition = new Vector3(UpgradingUtility.transform.position.x, UpgradingUtility.transform.position.y, -6);
            Instantiate(ParticleSystem, UtilityPosition, ParticleSystem.transform.rotation, ParticleSystem.transform.parent);
        } else{
            NoMoneySign.SetActive(true);
            Invoke("NoMoney", 1.0f);                        
        }        
    }
    // Function for upgrading the utilities and instantiating people
    public void UpgradeUtilities(){
        if (GameBehaviour.AmountToUpgrade == 1){
            Utilities[Random.Range(0, 9)].GetComponent<Utilities>().total += 1;
            Instantiate(Person, new Vector3(0, 0, 3), Quaternion.identity, Person.transform.parent);
        } else{
            for(int i = 0; i < 5; i++){
                Utilities[Random.Range(0, 9)].GetComponent<Utilities>().total += 1;
                Instantiate(Person, new Vector3(0, 0, 3), Quaternion.identity, Person.transform.parent);
            }
        }
    }

    // Functions for deactivating signs
    private void NoHigherUpgrade(){
        NoHigherUpgradeSign.SetActive(false);
    }
    private void NoMoney(){
        NoMoneySign.SetActive(false);
    }
}
