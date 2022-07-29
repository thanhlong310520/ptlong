using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBluePrint turretToBuild;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }
    public GameObject stawndardTurretPrefab;
    public GameObject cannonPrefab;
    Node selectedNote;
    public NodeUI nodeUI;
    private void Start()
    {

    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStart.money < turretToBuild.cost)
        {
            return;
        }
        else
        {
            GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            node.turret = turret;
            PlayerStart.money -= turretToBuild.cost;
        }
        
    }
    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStart.money >= turretToBuild.cost; } }
    public void SelectNode(Node node)
    {
        selectedNote = node;
        turretToBuild = null; // khi chọn ô có tháp thì đặt tháp đang chọn bằng null để không thể xây tháp nữa
        nodeUI.SetTarget(selectedNote);
    }
    public void SelectTurretToBiild(TurretBluePrint turret) 
    {
        turretToBuild = turret;
        selectedNote = null; // khi xây tháp thì k chọn Ô đang xây
        nodeUI.Hide();
    }
    public void UnCkecked()
    {
        turretToBuild = null;
        nodeUI.Hide();
    }
}
