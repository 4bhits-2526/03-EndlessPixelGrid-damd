using UnityEngine;
using UnityEngine.UI;

public class EndlessPixelGrid : MonoBehaviour
{
    public bool[] inputLine = new bool[7];
    public bool[,] grid = new bool[10, 7];

    public Transform gridParent;
    public Transform inputParent;

    Image[,] gridImages = new Image[10, 7];
    Image[] inputImages = new Image[7];

    void Start()
    {
        AutoLinkUI();
    }

    void Update()
    {
        HandleInput();
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



    void HandleInput()  // Schaun was Tastatur macht
    {
        if (Input.GetKeyDown(KeyCode.W)) ToggleInput(6);
        if (Input.GetKeyDown(KeyCode.A)) ToggleInput(5);
        if (Input.GetKeyDown(KeyCode.UpArrow)) ToggleInput(4);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ToggleInput(3);
        if (Input.GetKeyDown(KeyCode.DownArrow)) ToggleInput(2);
        if (Input.GetKeyDown(KeyCode.RightArrow)) ToggleInput(1);
        if (Input.GetKeyDown(KeyCode.S)) ToggleInput(0);

    }

    void ToggleInput(int i) // Input Zeile umschalten
    {
        inputLine[i] = !inputLine[i];
        RenderInput();
    }

    void RenderInput()  // Farbe toggeln
    {
        for (int x = 0; x < 7; x++)
            if (inputLine[x])
            {
                inputImages[x].color = Color.white;
            }
            else
            {
                inputImages[x].color = Color.black;
            }
        
    }
}
