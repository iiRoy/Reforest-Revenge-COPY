using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;
using Platformer.Model;

namespace Platformer.Gameplay
{
    public class RespawnGotas : Simulation.Event<RespawnGotas>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public override void Execute()
        {
            var water = model.water;

            Debug.Log("Respawneando agua");
            Transform[] allChildren = water.GetComponentsInChildren <Transform>();

            Debug.Log("Total de gotas a respawnear " + allChildren.Length);
            for (int a = 0; a < water.transform.childCount; a++)
            {
                water.transform.GetChild(a).gameObject.SetActive(true);
            }
        }
    }
}