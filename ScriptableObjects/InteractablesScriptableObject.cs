using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KG.ScriptableObjects
{
    [CreateAssetMenu(fileName = "InteractableSO", menuName = "InteractableSO")]
    public class InteractablesScriptableObject : ScriptableObject
    {
        public GameObject[] objectArray;
    }

}

