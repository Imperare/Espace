using UnityEngine;

public class FuseeDeplacements : MonoBehaviour
{
    public float vitesseDeplacement;
    public Rigidbody2D rb;
    private Vector3 velocite = Vector3.zero;
    public float RotateSpeed = 3000;

    private System.Random m_random;
    private int m_nombreDeplacements;

    private void Start()
    {
        m_random = new System.Random();

        m_nombreDeplacements = m_random.Next(500, 5000);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Planete")
        {
            Debug.Log("Planete");
            transform.Rotate(Vector3.forward * Random.Range(-300, 300));
        }
        else if (col.gameObject.tag == "Etoile")
        {
            Debug.Log("Etoile");
            transform.Rotate(Vector3.forward * Random.Range(-300, 300));
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * 0.5f * Time.deltaTime);
    }
}
