using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [Header("Car Physics")]
    public float motorPower = 1500f;
    public float brakePower = 3000f;
    public float steerAngle = 30f;
    public float wheelGrip = 0.8f;

    [Header("Wheel Colliders")]
    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public WheelCollider rearLeft;
    public WheelCollider rearRight;

    [Header("Audio")]
    public AudioSource engineSound;
    public AudioSource tireSquealSound;
    public AudioSource rainSound;
    public float enginePitchMin = 0.8f;
    public float enginePitchMax = 2.0f;

    [Header("Camera")]
    public Transform cameraTarget;
    public float cameraDistance = 6f;
    public float cameraHeight = 2f;
    public float shakeIntensity = 0.05f;

    private Rigidbody rb;
    private float currentSteer = 0f;
    private float currentMotor = 0f;
    private float currentBrake = 0f;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.5f, 0);
        mainCamera = Camera.main;

        if (rainSound != null && !rainSound.isPlaying)
        {
            rainSound.loop = true;
            rainSound.Play();
        }

        if (engineSound != null && !engineSound.isPlaying)
        {
            engineSound.loop = true;
            engineSound.Play();
        }
    }

    void Update()
    {
        HandleInput();
        UpdateAudio();
        UpdateCamera();
    }

    void FixedUpdate()
    {
        ApplyMotor();
        ApplySteering();
        ApplyBrake();
    }

    void HandleInput()
    {
        currentSteer = Input.GetAxis("Horizontal") * steerAngle;
        currentMotor = Input.GetAxis("Vertical") * motorPower;
        currentBrake = Input.GetKey(KeyCode.Space) ? brakePower : 0f;
    }

    void ApplyMotor()
    {
        rearLeft.motorTorque = currentMotor;
        rearRight.motorTorque = currentMotor;
    }

    void ApplySteering()
    {
        frontLeft.steerAngle = currentSteer;
        frontRight.steerAngle = currentSteer;
    }

    void ApplyBrake()
    {
        frontLeft.brakeTorque = currentBrake;
        frontRight.brakeTorque = currentBrake;
        rearLeft.brakeTorque = currentBrake;
        rearRight.brakeTorque = currentBrake;
    }

    void UpdateAudio()
    {
        if (engineSound != null)
        {
            float speed = rb.velocity.magnitude;
            float pitch = Mathf.Lerp(enginePitchMin, enginePitchMax, speed / 30f);
            engineSound.pitch = pitch;
        }

        if (tireSquealSound != null)
        {
            bool isSkidding = Mathf.Abs(currentSteer) > 15f && rb.velocity.magnitude > 5f;
            if (isSkidding && !tireSquealSound.isPlaying)
            {
                tireSquealSound.Play();
            }
            else if (!isSkidding && tireSquealSound.isPlaying)
            {
                tireSquealSound.Stop();
            }
        }
    }

    void UpdateCamera()
    {
        if (mainCamera != null && cameraTarget != null)
        {
            Vector3 targetPos = cameraTarget.position - cameraTarget.forward * cameraDistance + Vector3.up * cameraHeight;
            Vector3 shake = Random.insideUnitSphere * shakeIntensity * rb.velocity.magnitude * 0.05f;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPos + shake, Time.deltaTime * 5f);
            mainCamera.transform.LookAt(cameraTarget.position + Vector3.up);
        }
    }
}
