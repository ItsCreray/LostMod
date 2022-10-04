using LostMod.Content.Recipes;
using LostMod.Common.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace LostMod.Content.Items.Accessories
{
	public class AnglerVoodooDoll : ModItem
	{
		public override void SetDefaults() {
			Item.width = 14;
			Item.height = 26;
			Item.value = Item.sellPrice(gold: 2, silver: 15);
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}

		public override void SetStaticDefaults() {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddTile(TileID.Loom)
				.AddCondition(Recipe.Condition.InGraveyardBiome)
				.AddIngredient(ItemID.ClothierVoodooDoll)
				.AddIngredient(ItemID.PurificationPowder, 5)
				.AddRecipeGroup(RecipeGroups.FishingInfoAccessoryRecipeGroup, 5)
				.Register();

		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			VoodooDollPlayer voodooDollPlayer = player.GetModPlayer<VoodooDollPlayer>();
			voodooDollPlayer.AllowKillAngler();
		}
	}
}
