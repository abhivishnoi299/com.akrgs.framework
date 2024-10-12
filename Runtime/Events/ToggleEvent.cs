using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AKRGS.Framework.Events
{
    [CreateAssetMenu(fileName = "ToggleEvent", menuName = "AKRGS/Framework/ToggleEvent", order = 2)]
    [Serializable]
    public class ToggleEvent : RootEvents<Toggle>
    {

    }
}
