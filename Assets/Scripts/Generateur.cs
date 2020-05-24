using System.Collections.Generic;
using UnityEngine;

public class Generateur : MonoBehaviour
{
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

        CreerAstre(TypeAstre.Planete, 0, new Vector2(-1, 0), 1);
        CreerAstre(TypeAstre.Planete, 1, new Vector2(10, 1), 1.5);
        CreerAstre(TypeAstre.Etoile, 2, new Vector2(4, 9), 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreerAstre(TypeAstre typeAstre, int numero, Vector2 position, double echelle = 1)
    {
        GameObject astre = Instantiate(typeAstre == TypeAstre.Planete ? planete : etoile);
        astre.GetComponent<SpriteRenderer>().sprite = typeAstre == TypeAstre.Planete ? listePlanetes[numero] : listeEtoiles[numero];
        astre.transform.position = new Vector3(position.x, position.y, 0);
        astre.transform.localScale = new Vector3((float)echelle, (float)echelle, 0);

        listeAstres.Add(astre);
    }
}
