using UnityEngine;

public class BoundaryCheck : MonoBehaviour
{
    private Vector2 backgroundBounds;
    private float objectWidth;
    private float objectHeight;

    void Start()
    {
        // Hae taustaelementin rajat maailman koordinaateissa
        backgroundBounds = GetBackgroundBounds();

        // Laske objektin leveys ja korkeus
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void LateUpdate()
    {
        // Rajoita objektin liikkumista taustaelementin rajojen sisällä
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, backgroundBounds.x * -1 + objectWidth, backgroundBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, backgroundBounds.y * -1 + objectHeight, backgroundBounds.y - objectHeight);
        transform.position = viewPos;
    }

    private Vector2 GetBackgroundBounds()
    {
        // Hae taustaelementti
        GameObject background = GameObject.Find("Background");

        // Tarkista, että taustaelementti on löydetty
        if (background != null)
        {
            // Hae taustaelementin koko
            Vector3 backgroundSize = background.GetComponent<SpriteRenderer>().bounds.size;

            // Palauta taustaelementin koko maailman koordinaateissa
            return new Vector2(backgroundSize.x / 2, backgroundSize.y / 2);
        }
        else
        {
            // Jos taustaelementtiä ei löydetty, käytä koko näytön rajoja
            return new Vector2(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).x,
                               Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)).y);
        }
    }
}
