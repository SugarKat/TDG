using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;

    private TurretBlueprint turretToBuild;
    private TurretBlueprint turretToUpgrade;
    [HideInInspector]
    public Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool CanUpgrade { get { return turretToUpgrade != null; } }
    public bool HasMoneyToBuild { get { return PlayerStats.Money >= turretToBuild.cost; } }
    public bool HasMoneyToUpgrade { get { return PlayerStats.Money >= turretToUpgrade.cost; } }

    public void SelectNode (Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void SelectTurretToUpgrade(TurretBlueprint upgradeTurret)
    {
        turretToUpgrade = upgradeTurret;
    }

    public TurretBlueprint GetTurretToBuild ()
    {
        return turretToBuild;
    }

    public TurretBlueprint GetTurretToUpgrade ()
    {
        return turretToUpgrade;
    }

}
