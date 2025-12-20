using UnityEngine;

public class BoostItemBehavior : MonoBehaviour
{
    [SerializeField] public float shrinkDuration = 5f; // Time it takes to shrink and disappear
    [SerializeField] public float delayBeforeShrink = 3f; // Time before shrinking starts
    public Material redMaterial; // Assign the red shader material in the Inspector

    private Vector3 initialScale;
    private float shrinkTimer;
    private bool isShrinking = false;

    private void Start()
    {
        initialScale = transform.localScale;
        shrinkTimer = shrinkDuration;
        Invoke(nameof(StartShrinking), delayBeforeShrink); // Start shrinking after the delay
    }

    private void StartShrinking()
    {
        isShrinking = true;
        GetComponent<SpriteRenderer>().material = redMaterial; // Change to red material
    }

    private void Update()
    {
        if (isShrinking)
        {
            // Shrink the Boost Item over time
            shrinkTimer -= Time.deltaTime;
            float scaleFactor = Mathf.Clamp01(shrinkTimer / shrinkDuration);
            transform.localScale = initialScale * scaleFactor;

            // Destroy the Boost Item when it becomes too small
            if (shrinkTimer <= 0)
            {
                BoostItemManager.Instance.RespawnBoostItem(); // Call the manager to respawn the Boost Item FIRST
                Destroy(gameObject); // Then destroy this object
            }
        }
    }
}