using UnityEngine;

public class PlayerVR : MonoBehaviour
{
    private static PlayerVR m_instance;
    public static PlayerVR instance
    {
        get
        {
            if (m_instance == null)
                m_instance = FindObjectOfType<PlayerVR>();
            return m_instance;
        }
    }

    [SerializeField]
    private Camera m_mainCamera;
    public Camera mainCamera { get => m_mainCamera; }

    [SerializeField]
    private Transform m_trackingSpace;
    public Transform trackingSpace { get => m_trackingSpace; }
}