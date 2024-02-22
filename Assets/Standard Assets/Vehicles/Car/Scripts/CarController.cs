using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    internal enum CarDriveType
    {
        FrontWheelDrive,
        RearWheelDrive,
        FourWheelDrive
    }

    internal enum SpeedType
    {
        MPH,
        KPH
    }
    internal enum GearType
    {
        Auto,
        Manual
    }

    public class CarController : MonoBehaviour
    {
        [SerializeField] private CarDriveType m_CarDriveType = CarDriveType.FourWheelDrive;
        [SerializeField] private SpeedType m_SpeedType = SpeedType.KPH;
        [SerializeField] private GearType m_GearType = GearType.Auto;
        [SerializeField] private WheelCollider[] m_WheelColliders = new WheelCollider[4];
        [SerializeField] private GameObject[] m_WheelMeshes = new GameObject[4];
        [SerializeField] private WheelEffects[] m_WheelEffects = new WheelEffects[4];
        [SerializeField] private Vector3 m_CentreOfMassOffset;
        [SerializeField] private float m_MaximumSteerAngle = 35; //góc lái tối đa
        [SerializeField] private float m_MinSteerAngle = 10;                                                      //
        [Range(0, 1)] [SerializeField] private float m_SteerHelper; // 0 is raw physics , 1 the car will grip in the direction it is facing
        [Range(0, 1)] [SerializeField] private float m_TractionControl; //kiểm soát lực kéo, 0 không can thiệp, 1 can thiệp hoàn toàn
        [SerializeField] private bool m_InstantAcceleration; // có hay không gia tốc tức thời. dùng cho các siêu xe. khi có thì ở GearNum == 1  => motorTorque = m_MaxAcceleration
        [SerializeField] private bool m_AccelerationLimit; // có hay không giới hạn gia tốc, nếu có thì chỉ dùng lực đẩy từ m_FullTorqueOverAllWheels, không dùng m_Acceleration
        [SerializeField] private float m_MaxAcceleration = 30000f; // gia tốc tối đa
        [SerializeField] private float m_Acceleration = 1000f;
        [SerializeField] private float m_FullTorqueOverAllWheels;
        [SerializeField] private float m_ReverseTorque; // lực xoắn ngược
        [SerializeField] private float m_MaxHandbrakeTorque; // lực phanh max
        [SerializeField] private float m_Downforce = 100f;
        
        [SerializeField] private float m_Topspeed = 250;
        [SerializeField] private static int NoOfGears = 5;
        [SerializeField] private float m_RevRangeBoundary = 0.8f;
        [SerializeField] private float m_SlipLimit;
        [SerializeField] private float m_BrakeTorque;
        public float MySteerHelper = 0.66f;
        private Quaternion[] m_WheelMeshLocalRotations;
        private Vector3 m_Prevpos, m_Pos;
        private float m_SteerAngle;
        private int m_GearNum;
        private float m_GearFactor;
        private float m_OldRotation;
        private float m_CurrentTorque;
        private Rigidbody m_Rigidbody;
        private const float k_ReversingThreshold = 0.01f;
        [SerializeField] float m_BoxReduceSpeed = 10f;//hộp giảm tốc
        public bool Player = true;
        public float BoxReduceSpeed { get { return m_BoxReduceSpeed;} } 
        public bool Skidding { get; private set; }
        public float BrakeInput { get; private set; }
        public float CurrentSteerAngle{ get { return m_SteerAngle; }}
        public float CurrentSpeed{ get { return m_Rigidbody.velocity.magnitude* 3.6f; }}
        public float MaxSpeed{get { return m_Topspeed; }}
        public float Revs { get; private set; }
        public float AccelInput { get; private set; }

        // Use this for initialization
        private void Start()
        {
            m_WheelMeshLocalRotations = new Quaternion[4];
            for (int i = 0; i < 4; i++)
            {
                m_WheelMeshLocalRotations[i] = m_WheelMeshes[i].transform.localRotation;
            }
            m_WheelColliders[0].attachedRigidbody.centerOfMass = m_CentreOfMassOffset;

            m_MaxHandbrakeTorque = float.MaxValue;

            m_Rigidbody = GetComponent<Rigidbody>();
            m_CurrentTorque = m_FullTorqueOverAllWheels - (m_TractionControl*m_FullTorqueOverAllWheels);
            if (CompareTag("Player"))
            {
                SaveScript.Topspeed = m_Topspeed;
            }
            m_GearNum = 0;
            
        }

        private void Update()
        {
            if (Player == true)
            {
                SaveScript.speed = CurrentSpeed;
                SaveScript.Gear = m_GearNum;
                switch (m_SpeedType)
                {
                    case SpeedType.MPH:
                        SaveScript.typeSpeed = "MPH";
                        break;
                    case SpeedType.KPH:
                        SaveScript.typeSpeed = "KPH";
                        break;
                }
            }
            if(SaveScript.BrakeSlide == true)
            {
                m_SteerHelper = 0.99f;
            }
            if(SaveScript.BrakeSlide == false)
            {
                m_SteerHelper = MySteerHelper;
            }
        }
        private void AnimationWheel()
        {
            for (int i = 0; i < 4; i++)
            {
                Quaternion quat;
                Vector3 position;
                m_WheelColliders[i].GetWorldPose(out position, out quat);
                m_WheelMeshes[i].transform.position = position;
                m_WheelMeshes[i].transform.rotation = quat;
            }
        }
        private void GearChanging()
        {
            float f = Mathf.Abs(CurrentSpeed / MaxSpeed);
            switch (m_GearType)
            {
                case GearType.Auto:    
                    if (AccelInput > 0 && f < 0.1)
                    {
                        m_GearNum = 1;
                    }
                    if (BrakeInput != 0 && f < 0.1)
                    {
                        m_GearNum = -1;
                    }
                    if (m_GearNum > 0 && f < GearBoxCoefficientDown())
                    {
                        m_GearNum--;
                    }
                    if (f >= GearBoxCoefficient() && m_GearNum < NoOfGears && f !=0)
                    {
                        m_GearNum++;                        
                    }
                    
                    break;
                case GearType.Manual:
                    if ((Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus)) && m_GearNum < NoOfGears) 
                    { 
                        m_GearNum++;
                    }   
                    else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus)) 
                    { 
                        m_GearNum--;
                        if (m_GearNum < -1)
                        {
                            m_GearNum = -1;
                        }
                    }
                    if (m_GearNum > 0 && f < GearBoxCoefficientDown())
                    {
                        m_GearNum--;
                        if (m_GearNum < -1 && BrakeInput != 0)
                        {
                            m_GearNum = -1;
                        }
                    }
                    break;
            }
        }

        // simple function to add a curved bias towards 1 for a value in the 0-1 range
        private static float CurveFactor(float factor)
        {
            return 1 - (1 - factor)*(1 - factor);
        }


        // unclamped version of Lerp, to allow value to exceed the from-to range
        private static float ULerp(float from, float to, float value)
        {
            return (1.0f - value)*from + value*to;
        }


        private void CalculateGearFactor() //tính hệ số bánh răng
        {
            float f = (1/(float) NoOfGears);
            // gear factor is a normalised representation of the current speed within the current gear's range of speeds.
            // We smooth towards the 'target' gear factor, so that revs don't instantly snap up or down when changing gear.
            var targetGearFactor = Mathf.InverseLerp(f*m_GearNum, f*(m_GearNum + 1), Mathf.Abs(CurrentSpeed/MaxSpeed));
            m_GearFactor = Mathf.Lerp(m_GearFactor, targetGearFactor, Time.deltaTime*5f);
        }


        private void CalculateRevs() // tính toán số vòng quay
        {
            // calculate engine revs (for display / sound)
            // (this is done in retrospect - revs are not used in force/power calculations)
            CalculateGearFactor();
            var gearNumFactor = m_GearNum/(float) NoOfGears;
            var revsRangeMin = ULerp(0f, m_RevRangeBoundary, CurveFactor(gearNumFactor));
            var revsRangeMax = ULerp(m_RevRangeBoundary, 1f, gearNumFactor);
            Revs = ULerp(revsRangeMin, revsRangeMax, m_GearFactor);
        }

        //steering : bánh lái
        //accel : tiến
        //footbrake : lùi
        //handbrake : phanh
        public void Move(float steering, float accel, float footbrake, float handbrake)
        {
            AnimationWheel();
            
            steering = Mathf.Clamp(steering, -1, 1);

            AccelInput = accel = Mathf.Clamp(accel, 0, 1);
            BrakeInput = footbrake = -1*Mathf.Clamp(footbrake, -1, 0);
            handbrake = Mathf.Clamp(handbrake, 0, 1); 
            
            SteeringCar(steering);
            SteerHelper();
            switch (m_GearType)
            {
                case GearType.Auto:
                    AutoDrive(accel, footbrake);
                    break;
                case GearType.Manual:
                    ManualDrive(accel, footbrake);
                    break;
            }
            CapSpeed();            
            CalculateRevs();
            GearChanging();
            AddDownForce();
            if (handbrake > 0f)
            {
                var hbTorque = handbrake * m_MaxHandbrakeTorque;
                m_WheelColliders[2].brakeTorque = hbTorque;
                m_WheelColliders[3].brakeTorque = hbTorque;
                ReduceSpeed();
            }
            else
            {
                m_WheelColliders[2].brakeTorque = 0;
                m_WheelColliders[3].brakeTorque = 0;
            }    
            
            CheckForWheelSpin();
            TractionControl();
        }
        private void SteeringCar(float steering)
        {
            float constSP = 3.6f;            
            switch (m_SpeedType)
            {
                case SpeedType.MPH:
                    constSP = 3.6f;
                    break;
                case SpeedType.KPH:
                    constSP = 2.23693629f;
                    break;
            }
            if (SaveScript.OnTheRoad == true)
            {
                float speed = m_Rigidbody.velocity.magnitude * constSP;
                float highSpeedFraction = Mathf.Abs((speed * 2f) / ((MaxSpeed / 3.6f) * constSP));
                float actualSteerAngle = Mathf.Lerp(m_MaximumSteerAngle, m_MinSteerAngle, highSpeedFraction);
                m_SteerAngle = steering * actualSteerAngle;
                m_WheelColliders[0].steerAngle = m_SteerAngle;
                m_WheelColliders[1].steerAngle = m_SteerAngle;
            }
            if (SaveScript.OnTheTerrain == true)
            {
                float speed = m_Rigidbody.velocity.magnitude * constSP;
                float highSpeedFraction = Mathf.Abs((speed) / ((MaxSpeed / 3.6f) * constSP));
                float actualSteerAngle = Mathf.Lerp(m_MaximumSteerAngle, m_MinSteerAngle, highSpeedFraction);
                m_SteerAngle = steering * actualSteerAngle;
                m_WheelColliders[0].steerAngle = m_SteerAngle;
                m_WheelColliders[1].steerAngle = m_SteerAngle;
            }
        }  
        private void CapSpeed()
        {
            float speed = m_Rigidbody.velocity.magnitude;
            float topSpeedLimit = m_Topspeed* GearBoxCoefficient();
            float constMPH = 2.23693629f;
            float constKPH = 3.6f;
            switch (m_SpeedType)
            {
                case SpeedType.MPH:                    
                    speed *= constMPH;
                    if (speed > topSpeedLimit)
                    { m_Rigidbody.velocity = (topSpeedLimit / constMPH) * m_Rigidbody.velocity.normalized; }
                    if (speed > topSpeedLimit && m_GearNum == -1)
                    {
                        m_Rigidbody.velocity = (topSpeedLimit / constMPH) * -m_Rigidbody.velocity.normalized;
                    }
                    break;
                case SpeedType.KPH:                    
                    speed *= constKPH;
                    if (speed > topSpeedLimit)
                    { m_Rigidbody.velocity = (topSpeedLimit / constKPH) * m_Rigidbody.velocity.normalized; }
                    if (speed > topSpeedLimit && m_GearNum == -1)
                    {
                        m_Rigidbody.velocity = (topSpeedLimit / constMPH) * -m_Rigidbody.velocity.normalized;
                    }
                    break;
            }
        }
        private float GearBoxCoefficient()
        {
            float GearBoxCoefficient = 0;
            switch (m_GearNum)
            {
                case 1:
                    GearBoxCoefficient = 0.4f;
                    break;
                case 2:
                    GearBoxCoefficient = 0.6f;
                    break;
                case 3:
                    GearBoxCoefficient = 0.8f;
                    break;
                case 4:
                    GearBoxCoefficient = 0.88f;
                    break;
                case 5:
                    GearBoxCoefficient = 1f;
                    break;
                case 6:
                    GearBoxCoefficient = 1.2f;
                    break;
                case -1:
                    GearBoxCoefficient = 1f;
                    break;
            }
            return GearBoxCoefficient;
        }
        private float GearBoxCoefficientDown()
        {
            float GearBoxCoefficientDown = 0;
            switch (m_GearNum)
            {
                case 1:
                    GearBoxCoefficientDown = 0f;
                    break;
                case 2:
                    GearBoxCoefficientDown = 0.4f;
                    break;
                case 3:
                    GearBoxCoefficientDown = 0.6f;
                    break;
                case 4:
                    GearBoxCoefficientDown = 0.8f;
                    break;
                case 5:
                    GearBoxCoefficientDown = 0.87f;
                    break;                
            }
            return GearBoxCoefficientDown;
        }

        private void AutoDrive(float accel, float footbrake)
        {

            float thrustTorque;
            float SpeedGear = SpeedDependsGear();
            if (CompareTag("Player"))
            {
                if (SaveScript.OnTheTerrain == true)
                {
                    SpeedGear = SpeedGear / 5;
                }
            }
            switch (m_CarDriveType)
            {
                case CarDriveType.FourWheelDrive:
                    thrustTorque = accel * (SpeedGear / 4f);
                    for (int i = 0; i < 4; i++)
                    {
                        m_WheelColliders[i].motorTorque = thrustTorque;
                    }
                    break;

                case CarDriveType.FrontWheelDrive:
                    thrustTorque = accel * (SpeedGear / 2f);
                    m_WheelColliders[0].motorTorque = m_WheelColliders[1].motorTorque = thrustTorque;
                    break;

                case CarDriveType.RearWheelDrive:
                    thrustTorque = accel * (SpeedGear / 2f);
                    m_WheelColliders[2].motorTorque = m_WheelColliders[3].motorTorque = thrustTorque;
                    break;

            }

            for (int i = 0; i < 4; i++)
            {
                if (CurrentSpeed > 5 && Vector3.Angle(transform.forward, m_Rigidbody.velocity) < 50f)
                {
                    m_WheelColliders[i].brakeTorque = m_BrakeTorque*footbrake;
                }
                else if (footbrake > 0)
                {
                    m_WheelColliders[i].brakeTorque = 0f;
                    m_WheelColliders[i].motorTorque = -m_ReverseTorque*footbrake;
                }
            }
        }
        private void ManualDrive(float accel, float footbrake)
        {
            float thrustTorque;
            float SpeedGear = SpeedDependsGear();
            if (CompareTag("Player"))
            {
                if (SaveScript.OnTheTerrain == true)
                {
                    SpeedGear = SpeedGear / 5;
                }
            }
            if (m_GearNum >= 1)
            {
                switch (m_CarDriveType)
                {
                    case CarDriveType.FourWheelDrive:
                        thrustTorque = accel * (SpeedGear / 4f);
                        for (int i = 0; i < 4; i++)
                        {
                            m_WheelColliders[i].motorTorque = thrustTorque;
                        }
                        break;
                    case CarDriveType.FrontWheelDrive:
                        thrustTorque = accel * (SpeedGear / 2f);
                        m_WheelColliders[0].motorTorque = m_WheelColliders[1].motorTorque = thrustTorque;
                        break;
                    case CarDriveType.RearWheelDrive:
                        thrustTorque = accel * (SpeedGear / 2f);
                        m_WheelColliders[2].motorTorque = m_WheelColliders[3].motorTorque = thrustTorque;
                        break;
                }
            }
            else if (m_GearNum == -1)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (CurrentSpeed > 5 && Vector3.Angle(transform.forward, m_Rigidbody.velocity) < 50f)
                    {
                        m_WheelColliders[i].brakeTorque = m_BrakeTorque * footbrake;
                    }
                    else if (footbrake > 0)
                    {
                        m_WheelColliders[i].brakeTorque = 0f;
                        m_WheelColliders[i].motorTorque = -m_ReverseTorque * footbrake;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    m_WheelColliders[i].motorTorque = 0;
                }
            }
        }
        private void SteerHelper()
        {
            for (int i = 0; i < 4; i++)
            {
                WheelHit wheelhit;
                m_WheelColliders[i].GetGroundHit(out wheelhit);
                if (wheelhit.normal == Vector3.zero)
                    return; // wheels arent on the ground so dont realign the rigidbody velocity
            }

            // this if is needed to avoid gimbal lock problems that will make the car suddenly shift direction
            if (Mathf.Abs(m_OldRotation - transform.eulerAngles.y) < 10f)
            {
                var turnadjust = (transform.eulerAngles.y - m_OldRotation) * m_SteerHelper;
                Quaternion velRotation = Quaternion.AngleAxis(turnadjust, Vector3.up);
                m_Rigidbody.velocity = velRotation * m_Rigidbody.velocity;
            }
            m_OldRotation = transform.eulerAngles.y;
        }


        // this is used to add more grip in relation to speed
        private void AddDownForce()
        {
            m_WheelColliders[0].attachedRigidbody.AddForce(-transform.up*m_Downforce*
                                                         m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
        }
        private void ReduceSpeed()
        {
            m_BoxReduceSpeed = 10f;
            Vector3 brakeForceVector = -m_Rigidbody.velocity.normalized * m_BoxReduceSpeed;
            m_Rigidbody.AddForce(brakeForceVector, ForceMode.Acceleration);
        }    
        
        // checks if the wheels are spinning and is so does three things
        // 1) emits particles
        // 2) plays tiure skidding sounds
        // 3) leaves skidmarks on the ground
        // these effects are controlled through the WheelEffects class
        private void CheckForWheelSpin()
        {
            // loop through all wheels
            for (int i = 0; i < 4; i++)
            {
                WheelHit wheelHit;
                m_WheelColliders[i].GetGroundHit(out wheelHit);
                if (Player == true)
                {
                    if (wheelHit.collider != null)
                    {
                        if (SaveScript.OnTheTerrain == true)
                        {
                            if (wheelHit.collider.CompareTag("Road"))
                            {                                
                                SaveScript.OnTheRoad = true;
                                SaveScript.OnTheTerrain = false;
                            }
                        }
                        if (SaveScript.OnTheRoad == true)
                        {
                            if (wheelHit.collider.CompareTag("Terrain"))
                            {
                                SaveScript.OnTheRoad = false;
                                SaveScript.OnTheTerrain = true;
                            }
                        }
                    }
                }
                // is the tire slipping above the given threshhold
                if (Mathf.Abs(wheelHit.forwardSlip) >= m_SlipLimit || Mathf.Abs(wheelHit.sidewaysSlip) >= m_SlipLimit)
                {
                    m_WheelEffects[i].EmitTyreSmoke();

                    // avoiding all four tires screeching at the same time
                    // if they do it can lead to some strange audio artefacts
                    if (!AnySkidSoundPlaying())
                    {
                        m_WheelEffects[i].PlayAudio();
                    }
                    continue;
                }

                // if it wasnt slipping stop all the audio
                if (m_WheelEffects[i].PlayingAudio)
                {
                    m_WheelEffects[i].StopAudio();
                }
                // end the trail generation
                m_WheelEffects[i].EndSkidTrail();
            }
        }

        // crude traction control that reduces the power to wheel if the car is wheel spinning too much
        private void TractionControl()
        {
            WheelHit wheelHit;
            switch (m_CarDriveType)
            {
                case CarDriveType.FourWheelDrive:
                    // loop through all wheels
                    for (int i = 0; i < 4; i++)
                    {
                        m_WheelColliders[i].GetGroundHit(out wheelHit);

                        AdjustTorque(wheelHit.forwardSlip);
                    }
                    break;

                case CarDriveType.RearWheelDrive:
                    m_WheelColliders[2].GetGroundHit(out wheelHit);
                    AdjustTorque(wheelHit.forwardSlip);
                    if (Player == true)
                    {
                        if (wheelHit.collider.CompareTag("RumbleStrip"))
                        {
                            SaveScript.Rumble1 = true;
                        }
                        else
                        {
                            SaveScript.Rumble1 = false;
                        }
                    }
                    m_WheelColliders[3].GetGroundHit(out wheelHit);
                    AdjustTorque(wheelHit.forwardSlip);
                    if (Player == true)
                    {
                        if (wheelHit.collider.CompareTag("RumbleStrip"))
                        {
                            SaveScript.Rumble2 = true;
                        }
                        else
                        {
                            SaveScript.Rumble2 = false;
                        }
                    }
                    break;
                case CarDriveType.FrontWheelDrive:
                    m_WheelColliders[0].GetGroundHit(out wheelHit);
                    AdjustTorque(wheelHit.forwardSlip);

                    m_WheelColliders[1].GetGroundHit(out wheelHit);
                    AdjustTorque(wheelHit.forwardSlip);
                    break;
            }
        }


        private void AdjustTorque(float forwardSlip)
        {
            if (forwardSlip >= m_SlipLimit && m_CurrentTorque >= 0)
            {
                m_CurrentTorque -= 10 * m_TractionControl;
            }
            else
            {
                m_CurrentTorque += 10 * m_TractionControl;
                if (m_CurrentTorque > m_FullTorqueOverAllWheels)
                {
                    m_CurrentTorque = m_FullTorqueOverAllWheels;
                }
            }
        }


        private bool AnySkidSoundPlaying()
        {
            for (int i = 0; i < 4; i++)
            {
                if (m_WheelEffects[i].PlayingAudio)
                {
                    return true;
                }
            }
            return false;
        }
        private float SpeedDependsGear()
        {
            float thrustTorque = 0;
            if (m_InstantAcceleration)
            {
                thrustTorque = m_MaxAcceleration * 4;
            }
            else
            {
                float timer = 0f;
                float thresholdTime = 2f;
                bool isThresholdReached = false;
                switch (m_GearNum)
                {
                    case 0:
                        thrustTorque = 0;
                        break;
                    case 1:
                        timer += Time.deltaTime;

                        if (timer >= thresholdTime && !isThresholdReached)
                        {
                            thrustTorque = m_Acceleration + m_CurrentTorque;
                            isThresholdReached = true;
                            timer = 0f;
                        }
                        else
                        {
                            thrustTorque = (m_Acceleration + m_CurrentTorque) * 3  ;
                        }
                        break;
                    case 2:
                        thrustTorque = (m_Acceleration + m_CurrentTorque);
                        break;
                    case 3:
                        thrustTorque = (m_Acceleration + m_CurrentTorque) / 2f;
                        break;
                    case 4:
                        thrustTorque = (m_Acceleration + m_CurrentTorque) / 3f;
                        break;
                    case 5:
                        thrustTorque = (m_Acceleration + m_CurrentTorque) / 4f;
                        break;
                    case 6:
                        thrustTorque = (m_Acceleration + m_CurrentTorque) / 5;
                        break;
                }
            }
            return thrustTorque;
        }
    }
}
