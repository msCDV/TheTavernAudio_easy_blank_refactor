using UnityEngine;

/// <summary>
/// Zarządza stanem ambientu pokoju w zależności od pozycji gracza.
/// </summary>
public class Rooms : MonoBehaviour
{
    /// <summary>
    /// Wywoływane, gdy inny collider pozostaje wewnątrz triggera.
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        // Sprawdza, czy obiekt ma tag "Player".
        if (other.CompareTag("Player"))
        {
            // Znajduje instancję RoomAmbient w scenie i ustawia flagę na true.
            RoomAmbient roomAmbient = FindObjectOfType<RoomAmbient>();
            if (roomAmbient != null)
            {
                roomAmbient.ambientActivated = true;
            }
        }
    }

    /// <summary>
    /// Wywoływane, gdy inny collider opuszcza trigger.
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        // Sprawdza, czy obiekt ma tag "Player".
        if (other.CompareTag("Player"))
        {
            // Znajduje instancję RoomAmbient w scenie i ustawia flagę na false.
            RoomAmbient roomAmbient = FindObjectOfType<RoomAmbient>();
            if (roomAmbient != null)
            {
                roomAmbient.ambientActivated = false;
            }
        }
    }
}