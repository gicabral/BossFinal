using UnityEngine;

public class LaunchListener : MonoBehaviour
{
    private Launcher launcherScript;

    void Start()
    {
        GameObject launcherObj = GameObject.Find("Plunger-springjoint");
        launcherScript = launcherObj.GetComponent<Launcher>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "ball")
        {
            launcherScript.isActive = false;
        }
    }
}
