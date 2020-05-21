using UnityEngine;

public class Deplacements : MonoBehaviour
{


    private enum DirectionVerticale : int
    {
        Haut = 5,
        Bas = -5,
        Aucune = 0
    }

    private enum DirectionHorizontale
    {
        Gauche = 5,
        Droite = -5,
        Aucune = 0
    }

    public float vitesseDeplacement;
    public Rigidbody2D rb;
    private Vector3 velocite = Vector3.zero;
    public float RotateSpeed = 3000;

    private System.Random m_random;
    private int m_nombreDeplacements;
    private DirectionHorizontale m_directionHorizontale;
    private DirectionVerticale m_directionVerticale;

    private void Start()
    {
        m_random = new System.Random();

        m_nombreDeplacements = m_random.Next(500, 5000);
        m_directionHorizontale = DirectionHorizontale.Droite;
        m_directionVerticale = DirectionVerticale.Haut;
    }

    void Update()
    {
        //m_nombreDeplacements--;

        //float h = (int)m_directionHorizontale / 10f;
        //float mouvementHorizontal = h * vitesseDeplacement * Time.deltaTime;
        //DeplacerHorizontalementJoueur(mouvementHorizontal);

        //float mouvementVertical = 0.5f * vitesseDeplacement * Time.deltaTime;
        //Vector3 cibleVelocite = new Vector2(rb.velocity.x, mouvementVertical);
        //rb.velocity = Vector3.SmoothDamp(rb.velocity, cibleVelocite, ref velocite, .05f);

        transform.Translate(Vector3.up * 0.5f * Time.deltaTime);

        Debug.Log(Time.time);

        if ((int)Time.time > 0 && (int)Time.time % 3 == 0)
            transform.Rotate(Vector3.forward * Random.Range(50, 150));

        return;

        if (m_directionVerticale == DirectionVerticale.Haut)
        {
            if (transform.rotation.z >= 0)
                transform.Rotate(new Vector3(0, 0, -7));
            else
                transform.Rotate(new Vector3(0, 0, 7));
        }
        else if (m_directionVerticale == DirectionVerticale.Bas)
        {
            if (transform.rotation.z >= 0)
                transform.Rotate(new Vector3(0, 0, 7));
            else
                transform.Rotate(new Vector3(0, 0, -7));
        }
        if (m_directionHorizontale == DirectionHorizontale.Droite)
        {
            if (transform.rotation.z >= 0.7 || transform.rotation.z <= -0.7)
                transform.Rotate(new Vector3(0, 0, -7));
            else
                transform.Rotate(new Vector3(0, 0, 7));
        }
        else if (m_directionHorizontale == DirectionHorizontale.Gauche)
        {
            if (transform.rotation.z >= 0.7 || transform.rotation.z <= -0.7)
                transform.Rotate(new Vector3(0, 0, 7));
            else
                transform.Rotate(new Vector3(0, 0, -7));
        }

        if (m_nombreDeplacements <= 0)
        {
            m_nombreDeplacements = m_random.Next(30, 200);
            var randHorizontal = m_random.Next(0, 2);
            var randVertical = m_random.Next(0, 2);

            m_directionHorizontale = randHorizontal == 0 ? DirectionHorizontale.Aucune : randHorizontal == 1 ? DirectionHorizontale.Gauche : DirectionHorizontale.Droite;
            m_directionVerticale = randVertical == 0 && m_directionHorizontale != DirectionHorizontale.Aucune ? DirectionVerticale.Aucune : randVertical == 1 ? DirectionVerticale.Bas : DirectionVerticale.Haut;
        }
    }

    void DeplacerHorizontalementJoueur(float mouvementHorizontal)
    {
        Vector3 cibleVelocite = new Vector2(mouvementHorizontal, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, cibleVelocite, ref velocite, .05f);
    }

    void DeplacerVerticalementJoueur(float mouvementVertical)
    {
        Vector3 cibleVelocite = new Vector2(rb.velocity.x, mouvementVertical);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, cibleVelocite, ref velocite, .05f);
    }
}
