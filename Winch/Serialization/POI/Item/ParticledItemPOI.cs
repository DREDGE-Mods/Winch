﻿using UnityEngine;

namespace Winch.Serialization.POI.Item;

public class ParticledItemPOI : ItemPOI
{
    [SerializeField]
    public GameObject harvestParticlePrefab;

    public new void Start()
    {
        GameObject particlePrefab = harvestParticlePrefab;
        if (particlePrefab == null)
        {
            particlePrefab = Harvestable.GetParticlePrefab();
        }
        if (particlePrefab != null)
        {
            GameObject gameObject = Instantiate(particlePrefab, transform);
            harvestParticles = gameObject.GetComponent<HarvestableParticles>();
        }
        else
        {
            Debug.LogWarning("Couldn't find particle prefab for: " + name);
        }
        if (harvestParticles != null)
        {
            ItemData firstItem = harvestable.GetFirstItem();
            if (firstItem && firstItem.overrideHarvestParticleDepth)
            {
                harvestParticles.SetHarvestParticleOverride(firstItem.harvestParticleDepthOffset, firstItem.flattenParticleShape);
            }
        }
        OnStockUpdated();
    }

    public void AddStock()
    {
        if (Stock == 0)
        {
            Harvestable.AddStock(1, false);
            OnStockUpdated();
        }
    }
}


