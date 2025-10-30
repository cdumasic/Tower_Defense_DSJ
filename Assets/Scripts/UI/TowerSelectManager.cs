using UnityEngine;
using UnityEngine.UI;
public class TowerSelectManager : MonoBehaviour
{
    public GameObject[] seleccion;
    public GameObject[] locks;
    private int Gold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activarSeleccion(int index)
    {
        Debug.Log("Me presionaste xd");
        if (GameManager.Instance.getTower(index) == true)
        {

            for (int i = 0; i < seleccion.Length; i++)
            {
                seleccion[i].SetActive(false);
            }
            seleccion[index].SetActive(true);
            GameManager.Instance.setSeleccionTorre(index);
        }
        
    }

    public void desbloquearTorre(int index)
    {
        Debug.Log("Me presionaste xd otra vez");
        if (GameManager.Instance.getTower(index) == true) return;
        Debug.Log("Me presionaste de nuevo que fue manito xd");
        if (GameManager.Instance.getTowerPrices(index) <= GameManager.Instance.GetGold())
        {
            GameManager.Instance.SpendGold(GameManager.Instance.getTowerPrices(index));
            Destroy(locks[index]);
            GameManager.Instance.activateTower(index);
        }
        
    }
}
