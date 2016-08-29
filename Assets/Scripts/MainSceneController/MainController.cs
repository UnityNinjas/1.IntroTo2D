using UnityEngine;

public class MainController : MonoBehaviour
{
    public Moving koreyControls;
    public Laser[] lasers;

    public void Start()
    {
        for (int i = 0; i < this.lasers.Length; i++)
        {
            this.lasers[i].Play();
        }
    }
}