using UnityEngine;
using UnityEngine.InputSystem; // <- necesario para el nuevo Input System

public class TowerSelector : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Hiciste clic en: " + hit.collider.name);

                if (hit.collider.CompareTag("Tower"))
                {
                    Debug.Log("Torre seleccionada");
                }
            }
        }
    }
}