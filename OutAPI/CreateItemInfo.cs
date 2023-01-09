using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace OutAPI
{
    internal class CreateItemInfo 
    {

        private string itemname;
        private string itemDesc;
        private string itemInteractionText;
        private int power;
        private int itemID;
        private bool canEat;
        private bool canEquip;
        private int efficiency;
        private bool isWeapon;
        private bool isTool;
        private bool isRecipe;
        private int mass;
        private int toolTier;
        private int timeToUse;
        private int timeToEat;
        private string useWeaponSound;
        private int toolType;
        private WeaponInfo weaponInfo;
        private ItemInfo.ItemType itemtype;
        private Sprite itemIcon;
        private int effectID = 0;

        public CreateItemInfo(string itemname, [Optional] string itemDesc, [Optional] string itemInteractionText, int power, int itemID, int efficiency, [Optional] int mass, int toolTier, int timeToUse, int timeToEat, int effectID, [Optional]string useWeaponSound, int toolType, WeaponInfo weaponInfo, ItemInfo.ItemType itemtype, Sprite itemIcon)
        {
            this.itemname = itemname;
            this.itemDesc = itemDesc;
            this.itemInteractionText = itemInteractionText;
            this.power = power;
            this.itemID = itemID;
            this.efficiency = efficiency;
            this.mass = mass;
            this.toolTier = toolTier;
            this.effectID = effectID;
            this.timeToUse = timeToUse;
            this.timeToEat = timeToEat;
            this.useWeaponSound = useWeaponSound;
            this.toolType = toolType;
            this.weaponInfo = weaponInfo;
            this.itemtype = itemtype;
            this.itemIcon = itemIcon;
        }



        /*public CreateItemInfo(string ItemName, Sprite ItemSprite, int Power, int Efficiency, int ItemID)
        {
            this.itemname = ItemName;
            this.efficiency = Efficiency;
            this.itemIcon = ItemSprite;
            this.power = Power;
            this.itemID = ItemID;

        }*/
        public void CreateItem()
        {

           try
            {
                ItemInfo PreCreate = new ItemInfo();

                DetermineBool(itemtype);

                PreCreate.itemName = itemname;
                PreCreate.itemDesc = itemDesc;
                PreCreate.interactionDesc = itemInteractionText;
                PreCreate.power = power;
                PreCreate.itemID = itemID;
                PreCreate.canEat = canEat;
                PreCreate.canEquip = canEquip;
                PreCreate.efficiency = efficiency;
                PreCreate.isWeapon = isWeapon;
                PreCreate.isTool = isTool;
                PreCreate.isRecipe = isRecipe;
                PreCreate.mass = mass;
                PreCreate.toolTier = toolTier;
                PreCreate.timeToUse = timeToUse;
                PreCreate.timeToEat = timeToEat;
                PreCreate.effectID = effectID;
                PreCreate.useWeaponSound = useWeaponSound;
                PreCreate.toolType = toolType;
                PreCreate.weaponInfo = weaponInfo;
                PreCreate.itemType = itemtype;
                PreCreate.itemIcon = itemIcon;

                int GetItemIndexForCategory = GetItemTypeIndex(itemtype);

                var Items = ItemList.instance.itemsTypes[GetItemIndexForCategory].itemsList.ToList();
                Items.Add(PreCreate);
                ItemList.instance.itemsTypes[GetItemIndexForCategory].itemsList = Items.ToArray();

                Array.Resize(ref InventoryManager.instance.itemsInInv, InventoryManager.instance.itemsInInv.Length + 1);
                Array.Resize(ref InventoryManager.instance.itemsInInvTotal, InventoryManager.instance.itemsInInvTotal.Length + 1);

                InventoryManager.instance.AddItemToInv(PreCreate, 1, true);

                MelonLoader.MelonLogger.Msg("Item Created");
            }
            catch (Exception ex)
            {
                MelonLoader.MelonLogger.Msg(ex);
            }

        }

        public int GetItemTypeIndex(ItemInfo.ItemType Item)
        {
            if (Item == ItemInfo.ItemType.Material)
                return 0;
            else if (Item == ItemInfo.ItemType.Consumable)
                return 1;
            else if (Item == ItemInfo.ItemType.Artifact)
                return 5;
            else if (Item == ItemInfo.ItemType.Tool)
                return 3;
            else if (Item == ItemInfo.ItemType.Weapon)
                return 4;
            else if (Item == ItemInfo.ItemType.Potion)
                return 2;
            else if (Item == ItemInfo.ItemType.Recipe)
                return 6;
            else return 0;
        }
        public void DetermineBool(ItemInfo.ItemType itemtype)
        {
            if (itemtype == ItemInfo.ItemType.Material)
            {
                canEat = false;
                canEquip = true;
                isWeapon = false;
                isTool = false;
                isRecipe = true;
            }
            if (itemtype == ItemInfo.ItemType.Consumable)
            {
                canEat = true;
                canEquip = true;
                isWeapon = false;
                isTool = false;
                isRecipe = true;
            }
            if (itemtype == ItemInfo.ItemType.Artifact)
            {
                canEat = false;
                canEquip = true;
                isWeapon = false;
                isTool = false;
                isRecipe = true;
            }
            if (itemtype == ItemInfo.ItemType.Tool)
            {
                canEat = false;
                canEquip = true;
                isWeapon = false;
                isTool = true;
                isRecipe = true;
            }
            if (itemtype == ItemInfo.ItemType.Weapon)
            {
                canEat = false;
                canEquip = true;
                isWeapon = true;
                isTool = false;
                isRecipe = true;
            }
            if (itemtype == ItemInfo.ItemType.Potion)
            {
                canEat = true;
                canEquip = true;
                isWeapon = false;
                isTool = false;
                isRecipe = true;
            }
            if (itemtype == ItemInfo.ItemType.Recipe)
            {
                canEat = false;
                canEquip = false;
                isWeapon = false;
                isTool = false;
                isRecipe = true;
            }
        }

    }
}
