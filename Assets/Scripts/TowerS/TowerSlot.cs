using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    public GameObject towerPrefab1;
    public GameObject towerPrefab2;
    public GameObject towerPrefab3;
    private int levelTower = 0;
    private GameObject torre;
    private Tower towerData1;
    private Tower towerData2;
    private Tower towerData3;

    void Start()
    {
        towerData1 = towerPrefab1.GetComponent<Tower>();
        towerData2 = towerPrefab2.GetComponent<Tower>();
        towerData3 = towerPrefab3.GetComponent<Tower>();
        if (towerData1 == null || towerData2 == null || towerData3 == null)
        {
            Debug.LogError("El prefab no tiene componente Tower.cs");
            return;
        }
    }

    void OnMouseDown()
    {

        int cost1 = towerData1.cost1;
        int cost2 = towerData2.cost2;
        int cost3 = towerData3.cost3;

        // Verificar si hay suficiente oro
        if (GameManager.Instance.GetGold() >= cost1 && levelTower==0)
        {
            // Resta oro y coloca torre 1
            GameManager.Instance.SpendGold(cost1);
            torre = Instantiate(towerPrefab1, transform.position, Quaternion.identity);
            //isOccupied = true;
            Debug.Log($"Torre colocada. Oro restante: {GameManager.Instance.GetGold()}");
            levelTower = 1;
        }
        else if (GameManager.Instance.GetGold() >= cost2 && levelTower == 1)
        {
            // Resta oro y coloca torre 2
            GameManager.Instance.SpendGold(cost2);
            Destroy(torre);
            torre = Instantiate(towerPrefab2, transform.position, Quaternion.identity);
            Debug.Log($"Torre colocada. Oro restante: {GameManager.Instance.GetGold()}");
        }

        else if (GameManager.Instance.GetGold() >= cost3 && levelTower == 1)
        {
            // Resta oro y coloca torre 2
            GameManager.Instance.SpendGold(cost3);
            Destroy(torre);
            torre = Instantiate(towerPrefab3, transform.position, Quaternion.identity);
            Debug.Log($"Torre colocada. Oro restante: {GameManager.Instance.GetGold()}");
        }

        else
        {
            Debug.Log("No hay suficiente oro para colocar esta torre.");
        }

    }

    
}