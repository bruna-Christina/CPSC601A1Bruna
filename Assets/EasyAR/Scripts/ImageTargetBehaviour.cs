//=============================================================================================================================
//
// Copyright (c) 2015-2017 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
// EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
// and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
//
//=============================================================================================================================

using System.Collections.Generic;
using UnityEngine;

namespace EasyAR
{
    public class ImageTargetBehaviour : ImageTargetBaseBehaviour
    {
        //public Dictionary<string, bool> dictTargets = null;

        protected override void Awake()
        {
            base.Awake();
            TargetFound += OnTargetFound;
            TargetLost += OnTargetLost;
            TargetLoad += OnTargetLoad;
            TargetUnload += OnTargetUnload;
            //dictTargets = new Dictionary<string, bool>();
        }

        void OnTargetFound(TargetAbstractBehaviour behaviour)
        {
            Debug.Log(">>> Found: " + Target.Id + ": " + Target.Name);
            //if (dictTargets.ContainsKey(Target.Name))
            //{
            //    dictTargets[Target.Name] = true;
            //}
            //else
            //{
            //    Debug.LogError("Target: " + Target.Name + " not loaded.");
            //}
            //Debug.Log(">>> Position" + this.transform.position + ">> " + this.transform.localPosition);
        }

        void OnTargetLost(TargetAbstractBehaviour behaviour)
        {
            Debug.Log(">>> Lost: " + Target.Id + ": " + Target.Name);
            //if (dictTargets.ContainsKey(Target.Name))
            //{
            //    dictTargets[Target.Name] = false;
            //}
            //else
            //{
            //    Debug.LogError("Target: " + Target.Name + " not loaded.");
            //}
        }

        void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            Debug.Log(">>> Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
            //if (!dictTargets.ContainsKey(Target.Name))
            //{
            //    dictTargets.Add(Target.Name, true);
            //    //Debug.Log(">> Loading " + Target.Name);
            //}
        }

        void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            Debug.Log(">>> Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
            //if (!dictTargets.ContainsKey(Target.Name))
            //{
            //    dictTargets.Remove(Target.Name);
            //    //Debug.Log(">> Unloading " + Target.Name);
            //}
        }

        protected override void Update()
        {
            //Debug.Log(">>>> UPDATE<<<<< " + this.Target.Name + " > Pos: " + this.transform.position + "> Local pos: " + this.transform.localPosition);
        }
    }
}
