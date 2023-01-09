using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(OutAPI.Core),"OutAPI","0.0.1","RSM")]
namespace OutAPI
{
    public class Core : MelonMod
    {
        [Obsolete("Bullshit.")]
        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                CreateItemInfo Potion = new CreateItemInfo("Epic Potion","Blah","Press [E]",100, ItemList.instance.itemList.Length + 1, 100,1,1,1,1,1,null,1,null,ItemInfo.ItemType.Potion,null);

                CreateItemInfo Artifact = new CreateItemInfo("Epic Potion", "Blah", "Press [E]", 100, ItemList.instance.itemList.Length + 1, 100, 1, 1, 1, 1, 1, null, 1, null, ItemInfo.ItemType.Artifact, null);

                CreateItemInfo Weapon = new CreateItemInfo("Epic Weapon","Blah","Press [E]",100, ItemList.instance.itemList.Length + 1, 100,1,1,1,1,1,null,1,null,ItemInfo.ItemType.Weapon,null);

                Potion.CreateItem();

                Weapon.CreateItem();

                Artifact.CreateItem();

            }
        }

    }
}
