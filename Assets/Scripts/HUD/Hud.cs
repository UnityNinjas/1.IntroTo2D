using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField]
    private Text score;
    internal static Hud instance;

    public void Awake()
    {
        instance = this.GetComponent<Hud>();
    }

    public void UpdateScoreLabel()
    {
        this.score.text = "Laser hits: " + GameData.hitCounter;
    }
}
