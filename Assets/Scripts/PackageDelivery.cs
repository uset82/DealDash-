using UnityEngine;

public class PackageDelivery : MonoBehaviour
{
    [Header("Package Settings")]
    public int pointsPerDelivery = 100;
    public Color glowColor = Color.yellow;
    public float pulseSpeed = 2f;

    [Header("Audio")]
    public AudioSource deliverySound;

    private Light packageLight;
    private Renderer packageRenderer;
    private float initialIntensity = 2f;

    void Start()
    {
        packageLight = GetComponentInChildren<Light>();
        if (packageLight == null)
        {
            GameObject lightObj = new GameObject("PackageLight");
            lightObj.transform.parent = transform;
            lightObj.transform.localPosition = Vector3.up * 2f;
            packageLight = lightObj.AddComponent<Light>();
            packageLight.type = LightType.Point;
            packageLight.range = 10f;
            packageLight.intensity = initialIntensity;
            packageLight.color = glowColor;
        }

        packageRenderer = GetComponent<Renderer>();
        if (packageRenderer != null)
        {
            packageRenderer.material.EnableKeyword("_EMISSION");
            packageRenderer.material.SetColor("_EmissionColor", glowColor);
        }
    }

    void Update()
    {
        if (packageLight != null)
        {
            float pulse = Mathf.PingPong(Time.time * pulseSpeed, 1f);
            packageLight.intensity = initialIntensity + pulse;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DeliverPackage();
        }
    }

    void DeliverPackage()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.DeliverPackage(pointsPerDelivery);
        }

        if (deliverySound != null)
        {
            AudioSource.PlayClipAtPoint(deliverySound.clip, transform.position);
        }

        Destroy(gameObject);
    }
}
