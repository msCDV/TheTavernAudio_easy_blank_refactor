using UnityEngine;
using FMODUnity;

/// <summary>
/// Zarządza aktywacją snapshotu 'Outside' na podstawie tagu powierzchni, na której znajduje się gracz.
/// </summary>
public class Outside_foot_switch : MonoBehaviour
{
    // Prywatna zmienna do edycji w Inspektorze.
    [SerializeField]
    private bool snapshotActivated = false;

    // Odległość do podłoża od środka kolidera.
    private float distToGround;

    // FMOD - Instancja snapshotu.
    private FMOD.Studio.EventInstance outsideSnapshotInstance;
    public EventReference outsideSnapshot;

    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void FixedUpdate()
    {
        ToggleSnapshotLogic();
    }

    /// <summary>
    /// Sprawdza, czy należy włączyć lub wyłączyć snapshot.
    /// </summary>
    private void ToggleSnapshotLogic()
    {
        RaycastHit hit;
        // Wykonuje raycast, aby sprawdzić, co znajduje się pod graczem.
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distToGround + 0.5f))
        {
            string tag = hit.collider.tag;
            
            // Włącza snapshot, jeśli gracz jest na zewnątrz, a snapshot nie jest aktywny.
            if (tag == "Outside" && !snapshotActivated)
            {
                ToggleSnapshot(true);
            }
            // Wyłącza snapshot, jeśli gracz jest wewnątrz, a snapshot jest aktywny.
            else if ((tag == "Inside_stone" || tag == "Inside_wood") && snapshotActivated)
            {
                ToggleSnapshot(false);
            }
        }
    }

    /// <summary>
    /// Włącza lub wyłącza instancję snapshotu FMOD.
    /// </summary>
    /// <param name="activate">True, aby włączyć, false, aby wyłączyć.</param>
    private void ToggleSnapshot(bool activate)
    {
        if (activate)
        {
            // Tworzy i startuje instancję snapshotu.
            outsideSnapshotInstance = FMODUnity.RuntimeManager.CreateInstance(outsideSnapshot);
            outsideSnapshotInstance.start();
        }
        else
        {
            // Zatrzymuje i zwalnia instancję snapshotu, jeśli jest prawidłowa.
            if (outsideSnapshotInstance.isValid())
            {
                outsideSnapshotInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                outsideSnapshotInstance.release();
            }
        }
        // Przełącza stan.
        snapshotActivated = activate;
    }
}