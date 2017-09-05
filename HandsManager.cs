using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR.WSA.Input;


namespace HoloToolkit.Unity
{
        public class HandsManager : Singleton<HandsManager>
        {
            [Tooltip("Audio clip to play when Finger Pressed.")]
            public AudioClip FingerPressedSound;
            private AudioSource audioSource;

            /// <summary>
            /// Tracks the hand detected state.
            /// </summary>
            public bool HandDetected
            {
                get;
                private set;
            }

            // Keeps track of the GameObject that the hand is interacting with.
            public GameObject FocusedGameObject { get; private set; }

            protected override void Awake()
            {
                base.Awake();
                EnableAudioHapticFeedback();

                InteractionManager.SourceDetected += InteractionManager_SourceDetected;
                InteractionManager.SourceLost += InteractionManager_SourceLost;

                InteractionManager.SourcePressed += InteractionManager_SourcePressed;
                InteractionManager.SourceReleased += InteractionManager_SourceReleased;

                FocusedGameObject = null;
            }

            private void EnableAudioHapticFeedback()
            {
                // If this hologram has an audio clip, add an AudioSource with this clip.
                if (FingerPressedSound != null)
                {
                    audioSource = GetComponent<AudioSource>();
                    if (audioSource == null)
                    {
                        audioSource = gameObject.AddComponent<AudioSource>();
                    }

                    audioSource.clip = FingerPressedSound;
                    audioSource.playOnAwake = false;
                    audioSource.spatialBlend = 1;
                    audioSource.dopplerLevel = 0;
                }
            }

            private void InteractionManager_SourceDetected(InteractionSourceState hand)
            {
                HandDetected = true;
            }

            private void InteractionManager_SourceLost(InteractionSourceState hand)
            {
                HandDetected = false;

                ResetFocusedGameObject();
            }

            private void InteractionManager_SourcePressed(InteractionSourceState hand)
            {
                if (InteractibleManager.Instance.FocusedGameObject != null)
                {
                    // Play a select sound if we have an audio source and are not targeting an asset with a select sound.
                    if (audioSource != null && !audioSource.isPlaying)
                    { 
                        if(InteractibleManager.Instance.FocusedGameObject.GetComponent<Interactible>() != null &&
                                 InteractibleManager.Instance.FocusedGameObject.GetComponent<Interactible>().TargetFeedbackSound != null)
                        {
                             audioSource.PlayOneShot(InteractibleManager.Instance.FocusedGameObject
                                        .GetComponent<Interactible>().TargetFeedbackSound);
                        }
                        else
                        {
                            audioSource.Play();
                        }

                    }
                FocusedGameObject = InteractibleManager.Instance.FocusedGameObject;
                }
            }

            private void InteractionManager_SourceReleased(InteractionSourceState hand)
            {
                ResetFocusedGameObject();
            }

            private void ResetFocusedGameObject()
            {
                 FocusedGameObject = null;
                 //GestureManager.Instance.ResetGestureRecognizers();
            }

            protected override void OnDestroy()
            {
                base.OnDestroy();
                InteractionManager.SourceDetected -= InteractionManager_SourceDetected;
                InteractionManager.SourceLost -= InteractionManager_SourceLost;

                InteractionManager.SourceReleased -= InteractionManager_SourceReleased;
                InteractionManager.SourcePressed -= InteractionManager_SourcePressed;
            }
        }
}