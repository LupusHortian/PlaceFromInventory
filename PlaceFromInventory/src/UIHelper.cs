using UnityEngine;
using Common;
using Il2Cpp;
using HarmonyLib;

namespace PlaceFromInventory
{
	static class UIHelper
	{
		static bool backToInvPanel = false;
		static bool backToClothPanel = false;

		public static Panel_Inventory invPanel => InterfaceManager.GetPanel<Panel_Inventory>();
		public static Panel_Clothing clothPanel => InterfaceManager.GetPanel<Panel_Clothing>();

		public static void hideCurrentPanel()
		{
			if (backToInvPanel = invPanel.IsEnabled())		invPanel.Enable(false);
			if (backToClothPanel = clothPanel.IsEnabled())	clothPanel.Enable(false);									//$"UIHelper.hideCurrentPanel: invPanel: {backToInvPanel}, clothPanel: {backToClothPanel }".logDbg();
		}

		public static void restorePreviousPanel()
		{
			if (backToInvPanel)	  invPanel.Enable(true);
			if (backToClothPanel) clothPanel.Enable(true);

			 backToInvPanel = backToClothPanel = false;
		}

		public static void startPlaceObject(GameObject go, PlaceMeshFlags flags = PlaceMeshFlags.None)
		{
			hideCurrentPanel();
			GameUtils.PlayerManager.StartPlaceMesh(go, flags);
		}
	}
}