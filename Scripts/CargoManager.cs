using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CargoManager : MonoBehaviour
{
    [SerializeField] public CargoData GlobalCargoData;
    [SerializeField] public CargoData DepositCargoData;
    [SerializeField] public CargoData SubCargoData;

    [SerializeField] public int MaxCargo;
    private int CurrentCargo;
    private int PreviouslyAddedAmount;

    public static event Action AddedItemsToSubCargo;
    public static event Action AddedItemsToDeposit;

#if UNITY_EDITOR
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            CheckCargo();
        }
    }
#endif
    public void AddCargo(ResourceItemData itemData, int quantity)
    {
        int addedCargo = CurrentCargo < MaxCargo ? itemData.Weight : 0;

        SubCargoData.AddResource(itemData, quantity);
        CurrentCargo += addedCargo;
        PreviouslyAddedAmount = addedCargo;

        AddedItemsToSubCargo?.Invoke();
    }

    public void AddSubCargoToDeposit()
    {
        foreach (var resource in SubCargoData.Resources.ToList())
        {
            DepositCargoData.AddResource(resource.Key, resource.Value);
            CurrentCargo -= resource.Key.Weight;
            SubCargoData.RemoveResource(resource.Key, resource.Value);
        }

        AddedItemsToDeposit?.Invoke();
    }

    public void AddDepositToCargoInventory()
    {
        foreach (var resource in DepositCargoData.Resources.ToList())
        {
            GlobalCargoData.AddResource(resource.Key, resource.Value);
            DepositCargoData.RemoveResource(resource.Key, resource.Value);
        }

        CurrentCargo = 0;
    }

    public bool IsCargoFull()
    {
        return CurrentCargo >= MaxCargo;

    }

    public void CheckCargo()
    {
        Debug.Log("Cargo inventory after adding resources:");
        foreach (var entry in SubCargoData.Resources)
        {
            Debug.Log($"Junk in sub cargo {entry.Key}: {entry.Value} units");
        }

        Debug.Log("==============");

        foreach (var entry in DepositCargoData.Resources)
        {
            Debug.Log($"Junk in deposit cargo{entry.Key}: {entry.Value} units");
        }

        Debug.Log("==============");

        foreach (var entry in GlobalCargoData.Resources)
        {
            Debug.Log($"Junk in global cargo{entry.Key}: {entry.Value} units");
        }
    }

}
