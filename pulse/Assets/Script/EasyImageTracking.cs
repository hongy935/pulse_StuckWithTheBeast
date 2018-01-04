using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EasyAR
{
    public class EasyImageTracking : ImageTargetBehaviour
    {
        protected override void Awake() {
            base.Awake();
            TargetFound += OnTargetFound;
            TargetLost += OnTargetLost;
            TargetLoad += OnTargetLoad;
            TargetUnload += OnTargetUnload;
        }
        // Use this for initialization
        protected override void Start()
        {
            base.Start();
            HideObjects(transform);
        }

        void HideObjects(Transform trans)
        {
            for (int i = 0; i < trans.childCount; ++i) {
                trans.GetChild(i).gameObject.SetActive(false);
            }
            
          
                DelegateEventManager.instance.Out();
            
          
        }

        void ShowObjects(Transform trans)
        {
            for (int i = 0; i < trans.childCount; ++i) {
                trans.GetChild(i).gameObject.SetActive(true); 
            }
              
                    
                DelegateEventManager.instance.Over();
               // Debug.Log("trigger delegate");
            
        }


		void OnTargetFound(TargetAbstractBehaviour behaviour)
        {
            ShowObjects(transform);
            Debug.Log("Found: " + Target.Id);
        }

		void OnTargetLost(TargetAbstractBehaviour behaviour)
        {
            HideObjects(transform);
            Debug.Log("Lost: " + Target.Id);
        }

        void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            Debug.Log("Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
        }

        void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
        {
            Debug.Log("Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
        }

    }
}

