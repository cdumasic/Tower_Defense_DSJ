using UnityEngine;
public class TowerSlot : MonoBehaviour
{

    public GameObject towerPrefab;
    private bool isOccupied = false;

    void OnMouseDown()
    {
        if (!isOccupied)
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isOccupied = true;
        }
    }
}