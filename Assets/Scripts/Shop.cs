using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    public TurretBlueprint flameThrower;
    public TurretBlueprint sniperTurret;

    BuildManager buildManager;
    Node nodeUpgrade;
    Node upgradeNode = null;

    public GameObject Upgrades;
    public GameObject Turret;

    void Start ()
    {
        buildManager = BuildManager.instance;
    }

    public void ShowUpgrades ()
    {
        upgradeNode = buildManager.selectedNode;
        Upgrades.SetActive(true);
        Turret.SetActive(false);
    }

    public void HideUpgrades ()
    {
        Upgrades.SetActive(false);
        Turret.SetActive(true);
    }

    public void SelectStandartTurret ()
    {
        Debug.Log("Standart Turret Selected");
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissileLauncher ()
    {
        /*Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);*/

        buildManager.SelectTurretToUpgrade(missileLauncher);
        upgradeNode.UpgradeTurret(buildManager.GetTurretToUpgrade());
    }
    public void SelectLaserBeamer()
    {
        /*Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);*/

        buildManager.SelectTurretToUpgrade(laserBeamer);
        upgradeNode.UpgradeTurret(buildManager.GetTurretToUpgrade());
    }
    public void SelectFlameThrower()
    {
        /*Debug.Log("Flame Thrower Selected");
        buildManager.SelectTurretToBuild(flameThrower);*/

        buildManager.SelectTurretToUpgrade(flameThrower);
        upgradeNode.UpgradeTurret(buildManager.GetTurretToUpgrade());
    }

    public void SelectSniperTurret()
    {
        /*Debug.Log("Sniper Turret Selected");
        buildManager.SelectTurretToBuild(sniperTurret);*/

        buildManager.SelectTurretToUpgrade(sniperTurret);
        upgradeNode.UpgradeTurret(buildManager.GetTurretToUpgrade());
    }
}
