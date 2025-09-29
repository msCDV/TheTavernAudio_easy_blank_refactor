using UnityEngine;
using FMODUnity;

/// <summary>
/// Zarządza aktywacją snapshotu zdrowia, gdy gra gracz naciśnie klawisz "K".
/// </summary>
public class Health : MonoBehaviour
{
    // Flaga stanu snapshotu.
    [SerializeField]
    private bool healthSnapshotActive = false;

    // FMOD - Instancja snapshotu.
    private FMOD.Studio.EventInstance healthSnapshotInstance;
    public EventReference healthSnapshot;

    void Update()
    {
        // Sprawdza, czy klawisz "K" został naciśnięty.
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Przełącza stan snapshotu.
            ToggleSnapshot(!healthSnapshotActive);
        }
    }

    /// <summary>
    /// Włącza lub wyłącza instancję snapshotu zdrowia.
    /// </summary>
    /// <param name="activate">True, aby włączyć, false, aby wyłączyć.</param>
    private void ToggleSnapshot(bool activate)
    {
        if (activate)
        {
            healthSnapshotInstance = RuntimeManager.CreateInstance(healthSnapshot);
            healthSnapshotInstance.start();
        }
        else
        {
            if (healthSnapshotInstance.isValid())
            {
                healthSnapshotInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                healthSnapshotInstance.release();
            }
        }
        // Aktualizuje stan.
        healthSnapshotActive = activate;
    }
}