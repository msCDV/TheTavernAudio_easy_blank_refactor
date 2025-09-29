// using UnityEngine;
// using FMODUnity;
// using FMOD.Studio;

// public class FMOD_Commands : MonoBehaviour
// {
//     #region EVENT EMITTER
//     // EVENT EMITTER
// 	[SerializeField]
//     public FMODUnity.StudioEventEmitter tavernEmitter; // Deklaracja publicznego pola, które przechowuje referencję do event emittera na scenie.
//     #endregion

//     #region EVENT
//     // EVENT
//     FMOD.Studio.EventInstance FootstepsSound; // Deklaracja zmiennej, która będzie przechowywać instancję eventu Footsteps.
//     public EventReference footstepsEvent; // Deklaracja publicznego pola, które przechowuje referencję do pliku z eventem Footsteps.

//     private void Footsteps()
//     {
//         // jednorazowe odtworzenie
//         FMODUnity.RuntimeManager.PlayOneShot(footstepsEvent); // Odtwarza event jednokrotnie bez zarządzania jego instancją.
        
//         // podstawowe zarządzanie eventem
//         FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent); // Tworzy nową instancję eventu Footsteps.
//         FootstepsSound.setParameterByNameWithLabel("Footsteps_surface", "Stone"); // Ustawia parametr o nazwie "Footsteps_surface" na wartość "Stone".
//         FootstepsSound.start(); // Uruchamia odtwarzanie eventu.
//         FootstepsSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // Stopuje odtwarzanie eventu bez fadeoutu.
//         FootstepsSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // Stopuje odtwarzanie eventu z fadeoutem.
//         FootstepsSound.release(); // Zwolnia pamięć zajmowaną przez instancję eventu.

//         // zarządzanie eventem z przypięciami emittera do gameObjectu 
//         FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent);
//         FootstepsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform)); // Przypięcia emitter eventu do obiektu GameObject.
//         FootstepsSound.setParameterByNameWithLabel("Footsteps_surface", "Stone");
//         FootstepsSound.start();
//         FootstepsSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
//         FootstepsSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
//         FootstepsSound.release();
//     }
//     #endregion

//     #region SNAPSHOT
//     // SNAPSHOT
//     FMOD.Studio.EventInstance HealthSnap; // Deklaracja zmiennej, która będzie przechowywać instancję snapshotu Health.
//     public EventReference healthSnapshot; // Deklaracja publicznego pola, które przechowuje referencję do pliku z snapshotem Health.

//     private void StartSnapshot()
//     {
//         if (tavernEmitter != null && tavernEmitter.IsPlaying()) // Sprawdza, czy event emitter istnieje i jest aktywny.
//         {
//             HealthSnap = FMODUnity.RuntimeManager.CreateInstance(healthSnapshot); // Tworzy nową instancję snapshotu Health.
//             HealthSnap.start(); // Uruchamia snapshot.
//         }
//         else if (tavernEmitter != null && tavernEmitter.IsPlaying())
//         {
//             HealthSnap.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // Stopuje snapshot bez fadeoutu.
//             HealthSnap.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // Stopuje snapshot z fadeoutem.
//             HealthSnap.release(); // Zwolnia pamięć zajmowaną przez instancję snapshotu.
//         }
//     }
//     #endregion

//     #region VCA
//     // VCA
//     FMOD.Studio.VCA GlobalVCA; // Deklaracja zmiennej, która będzie przechowywać referencję do VCA o nazwie "Mute".

//     private void VCA()
//     {
//         GlobalVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Mute"); // Pobiera referencję do VCA o nazwie "Mute".
//         GlobalVCA.setVolume(DecibelToLinear(0)); // Ustawia głośność VCA na maksimum (0 dB).
//         GlobalVCA.setVolume(DecibelToLinear(-100)); // Obniża głośność VCA do minimalnego poziomu (-100 dB).
//     }

//     private float DecibelToLinear(float dB) // Funkcja przeliczająca wartość decybelową na skalę liniową.
//     {
//         float linear = Mathf.Pow(10.0f, dB / 20f);
//         return linear;
//     }
//     #endregion

//     #region EVENT / EMITTER Z MUZYKĄ
//     // EVENT / EMITTER Z MUZYKĄ
//     FMOD.Studio.EventInstance Music; // Deklaracja zmiennej, która będzie przechowywać instancję eventu Music.
//     public FMODUnity.StudioEventEmitter tavernEmitter_Music; // Deklaracja publicznego pola, które przechowuje referencję do event emittera na scenie.

//     private void MusicSwitch()
//     {
//         // EVENT
//         FMOD.Studio.EventInstance Music; // Deklaracja zmiennej, która będzie przechowywać instancję eventu Footsteps.
//         private EventReference musicEvent = "events:/nazwa_eventu"; // Deklaracja publicznego pola, które przechowuje referencję do pliku z eventem Footsteps.
        
//         [SerializeField]
//         EventReference musicEvent; // Deklaracja publicznego pola, które przechowuje referencję do pliku z eventem Footsteps.


//         Music = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent); // Tworzy nową instancję eventu Footsteps.
//         Music.setParameterByNameWithLabel("Switch_parts", "Part 2"); // Ustawia parametr o nazwie "Switch_parts" na wartość "Part 2".
//         Music.start(); // Uruchamia odtwarzanie eventu.
//         Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // Stopuje odtwarzanie eventu bez fadeoutu.
//         Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // Stopuje odtwarzanie eventu z fadeoutem.
//         Music.release(); // Zwolnia pamięć zajmowaną przez instancję eventu.

//         // EMITTER
//         [SerializeField]
//         public FMODUnity.StudioEventEmitter tavernEmitter; // Deklaracja publicznego pola, które przechowuje referencję do event emittera na scenie.

//         tavernEmitter_Music.SetParameter("Switch_parts", 0); // Ustawia parametr o nazwie "Switch_parts" na wartość 0 dla event emittera.
//         tavernEmitter_Music.Play(); // Uruchamia odtwarzanie na emitterze.
//         tavernEmitter_Music.Stop(); // Stopuje odtwarzanie na emitterze.
//     }
//     #endregion
// }
