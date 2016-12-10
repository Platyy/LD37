using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

    public float m_MoveSpeed = 1f;
    public float m_JumpPower = 5f;
    public float m_MaxVelocity = 2f;
    public float m_RotationSpeed = 10f;

    public float m_DoubletapTime = 0.5f;
    private float m_DTRemaining;
    private int m_ButtonCount = 0;

    public bool m_IsDead = false;

    public Rigidbody m_RB;
    public GameObject m_Body;

    public Slider m_BoostSlider;
    public float m_MaxBoost = 2f;
    private float m_BoostAmount = 2f;
    private bool m_Refilling = false;

    private float m_PrevAngle;

    public ParticleSystem m_Ink;

    public GameObject m_LegParent;

    private List<Legs> m_Legs = new List<Legs>();
    

    void Start()
    {

        //m_RB = GetComponent<Rigidbody>();
        m_DTRemaining = m_DoubletapTime;
        m_BoostAmount = m_MaxBoost;
        //GetLegs();
        Debug.Log(m_Legs.Count);
    }

    void Update()
    {
        if (m_IsDead)
            return;
        // If we're over the pause menu UI, we don't want to detect clicks for movement
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        // TODO: Move this into it's own input function, if you like?
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.m_IsPaused = true;
        }

        Jump();
        // compare Vector3.Up and .Right against current transform.direction
    }

    void FixedUpdate()
    {
        if (m_IsDead)
            return;
        //Move();
        Jump();
        //Dash();
        LookAtMouse();
        //m_RB.velocity = new Vector3(Mathf.Clamp(m_RB.velocity.x, -m_MaxVelocity, m_MaxVelocity), m_RB.velocity.y, m_RB.velocity.z);
    }


    void LookAtMouse()
    {
        //Get the Screen positions of the object
        Vector2 _positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 _mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float _angle = AngleBetweenTwoPoints(_positionOnScreen, _mouseOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0f, 0f, _angle + 90)), Time.deltaTime * m_RotationSpeed);
        m_PrevAngle = _angle;
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A)) // Left
        {
            m_RB.velocity = new Vector3(m_RB.velocity.x - m_MoveSpeed, m_RB.velocity.y, m_RB.velocity.z);
        }
        if(Input.GetKey(KeyCode.D)) // Right
        {
            m_RB.velocity = new Vector3(m_RB.velocity.x + m_MoveSpeed, m_RB.velocity.y, m_RB.velocity.z);
        }
    }

    void Jump()
    {
        if(Input.GetMouseButtonDown(0))
        {
            m_RB.AddForce(transform.up * m_JumpPower, ForceMode.Impulse);
            //transform.DOMove(transform.position + transform.up, 0.2f);
        }
        if(Input.GetMouseButton(0) && m_BoostAmount >= 0 && !m_Refilling)
        {
            if(!m_Ink.isPlaying)
            {
                m_Ink.Play();
            }
            m_RB.AddForce(transform.up * m_JumpPower, ForceMode.Acceleration);
            m_BoostAmount -= Time.deltaTime;
            m_BoostSlider.value = m_BoostAmount;
            if(m_BoostAmount <= 0.01f)
            {
                m_Refilling = true;
            }
        }
        if(m_Ink.isPlaying && (m_BoostAmount <= 0.01f || !Input.GetMouseButton(0)))
        {
            m_Ink.Stop();
        }
        Fill();
    }

    void Fill()
    {
        if(m_Refilling)
        {
            if (m_BoostAmount <= m_MaxBoost)
            {
                m_BoostAmount += Time.deltaTime;
                m_BoostSlider.value = m_BoostAmount;
            }
            else
                m_Refilling = false;
        }
    }
    
    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(m_DTRemaining >= 0 && m_ButtonCount == 1)
            {
                Debug.Log("Dashed");
                transform.DOMoveX(transform.position.x - 2, 0.2f);
                m_DTRemaining = m_DoubletapTime;
            }
            else
            {
                m_DTRemaining = m_DoubletapTime;
                m_ButtonCount += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (m_DTRemaining >= 0 && m_ButtonCount == 1)
            {
                Debug.Log("Dashed");
                transform.DOMoveX(transform.position.x + 2, 0.2f);
                m_DTRemaining = m_DoubletapTime;
            }
            else
            {
                m_DTRemaining = m_DoubletapTime;
                m_ButtonCount += 1;
            }
        }

        if (m_DTRemaining >= 0)
        {
            m_DTRemaining -= Time.deltaTime;
        }
        else
        {
            m_ButtonCount = 0;
        }
    }

    public void GetLegs(int legIndex)
    {
        Transform f;
        for (int i = 0; i < m_LegParent.transform.childCount; i++)
        {
            f = m_LegParent.transform.GetChild(i);
            
            if (i == legIndex)
            {
                f.gameObject.SetActive(false);
            }
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
