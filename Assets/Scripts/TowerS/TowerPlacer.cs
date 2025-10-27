using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TowerManager : MonoBehaviour, IPointerClickHandler
{
    public Camera mainCamera; // arrástrala en el inspector
    public GameObject towerPrefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Código que se ejecuta al hacer click.
        Debug.Log("¡Objeto clickeado con IPointerClickHandler!");
    }
}