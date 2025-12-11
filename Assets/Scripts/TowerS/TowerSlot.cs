using UnityEngine;

public class TowerSlot : MonoBehaviour
{
    public GameObject[] towerPrefab1;
    public GameObject[] towerPrefab2;
    public GameObject[] towerPrefab3;
    public GameObject[] towerPrefab4;

    private int levelTower1 = 0;
    private int levelTower2 = 0;
    private int levelTower3 = 0;
    private int levelTower4 = 0;

    private GameObject torre;
    private Tower towerData;

    private int towerSelection = 0;

    void Start()
    {
        
        towerData = towerPrefab1[0].GetComponent<Tower>();
        
        if (towerData == null)
        {
            Debug.LogError("El prefab no tiene componente Tower.cs");
            return;
        }
    }

    void OnMouseDown()
    {
        towerSelection = GameManager.Instance.getSeleccionTorre();
        if (towerSelection == 0)
        {
            if (levelTower2 != 0 || levelTower3 != 0 || levelTower4 != 0) return;

            int cost1 = towerData.TowerPrices1(towerSelection);
            int cost2 = towerData.TowerPrices2(towerSelection);
            int cost3 = towerData.TowerPrices3(towerSelection);

            // Verificar si hay suficiente oro
            if (GameManager.Instance.GetGold() >= cost1 && levelTower1 == 0)
            {
                // Resta oro y coloca torre 1
                GameManager.Instance.SpendGold(cost1);
                torre = Instantiate(towerPrefab1[0], transform.position, Quaternion.identity);
                //isOccupied = true;
                levelTower1 = 1;
            }
            else if (GameManager.Instance.GetGold() >= cost2 && levelTower1 == 1)
            {
                // Resta oro y coloca torre 2
                GameManager.Instance.SpendGold(cost2);
                Destroy(torre);
                torre = Instantiate(towerPrefab1[1], transform.position, Quaternion.identity);
                levelTower1 = 2;
            }

            else if (GameManager.Instance.GetGold() >= cost3 && levelTower1 == 2)
            {
                // Resta oro y coloca torre 2
                GameManager.Instance.SpendGold(cost3);
                Destroy(torre);
                torre = Instantiate(towerPrefab1[2], transform.position, Quaternion.identity);
            }

            else
            {
                GameManager.Instance.setMessage("No hay suficiente oro para colocar esta torre");
            }

        }
        else if (towerSelection == 1)
        {
            if (levelTower1 != 0 || levelTower3 != 0 || levelTower4 != 0) return;
            int cost1 = towerData.TowerPrices1(towerSelection);
            int cost2 = towerData.TowerPrices2(towerSelection);
            int cost3 = towerData.TowerPrices3(towerSelection);

            // Verificar si hay suficiente oro
            if (GameManager.Instance.GetGold() >= cost1 && levelTower2 == 0)
            {
                // Resta oro y coloca torre 1
                GameManager.Instance.SpendGold(cost1);
                torre = Instantiate(towerPrefab2[0], transform.position, Quaternion.identity);
                //isOccupied = true;
                levelTower2 = 1;
            }
            else if (GameManager.Instance.GetGold() >= cost2 && levelTower2 == 1)
            {
                // Resta oro y coloca torre 2
                GameManager.Instance.SpendGold(cost2);
                Destroy(torre);
                torre = Instantiate(towerPrefab2[1], transform.position, Quaternion.identity);
                levelTower2 = 2;
            }

            else if (GameManager.Instance.GetGold() >= cost3 && levelTower2 == 2)
            {
                // Resta oro y coloca torre 2
                GameManager.Instance.SpendGold(cost3);
                Destroy(torre);
                torre = Instantiate(towerPrefab2[2], transform.position, Quaternion.identity);
            }

            else
            {
                GameManager.Instance.setMessage("No hay suficiente oro para colocar esta torre.");
            }
        }
        else if (towerSelection == 2)
        {
            if (levelTower1 != 0 || levelTower2 != 0 || levelTower4 != 0) return;

            int cost1 = towerData.TowerPrices1(towerSelection);
            int cost2 = towerData.TowerPrices2(towerSelection);
            int cost3 = towerData.TowerPrices3(towerSelection);

            // Verificar si hay suficiente oro
            if (GameManager.Instance.GetGold() >= cost1 && levelTower3 == 0)
            {
                // Resta oro y coloca torre 1
                GameManager.Instance.SpendGold(cost1);
                torre = Instantiate(towerPrefab3[0], transform.position, Quaternion.identity);
                //isOccupied = true;
                levelTower3 = 1;
            }
            else if (GameManager.Instance.GetGold() >= cost2 && levelTower3 == 1)
            {
                // Resta oro y coloca torre 2
                GameManager.Instance.SpendGold(cost2);
                Destroy(torre);
                torre = Instantiate(towerPrefab3[1], transform.position, Quaternion.identity);
                levelTower3 = 2;
            }

            else if (GameManager.Instance.GetGold() >= cost3 && levelTower3 == 2)
            {
                // Resta oro y coloca torre 2
                GameManager.Instance.SpendGold(cost3);
                Destroy(torre);
                torre = Instantiate(towerPrefab3[2], transform.position, Quaternion.identity);
            }

            else
            {
                GameManager.Instance.setMessage("No hay suficiente oro para colocar esta torre.");
            }
        }
        else if (towerSelection == 3)
        {
            if (levelTower1 != 0 || levelTower3 != 0 || levelTower3 != 0) return;

            int cost1 = towerData.TowerPrices1(towerSelection);
            int cost2 = towerData.TowerPrices2(towerSelection);
            int cost3 = towerData.TowerPrices3(towerSelection);

            // Verificar si hay suficiente oro
            if (GameManager.Instance.GetGold() >= cost1 && levelTower4 == 0)
            {
                // Resta oro y coloca torre 1
                GameManager.Instance.SpendGold(cost1);
                torre = Instantiate(towerPrefab4[0], transform.position, Quaternion.identity);
                //isOccupied = true;
                levelTower4 = 1;
            }
            else if (GameManager.Instance.GetGold() >= cost2 && levelTower4 == 1)
            {
                // Resta oro y coloca torre 2
                GameManager.Instance.SpendGold(cost2);
                Destroy(torre);
                torre = Instantiate(towerPrefab4[1], transform.position, Quaternion.identity);
                levelTower4 = 2;
            }

            else if (GameManager.Instance.GetGold() >= cost3 && levelTower4 == 2)
            {
                // Resta oro y coloca torre 2
                GameManager.Instance.SpendGold(cost3);
                Destroy(torre);
                torre = Instantiate(towerPrefab4[2], transform.position, Quaternion.identity);
            }

            else
            {
                GameManager.Instance.setMessage("No hay suficiente oro para colocar esta torre.");
            }
        }
        else
        {
            GameManager.Instance.setMessage("No existe esa torre.");
        }
    }
}