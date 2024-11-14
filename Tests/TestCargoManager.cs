using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class TestCargoManager
{
    private CargoManager cargoManager;
    private ResourceItemData junkResourceItemData;
    private ResourceItemData biomassResourceItemData;
    private int initalCargoValue;

    [SetUp]
    public void SetUp()
    {
        GameObject testObject = new GameObject("TestObject");
        cargoManager = testObject.AddComponent<CargoManager>();

        cargoManager = new CargoManager();
        cargoManager.SubCargoData = ScriptableObject.CreateInstance<CargoData>();
        cargoManager.DepositCargoData = ScriptableObject.CreateInstance<CargoData>();
        cargoManager.GlobalCargoData = ScriptableObject.CreateInstance<CargoData>();
        cargoManager.MaxCargo = initalCargoValue;

        junkResourceItemData = ScriptableObject.CreateInstance<ResourceItemData>();
        junkResourceItemData.ResourceType = ResourceType.JUNK;

        biomassResourceItemData = ScriptableObject.CreateInstance<ResourceItemData>();
        biomassResourceItemData.ResourceType = ResourceType.BIOMASS;
    }

    [Test]
    public void TestCargoTransfer()
    {
        cargoManager.AddCargo(biomassResourceItemData,10);
        cargoManager.AddCargo(junkResourceItemData,1234);

        cargoManager.AddSubCargoToDeposit();

        Assert.AreEqual(10,cargoManager.DepositCargoData.Resources[biomassResourceItemData]);
        Assert.AreEqual(1234, cargoManager.DepositCargoData.Resources[junkResourceItemData]);
        Assert.AreEqual(0, cargoManager.SubCargoData.Resources[biomassResourceItemData]);
        Assert.AreEqual(0, cargoManager.SubCargoData.Resources[junkResourceItemData]);
        Assert.AreEqual(2, cargoManager.DepositCargoData.Resources.Count);
    }


}
