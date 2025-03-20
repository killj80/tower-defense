using UnityEngine;

public class TowerSpots : MonoBehaviour
{
    [SerializeField]
    private GameObject PlacementCanvas;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlacementCanvas.SetActive(true);
        }
    }
}
