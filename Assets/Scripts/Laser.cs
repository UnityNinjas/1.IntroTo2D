using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    public float factor = 0.007f;

    private Transform transformCache;
    private bool isPlaying;

    public void Start()
    {
        this.transformCache = this.transform;
    }

    public void Update()
    {
        if (this.isPlaying)
        {
            TranslateBetween();
        }
    }

    public void Play()
    {
        this.isPlaying = true;
    }

    public void TranslateBetween()
    {
        if (this.transformCache.localPosition.y <= this.maxDistance ||
            this.transformCache.localPosition.y >= this.minDistance)
        {
            this.factor = -this.factor;
        }

        this.transformCache.localPosition = new Vector2(
            this.transformCache.localPosition.x,
            this.transformCache.localPosition.y + this.factor);
    }
}