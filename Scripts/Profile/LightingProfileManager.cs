using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WizardsCode.Profile
{
    public class LightingProfileManager : GameObjectProfileManager
    {
        [Tooltip("In this profile enable or disable fog.")]
        public bool[] fogEnabled = Enumerable.Repeat(true, Enum.GetNames(typeof(GameObjectProfileManager.Profiles)).Length).ToArray();

        public override void Configure(Profiles profile)
        {
            RenderSettings.fog = fogEnabled[(int)profile];

            base.Configure(profile);
        }
    }
}
