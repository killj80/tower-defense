using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField]
    private GameObject upgradeCanvas;

    [SerializeField]
    public GameObject selectedTower;

    public CannonTower cannonTower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        cannonTower = selectedTower.GetComponent<CannonTower>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUpgradeClick()
    {
        if (gameManager.gold >= 5)
        {
            cannonTower.towerDamage = cannonTower.towerDamage + cannonTower.damageIncrease;
            cannonTower.upgradeLimit++;
            upgradeCanvas.SetActive(false);
        }
    }

    public void OnSellClick()
    {
        gameObject.SetActive(false);
        upgradeCanvas.SetActive(false);

        gameManager.gold = gameManager.gold + 5;
    }
}
