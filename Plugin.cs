using BepInEx;
using SlugBase.Features;
using static SlugBase.Features.FeatureTypes;

namespace SlugExpansion
{
    [BepInDependency("com.dual.improved-input-config", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("nc.slugexpansion", "SlugExpansion", "1.0.0")]
    class Plugin : BaseUnityPlugin
    {

        public static readonly PlayerFeature<bool> DualSpear = PlayerBool("SlugExpansion/double_spear");
        ///public static readonly PlayerFeature<string[]> DoubleObjectHolding = PlayerStrings("SlugExpansion/double_spear");


        // Add hooks
        public void OnEnable()
        {
            // Put your custom hooks here!
            On.Player.Grabability += Player_DoubleSpear;
        }

        // Implement SuperJump
        public Player.ObjectGrabability Player_DoubleSpear(On.Player.orig_Grabability orig, Player self, PhysicalObject obj)
        {
            if (obj is Weapon)
            {
                if (DualSpear.TryGet(self, out bool doublespearbool) && doublespearbool)
                {
                    return (Player.ObjectGrabability)1;
                }
            }
            return orig.Invoke(self, obj);
        }
    }
}