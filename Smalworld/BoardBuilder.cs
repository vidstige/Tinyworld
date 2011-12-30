using System;
using System.Collections.Generic;

namespace Smallworld
{
	public static class BoardBuilder
	{
		public static Board CreateTwoPlayer()
		{
			var northsea = new Region(Terrain.Sea);
			var northFarm = new Region(Terrain.Farmland);
			var miningWoods = new Region(Terrain.Wood);
			var caveSwamp = new Region(Terrain.Swamp);
			var northplains = new Region(Terrain.Hill);
			
			var northRim = new Region(Terrain.Mountain);
			var centralPlateu = new Region(Terrain.Hill);
			var lake = new Region(Terrain.Sea);
			var dragonMountain = new Region(Terrain.Mountain);
			var farm = new Region(Terrain.Farmland);
			var magicWoods = new Region(Terrain.Wood);
			
			var whiteCity = new Region(Terrain.Farmland);
			var centralWoods = new Region(Terrain.Wood);
			var centralFarm = new Region(Terrain.Farmland);
			var eastCaveHills = new Region(Terrain.Hill);
			var mineMountain = new Region(Terrain.Mountain);
			
			var magicSwamp = new Region(Terrain.Swamp);
			var westCaveHills = new Region(Terrain.Hill);
			var swampMine = new Region(Terrain.Swamp);
			var southPeak = new Region(Terrain.Mountain);
			var swamps = new Region(Terrain.Swamp);
			var southWood = new Region(Terrain.Wood);
			
			var southSea = new Region(Terrain.Sea);
			
			var edge = Region.Edge;
			
			northsea.ConnectWith(edge);
			northsea.ConnectWith(northFarm);
			northsea.ConnectWith(northRim);
			
			northFarm.ConnectWith(edge);
			northFarm.ConnectWith(northsea);
			northFarm.ConnectWith(northRim);
			northFarm.ConnectWith(miningWoods);
			northFarm.ConnectWith(centralPlateu);
			
			miningWoods.ConnectWith(edge);
			miningWoods.ConnectWith(northFarm);
			miningWoods.ConnectWith(centralPlateu);
			miningWoods.ConnectWith(lake);
			miningWoods.ConnectWith(caveSwamp);
			miningWoods.ConnectWith(dragonMountain);
						
			caveSwamp.ConnectWith(edge);
			caveSwamp.ConnectWith(miningWoods);
			caveSwamp.ConnectWith(dragonMountain);
			caveSwamp.ConnectWith(farm);
			caveSwamp.ConnectWith(northplains);
			
			northplains.ConnectWith(edge);
			northplains.ConnectWith(caveSwamp);
			northplains.ConnectWith(farm);
			northplains.ConnectWith(magicWoods);
			
			northRim.ConnectWith(edge);
			northRim.ConnectWith(northsea);
			northRim.ConnectWith(northFarm);
			northRim.ConnectWith(centralPlateu);
			northRim.ConnectWith(whiteCity);
			
			centralPlateu.ConnectWith(northFarm);
			centralPlateu.ConnectWith(miningWoods);
			centralPlateu.ConnectWith(lake);
			centralPlateu.ConnectWith(centralWoods);
			centralPlateu.ConnectWith(whiteCity);
			centralPlateu.ConnectWith(northRim);
			
			lake.ConnectWith(miningWoods);
			lake.ConnectWith(dragonMountain);
			lake.ConnectWith(centralFarm);
			lake.ConnectWith(centralWoods);
			lake.ConnectWith(centralPlateu);

			dragonMountain.ConnectWith(caveSwamp);
			dragonMountain.ConnectWith(farm);
			dragonMountain.ConnectWith(eastCaveHills);
			dragonMountain.ConnectWith(centralFarm);
			dragonMountain.ConnectWith(lake);
			dragonMountain.ConnectWith(miningWoods);
			
			farm.ConnectWith(caveSwamp);
			farm.ConnectWith(northplains);
			farm.ConnectWith(magicWoods);
			farm.ConnectWith(eastCaveHills);
			farm.ConnectWith(dragonMountain);
			
			magicWoods.ConnectWith(edge);
			magicWoods.ConnectWith(northplains);
			magicWoods.ConnectWith(mineMountain);
			magicWoods.ConnectWith(eastCaveHills);
			magicWoods.ConnectWith(farm);
			
			whiteCity.ConnectWith(edge);
			whiteCity.ConnectWith(northRim);
			whiteCity.ConnectWith(centralPlateu);
			whiteCity.ConnectWith(centralWoods);
			whiteCity.ConnectWith(westCaveHills);
			whiteCity.ConnectWith(magicSwamp);
			
			centralWoods.ConnectWith(centralPlateu);
			centralWoods.ConnectWith(lake);
			centralWoods.ConnectWith(centralFarm);
			centralWoods.ConnectWith(swampMine);
			centralWoods.ConnectWith(westCaveHills);
			centralWoods.ConnectWith(whiteCity);
			
			centralFarm.ConnectWith(dragonMountain);
			centralFarm.ConnectWith(eastCaveHills);
			centralFarm.ConnectWith(swamps);
			centralFarm.ConnectWith(southPeak);
			centralFarm.ConnectWith(swampMine);
			centralFarm.ConnectWith(centralWoods);
			centralFarm.ConnectWith(lake);
			
			eastCaveHills.ConnectWith(farm);
			eastCaveHills.ConnectWith(magicWoods);
			eastCaveHills.ConnectWith(mineMountain);
			eastCaveHills.ConnectWith(southWood);
			eastCaveHills.ConnectWith(swamps);
			eastCaveHills.ConnectWith(centralFarm);
			eastCaveHills.ConnectWith(dragonMountain);
			
			mineMountain.ConnectWith(edge);
			mineMountain.ConnectWith(magicWoods);
			mineMountain.ConnectWith(southSea);
			mineMountain.ConnectWith(southWood);
			mineMountain.ConnectWith(eastCaveHills);
			
			magicSwamp.ConnectWith(edge);
			magicSwamp.ConnectWith(whiteCity);
			magicSwamp.ConnectWith(westCaveHills);
			
			westCaveHills.ConnectWith(edge);
			westCaveHills.ConnectWith(whiteCity);
			westCaveHills.ConnectWith(centralWoods);
			westCaveHills.ConnectWith(swampMine);
			westCaveHills.ConnectWith(magicSwamp);

			swampMine.ConnectWith(edge);
			swampMine.ConnectWith(centralWoods);
			swampMine.ConnectWith(centralFarm);
			swampMine.ConnectWith(southPeak);
			swampMine.ConnectWith(westCaveHills);
			
			southPeak.ConnectWith(edge);
			southPeak.ConnectWith(centralFarm);
			southPeak.ConnectWith(swamps);
			southPeak.ConnectWith(swampMine);
			
			swamps.ConnectWith(edge);
			swamps.ConnectWith(eastCaveHills);
			swamps.ConnectWith(southWood);
			swamps.ConnectWith(southSea);
			swamps.ConnectWith(southPeak);
			swamps.ConnectWith(centralFarm);
			
			southWood.ConnectWith(eastCaveHills);
			southWood.ConnectWith(mineMountain);
			southWood.ConnectWith(southSea);
			southWood.ConnectWith(swamps);
			
			southSea.ConnectWith(edge);
			southSea.ConnectWith(mineMountain);
			southSea.ConnectWith(swamps);
			southSea.ConnectWith(southWood);
			
			return new Board(edge);
		}
	}
}