using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using Photon.Pun;


using static ClearParticleSystem.CFXR_Effect;

namespace ClearParticleSystem
{
    [RequireComponent(typeof(ParticleSystem))]
    public partial class CFXR_Effect : MonoBehaviour
    {
        ParticleSystem particleSystem;
        public ClearBehavior clearBehavior = ClearBehavior.Destroy;
        [System.NonSerialized] Renderer particleRenderer;
        ParticleSystem rootParticleSystem;

        static int GlobalStartFrameOffset = 0;
        int startFrameOffset;
        const int CHECK_EVERY_N_FRAME = 20;
        public enum ClearBehavior
        {
            None,
            Disable,
            Destroy
        }

        void Awake()
        {
            startFrameOffset = GlobalStartFrameOffset++;

            particleRenderer = this.GetComponent<ParticleSystemRenderer>();
        }

        void Update()
        {
            ParticleFuntion();
        }

        [PunRPC]
        public void ParticleFuntion()
        {
            if (clearBehavior != ClearBehavior.None)
            {
                if (rootParticleSystem == null)
                {
                    rootParticleSystem = this.GetComponent<ParticleSystem>();
                }

                // Check isAlive every N frame, with an offset so that all active effects aren't checked at once
                if ((Time.renderedFrameCount + startFrameOffset) % CHECK_EVERY_N_FRAME == 0)
                {
                    if (!rootParticleSystem.IsAlive(true))
                    {
                        if (clearBehavior == ClearBehavior.Destroy)
                        {
                            GameObject.Destroy(this.gameObject);
                        }
                        else
                        {
                            this.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}

