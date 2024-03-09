using UnityEngine;

public class ResourceIndicator : MonoBehaviour
{
    public float bois = 100; 
    public float terre = 50; 

    private void OnGUI()
    {

   
        // xPosition = 70% de la taille de l'écran
        float xPosition = 0.70f * Screen.width;

        Rect locationBois = new Rect(xPosition, 0, 85, 25);
        Rect locationTerre = new Rect(xPosition + 80, 0, 85, 25);
       
        string boisText = $"Bois: {bois}";
        string terreText = $"Terre: {terre}"; 



        Texture black = Texture2D.linearGrayTexture;
        GUI.DrawTexture(locationBois, black, ScaleMode.StretchToFill);
        GUI.DrawTexture(locationTerre, black, ScaleMode.StretchToFill);
        GUI.color = Color.black;
        GUI.skin.label.fontSize = 18;

        GUI.Label(locationBois, boisText);
        GUI.Label(locationTerre, terreText);
    }
}
