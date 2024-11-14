using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CargoData", order = 0)]
public class CargoData : ScriptableObject
{
    public Dictionary<ResourceItemData, int> Resources = new Dictionary<ResourceItemData, int>();

    public void AddResource(ResourceItemData item, int quantity)
    {
        if (Resources.ContainsKey(item))
        {
            Resources[item] += quantity;
        }
        else
        {
            Resources.Add(item, quantity);
        }
    }

    public void RemoveResource(ResourceItemData item, int amount)
    {
        if (Resources.ContainsKey(item))
        {
            Resources[item] = Mathf.Max(0, Resources[item] - amount);
        }
    }

    public int GetResourceAmount(ResourceType resourceType) 
    {
        foreach (var item in Resources)
        {
            if (item.Key.ResourceType == resourceType)
            {
                return item.Value;
            }
        }
        return 0;
    }

    public ResourceItemData GetResourceDataType(ResourceType resourceType)
    {
        return Resources.Keys.FirstOrDefault(x => x.ResourceType == resourceType);
    }

}
