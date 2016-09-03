using UnityEngine;

class LaserCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Korey")
        {
            GameData.hitCounter++;
            Hud.instance.UpdateScoreLabel();
        }
    }
}