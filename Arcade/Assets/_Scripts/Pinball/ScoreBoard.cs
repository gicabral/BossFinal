using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private TextMesh text3D;
    private Renderer textRenderer;

    public int gamescore = 0;
    public string displaytext = "SCORE";

    // Use this for initialization
    void Start()
    {
        textRenderer = GetComponent<Renderer>();
        textRenderer.sortingLayerName = "Top";
        text3D = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
    }

    void Update()
    {
        text3D.text = displaytext + ": " + gamescore;
    }
}
