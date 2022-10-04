using System;
using System.Collections.Generic;
using Terraria;

namespace LostMod.Utils
{
	public static class NPCUtils
	{

		public static NPC SearchFirstWithType(int npcId) {
			return !NPC.npcsFoundForCheckActive[npcId] ?
				null : SearchFirst(npc => npc.type == npcId);
		}

		public static NPC SearchFirst(Func<NPC, bool> filter) {
			foreach (NPC npc in Main.npc) {
				if (npc.active && filter(npc)) {
					return npc;
				}
			}
			return null;
		}

		public static List<NPC> SearchAll(Func<NPC, bool> filter) {
			List<NPC> npcs = new List<NPC>();
			foreach (NPC npc in Main.npc) {
				if (npc.active && filter(npc)) {
					npcs.Add(npc);
				}
			}
			return npcs;
		}
	}
}
