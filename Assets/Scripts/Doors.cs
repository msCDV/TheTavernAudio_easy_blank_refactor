using FMODUnity;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// Interfejs IInteractable pozwala innym skryptom na wywoływanie metody Interact().
public class Doors : MonoBehaviour, IInteractable
{
    // Czas trwania animacji otwierania/zamykania drzwi.
    public float rotationDuration = 1f;

    // Prywatne pola z atrybutem SerializedField do edycji w Inspektorze.
    [SerializeField]
    private bool doorsOpened = true;
    [SerializeField]
    private bool isRotating = false;

    // FMOD - Dźwięk drzwi.
    private FMOD.Studio.EventInstance doorsSoundInstance;
    public EventReference doorsEvent;
    
    // FMOD - Snapshot do wnętrza pokoju.
    private FMOD.Studio.EventInstance insideRoomSnapshot;
    public EventReference insideRoomSnap;

    /// <summary>
    /// Główna metoda interakcji, wywoływana z zewnątrz (np. przez skrypt gracza).
    /// </summary>
    public void Interact()
    {
        if (!isRotating)
        {
            // Przełącza stan drzwi (otwarte/zamknięte) i uruchamia odpowiednie akcje.
            doorsOpened = !doorsOpened;
            StartCoroutine(RotateDoors(doorsOpened ? -65 : 65));
            PlaySound();
            RoomsSnap();
        }
    }

    /// <summary>
    /// Korutyna do animowania obrotu drzwi w czasie.
    /// </summary>
    /// <param name="targetAngle">Docelowy kąt obrotu (w stopniach) wokół osi Y.</param>
    private IEnumerator RotateDoors(float targetAngle)
    {
        isRotating = true;
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.Euler(0, targetAngle, 0);

        while (elapsedTime < rotationDuration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / rotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Zapewnia, że drzwi są idealnie obrócone na koniec animacji.
        transform.rotation = targetRotation;
        isRotating = false;
    }

    /// <summary>
    /// Odtwarza dźwięk otwierania lub zamykania drzwi.
    /// </summary>
    private void PlaySound()
    {
        // Sprawdza, czy instancja dźwięku już istnieje, a następnie ją zwalnia.
        if (doorsSoundInstance.isValid())
        {
            doorsSoundInstance.release();
        }
        
        doorsSoundInstance = RuntimeManager.CreateInstance(doorsEvent);
        doorsSoundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject.transform));
        
        // Ustawia parametr "Doors" w zależności od stanu drzwi.
        string parameterLabel = doorsOpened ? "Open" : "Close";
        doorsSoundInstance.setParameterByNameWithLabel("Doors", parameterLabel);
        
        doorsSoundInstance.start();
    }

    /// <summary>
    /// Aktywuje lub dezaktywuje snapshot dźwiękowy pokoju.
    /// </summary>
    private void RoomsSnap()
    {
        RoomAmbient roomAmbient = FindObjectOfType<RoomAmbient>();

        // Logika włączania i wyłączania snapshotu.
        if (roomAmbient.ambientActivated && doorsOpened)
        {
            // Dezaktywuje snapshot.
            if (insideRoomSnapshot.isValid())
            {
                insideRoomSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                insideRoomSnapshot.release();
            }
        }
        else if (roomAmbient.ambientActivated && !doorsOpened)
        {
            // Aktywuje snapshot.
            insideRoomSnapshot = RuntimeManager.CreateInstance(insideRoomSnap);
            insideRoomSnapshot.start();
        }
    }
}