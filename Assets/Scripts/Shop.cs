using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint cannonTurret;
    public Text costCannon;
    public Text costStandard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        costStandard.text ="$" + standardTurret.cost.ToString();
        costCannon.text ="$" + cannonTurret.cost.ToString();

    }

    public void SelectStandardTurret()
    {
        BuildManager.instance.SelectTurretToBiild(standardTurret);
    }
    public void SelectCannonTurret()
    {
        BuildManager.instance.SelectTurretToBiild(cannonTurret);
    }

    
}
