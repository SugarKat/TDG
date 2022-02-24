using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject uI;

    public Text upgradeText;
    public Button upgradeButton;
    public Text sellCost;

    private Node target;
    
    public void SetTarget (Node _target)
    {
        target = _target;
        Turret turret = target.turret.GetComponent<Turret>();

        transform.position = target.GetBuildPosition();

        if (target.isUpgraded)
        {
            upgradeText.text = "No More Upgrades!";
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeText.text = "Upgrades";
            upgradeButton.interactable = true;
        }

        sellCost.text = "$" + target.turretBlueprint.sellWorth;

        uI.SetActive(true);
    }
    
    public void Hide ()
    {
        uI.SetActive(false);
    }

    public void Sell ()
    {
        target.SellTurret();
        target.isUpgraded = false;
        BuildManager.instance.DeselectNode();
    }

    public void SetNormalTur()
    {
        
    }
}
