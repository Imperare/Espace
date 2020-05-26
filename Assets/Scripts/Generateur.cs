using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Generateur : MonoBehaviour
{
    private int compteurAstres;

    public GameObject fusee;
    public GameObject planete;
    public GameObject etoile;

    public List<GameObject> listeAstres;

    public List<Sprite> listeEtoiles;
    public List<Sprite> listePlanetes;

    private enum TypeAstre
    {
        Etoile,
        Planete
    }

    private void Start()
    {
        listeEtoiles = new List<Sprite>(Resources.LoadAll<Sprite>("Etoiles"));
        listePlanetes = new List<Sprite>(Resources.LoadAll<Sprite>("Planetes"));

        CreerAstre(TypeAstre.Planete, numero:0, position:new Vector2(-1, 0), echelle:1);
        CreerAstre(TypeAstre.Planete, numero:1, position:new Vector2(10, 1), echelle: 1.5);
        CreerAstre(TypeAstre.Etoile, numero:2, position:new Vector2(4, 9), echelle: 4);
    }

    void Update()
    {
        int aleatoire = Random.Range(0, 9);
        TypeAstre typeAstre = aleatoire == 0 ? TypeAstre.Etoile : TypeAstre.Planete;

        Debug.Log(compteurAstres++);

        NettoyerAstresEloignes(25);
    }

    private void CreerAstre(TypeAstre typeAstre, int numero, Vector2 position, double echelle = 1)
    {
        GameObject astre = Instantiate(typeAstre == TypeAstre.Planete ? planete : etoile);
        astre.GetComponent<SpriteRenderer>().sprite = typeAstre == TypeAstre.Planete ? listePlanetes[numero % listePlanetes.Count] : listeEtoiles[numero % listeEtoiles.Count];
        astre.transform.position = new Vector3(position.x, position.y, 0);
        astre.transform.localScale = new Vector3((float)echelle, (float)echelle, 0);

        listeAstres.Add(astre);
    }

    private void NettoyerAstresEloignes(int distanceMax)
    {
        for (var i = 0; i < listeAstres.Count; i++)
        {
            GameObject astre = listeAstres.ElementAt(i);
            float distance = Vector3.Distance(fusee.transform.position, astre.transform.position);
            if (distance > distanceMax)
            {
                Destroy(astre);
                listeAstres.Remove(astre);
                i--;
            }
        }
    }
}
