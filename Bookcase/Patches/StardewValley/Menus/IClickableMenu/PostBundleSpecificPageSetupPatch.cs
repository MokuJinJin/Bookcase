﻿using Bookcase.Events;
using StardewValley.Menus;
using System;
using System.Reflection;

namespace Bookcase.Patches {
    /// <summary>
    /// Code run everytime a bundle is 'setup', essentially allowing you the ability to inject information into an already created bundle's display.
    /// </summary>
    public class PostBundleSpecificPageSetupPatch : IGamePatch {
        public Type TargetType => typeof(JunimoNoteMenu);

        public MethodBase TargetMethod => TargetType.GetMethod("setUpBundleSpecificPage", BindingFlags.NonPublic | BindingFlags.Instance);

        public static void Postfix(JunimoNoteMenu __instance, Bundle b) {
            BookcaseEvents.PostBundleSpecificPageSetup.Post(new PostBundleSetupEvent(__instance.ingredientList, __instance.ingredientSlots, __instance.inventory, b));
        }
    }
}
