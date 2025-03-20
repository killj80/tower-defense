using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject placementCanvas;

    [SerializeField]
    private GameObject cannonTower;
    [SerializeField]
    private GameObject ballistaTower;
    [SerializeField]
    private GameObject wizardTower;
    [SerializeField]
    private GameObject trebuchetTower;
    [SerializeField]
    private GameObject hotOilTower;

    public void OnCannonClick()
    {
        cannonTower.SetActive(true);
        placementCanvas.SetActive(false);
    }

    public void OnBallistaClick()
    {
        ballistaTower.SetActive(true);
        placementCanvas.SetActive(false);
    }
    public void OnWizardClick()
    {
        wizardTower.SetActive(true);
        placementCanvas.SetActive(false);
    }
    public void OnTrebuchetClick()
    {
        trebuchetTower.SetActive(true);
        placementCanvas.SetActive(false);
    }
    public void OnHotOilClick()
    {
        hotOilTower.SetActive(true);
        placementCanvas.SetActive(false);
    }
}
