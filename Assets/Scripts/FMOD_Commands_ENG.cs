// using UnityEngine;
// using FMODUnity;
// using FMOD.Studio;

// public class FMOD_Commands : MonoBehaviour
// {
//     #region EVENT EMITTER
//     // EVENT EMITTER
// 	[SerializedField]
//     public FMODUnity.StudioEventEmitter tavernEmitter; // Declaration of a public field that holds the reference to the event emitter on the scene.
//     #endregion

//     #region EVENT
//     // EVENT
//     FMOD.Studio.EventInstance FootstepsSound; // Declaration of a variable that will store the instance of the Footsteps event.
//     public EventReference footstepsEvent; // Declaration of a public field that holds the reference to the file with the Footsteps event.

//     private void Footsteps()
//     {
//         // one-time playback
//         FMODUnity.RuntimeManager.PlayOneShot(footstepsEvent); // Plays the event once without managing its instance.
        
//         // basic event management
//         FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent); // Creates a new instance of the Footsteps event.
//         FootstepsSound.setParameterByNameWithLabel("Footsteps_surface", "Stone"); // Sets the parameter named "Footsteps_surface" to the value "Stone".
//         FootstepsSound.start(); // Starts playing the event.
//         FootstepsSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // Stops playing the event without fadeout.
//         FootstepsSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // Stops playing the event with fadeout.
//         FootstepsSound.release(); // Frees the memory occupied by the event instance.

//         // event management with emitter attachment to gameObject 
//         FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent);
//         FootstepsSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform)); // Attaches the emitter event to the GameObject.
//         FootstepsSound.setParameterByNameWithLabel("Footsteps_surface", "Stone");
//         FootstepsSound.start();
//         FootstepsSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
//         FootstepsSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
//         FootstepsSound.release();
//     }
//     #endregion

//     #region SNAPSHOT
//     // SNAPSHOT
//     FMOD.Studio.EventInstance HealthSnap; // Declaration of a variable that will store the instance of the Health snapshot.
//     public EventReference healthSnapshot; // Declaration of a public field that holds the reference to the file with the Health snapshot.

//     private void StartSnapshot()
//     {
//         if (tavernEmitter != null && tavernEmitter.IsPlaying()) // Checks if the event emitter exists and is active.
//         {
//             HealthSnap = FMODUnity.RuntimeManager.CreateInstance(healthSnapshot); // Creates a new instance of the Health snapshot.
//             HealthSnap.start(); // Starts the snapshot.
//         }
//         else if (tavernEmitter != null && tavernEmitter.IsPlaying())
//         {
//             HealthSnap.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // Stops the snapshot without fadeout.
//             HealthSnap.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // Stops the snapshot with fadeout.
//             HealthSnap.release(); // Frees the memory occupied by the snapshot instance.
//         }
//     }
//     #endregion

//     #region VCA
//     // VCA
//     FMOD.Studio.VCA GlobalVCA; // Declaration of a variable that will store the reference to the VCA named "Mute".

//     private void VCA()
//     {
//         GlobalVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Mute"); // Retrieves the reference to the VCA named "Mute".
//         GlobalVCA.setVolume(DecibelToLinear(0)); // Sets the volume of the VCA to maximum (0 dB).
//         GlobalVCA.setVolume(DecibelToLinear(-100)); // Reduces the volume of the VCA to the minimum level (-100 dB).
//     }

//     private float DecibelToLinear(float dB) // Function converting decibel value to linear scale.
//     {
//         float linear = Mathf.Pow(10.0f, dB / 20f);
//         return linear;
//     }
//     #endregion

//     #region EVENT / EMITTER WITH MUSIC
//     // EVENT / EMITTER WITH MUSIC
//     FMOD.Studio.EventInstance Music; // Declaration of a variable that will store the instance of the Music event.
//     public FMODUnity.StudioEventEmitter tavernEmitter_Music; // Declaration of a public field that holds the reference to the event emitter on the scene.

//     private void MusicSwitch()
//     {
//         // EVENT
//         FootstepsSound = FMODUnity.RuntimeManager.CreateInstance(footstepsEvent); // Creates a new instance of the Footsteps event.
//         Music.setParameterByNameWithLabel("Switch_parts", "Part 2"); // Sets the parameter named "Switch_parts" to the value "Part 2".
//         Music.start(); // Starts playing the event.
//         Music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE); // Stops playing the event without fadeout.
//         Music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); // Stops playing the event with fadeout.
//         Music.release(); // Frees the memory occupied by the event instance.

//         // EMITTER
//         tavernEmitter_Music.SetParameter("Switch_parts", 0); // Sets the parameter named "Switch_parts" to the value 0 for the event emitter.
//         tavernEmitter_Music.Play(); // Starts playing on the emitter.
//         tavernEmitter_Music.Stop(); // Stops playing on the emitter.
//     }
//     #endregion
// }
