using UnityEngine;

public class CannonTower : MonoBehaviour
{
    public int towerDamage = 10;
    public int damageIncrease = 10;
    public int upgradeLimit = 0;
    [SerializeField]
    private GameObject upgradeCanvas;

    public GameManager gameManager;
    public UpgradeMenu upgradeButton;
    public UpgradeMenu sellButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        upgradeButton = upgradeCanvas.GetComponentInChildren<UpgradeMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            upgradeCanvas.SetActive(true);
            upgradeButton.selectedTower = gameObject;
        }
    }

    
}
