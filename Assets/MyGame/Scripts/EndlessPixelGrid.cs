using UnityEngine;
using UnityEngine.UI;

public class EndlessPixelGrid : MonoBehaviour
{
    public Transform gridParent;    
    public Transform inputParent;     

    Image[,] gridImages = new Image[10, 7];
    Image[] inputImages = new Image[7];

    void Start()
    {
        AutoLinkUI();
    }



    void AutoLinkUI() // Automatisch ui elemente in array einistecken
    {
        for (int i = 0; i < 7; i++)
        {
            inputImages[i] = inputParent.GetChild(i).GetComponent<Image>();
        }

        int index = 0;
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                gridImages[y, x] = gridParent.GetChild(index).GetComponent<Image>();
                index++;
            }
        }
    }
}
