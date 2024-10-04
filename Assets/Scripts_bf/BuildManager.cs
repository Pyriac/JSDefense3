using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singleton
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Il y a déjà un build manager dans la scène");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject standardTurretPrefab;

    public GameObject missileLauncherPrefab;

    private TurretBluePrint turretToBuild;

    public bool canBuild { get { return turretToBuild != null;} }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost;} }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Pas assez d'or pour cela.");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("L'objet a été acheté, il vous reste : " + PlayerStats.money);
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }
}
