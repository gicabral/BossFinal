using UnityEngine;

public class CurveRampEnter : MonoBehaviour
{
    public GameObject curveRampObj;
    private CurveRamp scriptRef;
    private SoundController sound;

    void Start()
    {
        scriptRef = curveRampObj.GetComponent<CurveRamp>();
        sound = GameObject.Find("SoundObjects").GetComponent<SoundController>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "ball")
        {
            sound.crank.Play();
            scriptRef.isInRamp = true;
        }
    }
}
