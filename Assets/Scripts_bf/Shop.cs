using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncherTurret;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Tourelle standard sélectionnée");
        buildManager.SelectTurretToBuild(standardTurret);
    }

        public void SelectMissileLauncher()
    {
        Debug.Log("Lance missile sélectionné");
        buildManager.SelectTurretToBuild(missileLauncherTurret);
    }
}
