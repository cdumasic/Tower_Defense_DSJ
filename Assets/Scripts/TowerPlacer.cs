using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TowerManager : MonoBehaviour, IPointerClickHandler
{
    public Camera mainCamera; // arr�strala en el inspector
    public GameObject towerPrefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        // C�digo que se ejecuta al hacer click.
        Debug.Log("�Objeto clickeado con IPointerClickHandler!");
    }
}