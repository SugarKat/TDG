using UnityEngine;
using System.Collections;

public class UpgradesConfirms : MonoBehaviour
{

    public GameObject confirmMissileLauncher;
    public GameObject confirmLaserBeamer;
    public GameObject confirmFlameThrower;
    

    Node upgradeNode = null;
    BuildManager buildManager;

    public void OnEnable ()
    {
        buildManager = BuildManager.instance;
        upgradeNode = buildManager.selectedNode;
    }

    public void ShowMissileConfirm ()
    {
        confirmMissileLauncher.SetActive(true);
    }

    public void ConfirmMissileConfirm()
    {
        confirmMissileLauncher.SetActive(false);

        upgradeNode.UpgradeTurret(buildManager.GetTurretToUpgrade());
    }

    public void ShowLaserConfirm()
    {
        confirmLaserBeamer.SetActive(true);
    }

    public void ConfirmLaserConfirm ()
    {
        confirmLaserBeamer.SetActive(false);

        upgradeNode.UpgradeTurret(buildManager.GetTurretToUpgrade());
    }

    public void ShowFlameConfirm()
    {
        confirmFlameThrower.SetActive(true);
    }

    public void ConfirmFlameConfirm()
    {
        confirmFlameThrower.SetActive(false);

        upgradeNode.UpgradeTurret(buildManager.GetTurretToUpgrade());
    }

}
