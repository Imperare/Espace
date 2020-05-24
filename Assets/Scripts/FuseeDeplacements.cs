using UnityEngine;

public class FuseeDeplacements : MonoBehaviour
{
    public float vitesseDeplacement;
    public Rigidbody2D rb;
    private Vector3 velocite = Vector3.zero;
    public float vitesse = 0.5f;

    private void Start()
    {
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Planete")
        {
            Debug.Log("Planete");
            transform.Rotate(Vector3.forward * Random.Range(-360, 360));
        }
        else if (col.gameObject.tag == "Etoile")
        {
            Debug.Log("Etoile");
            transform.Rotate(Vector3.forward * Random.Range(-360, 360));
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * vitesse * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * 120 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * -120 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vitesse += 0.03f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vitesse -= 0.03f;
            vitesse = System.Math.Max(0.1f, vitesse);
        }
    }
}
