using UnityEngine;

public class CurveRampExit : MonoBehaviour
{
    public GameObject curveRampObj;
    private CurveRamp scriptRef;

    void Start()
    {
        scriptRef = curveRampObj.GetComponent<CurveRamp>();
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.name == "ball" && scriptRef.isInRamp == true)
        {
            scriptRef.isInRamp = false;
        }
    }
}
