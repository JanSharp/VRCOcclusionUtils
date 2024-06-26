﻿using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace JanSharp
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class OcclusionPortalsToggleArea : UdonSharpBehaviour
    {
        [Tooltip("When the player is inside of trigger colliders that are on this game objects, the portals "
            + "will be open. Multiple colliders are supported, all are forced to be triggers automatically.\n"
            + "The default open state of all these portals will be overwritten on Start."
        )]
        public OcclusionPortal[] portals;
        [Tooltip("An optimization to reduce chance of issues when using only 1 trigger collider.")]
        [SerializeField] private bool singleColliderMode = false;
        private int triggerCount;

        private void Start()
        {
            Close();
        }

        private void Open()
        {
            foreach (OcclusionPortal portal in portals)
                if (portal != null)
                    portal.open = true;
        }

        private void Close()
        {
            foreach (OcclusionPortal portal in portals)
                if (portal != null)
                    portal.open = false;
        }

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            if (!player.isLocal)
                return;
            if (singleColliderMode)
            {
                Open();
                return;
            }
            triggerCount++;
            if (triggerCount == 1)
                Open();
        }

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            if (!player.isLocal)
                return;
            if (singleColliderMode)
            {
                Close();
                return;
            }
            // Checking for zero to handle cases where we didn't get the enter event.
            if (triggerCount == 0)
                return;
            triggerCount--;
            if (triggerCount == 0)
                Close();
        }
    }
}
