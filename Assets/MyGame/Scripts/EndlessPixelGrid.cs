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
        RenderAll();
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

    void HandleInput() // Tastatureingaben anschauen
    {
        if (Input.GetKeyDown(KeyCode.W)) ToggleInput(6);
        if (Input.GetKeyDown(KeyCode.A)) ToggleInput(5);
        if (Input.GetKeyDown(KeyCode.UpArrow)) ToggleInput(4);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ToggleInput(3);
        if (Input.GetKeyDown(KeyCode.DownArrow)) ToggleInput(2);
        if (Input.GetKeyDown(KeyCode.RightArrow)) ToggleInput(1);
        if (Input.GetKeyDown(KeyCode.S)) ToggleInput(0);

        if (Input.GetKeyDown(KeyCode.D)) CommitLine();
        if (Input.GetKeyDown(KeyCode.G)) ResetAll();
    }

    void ToggleInput(int i) // Pixel in der Eingabezeile umschalten
    {
        inputLine[i] = !inputLine[i];
        RenderInput();
    }

    void CommitLine() // Eingabe in Raster FIFO einischtecken
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                grid[y, x] = grid[y + 1, x];
            }
        }

        for (int x = 0; x < 7; x++)
        {
            grid[9, x] = inputLine[x];
        }

        for (int x = 0; x < 7; x++)
        {
            inputLine[x] = false;
        }

        RenderAll(); 
    }

    void ResetAll() // Alles zurücksetzen
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                grid[y, x] = false;
            }
        }

        for (int x = 0; x < 7; x++)
        {
            inputLine[x] = false;
        }

        RenderAll();
    }

    void RenderAll() // Anzeigen
    {
        RenderGrid();
        RenderInput();
    }

    void RenderGrid() // Raster anzeigen
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                gridImages[y, x].color = grid[y, x] ? Color.white : Color.black;
            }
        }
    }

    void RenderInput() // Eingabezeile anzeigen
    {
        for (int x = 0; x < 7; x++)
        {
            inputImages[x].color = inputLine[x] ? Color.white : Color.black;
        }
    }
}
