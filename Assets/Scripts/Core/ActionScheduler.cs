using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGProject.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAciton;

        public void StartAciton(IAction action)
        {
            if(currentAciton == action) return;
            if(currentAciton != null)
            {
                currentAciton.Cancel();
            }
            
            currentAciton = action;
        }
    }
}


