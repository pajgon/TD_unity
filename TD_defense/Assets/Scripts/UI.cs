using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    public float Money = 10;
    public float Lives = 0;


    private BuildBuilding build;


    private Sprite WoodBackground;
    private Sprite WoodPanel;
    private Sprite SteelBackground;
    private Sprite Coin;

    private GameObject Magic_tower;
    private GameObject Magic_towerText;
    private string Magic_towerName =  "Magic_Tower";

    private GameObject War_tower;
    private GameObject War_towerText;
    private string War_towerName = "War_tower";

    public GameObject BuildNode;
    private GameObject BuildCan;
    private string BuildCanName = "BuidlCan";

    public GameObject WorldNode;
    private GameObject WorldCan;
    private string WorldCanName = "WorldCan";

    private GameObject TopPanel;
    private string TopPanelName = "TopPanel";

    private GameObject TopPanelCoinPlace;
    private string TopPanelCoinPlaceName = "TopPanelCoinPlace";

    private GameObject TopPanelCoin;
    private string TopPanelCoinName = "TopPanelCoin";

    private GameObject TopPanelCoinCount;
    private string TopPanelCoinCountName = "TopPanelCoinCount";

    private GameObject TopPanelCoinCountCash;
    private string TopPanelCoinCountCashText = "Money";


    private float angleX = 70;

    private float TopPanelWidth = 300f;
    private float TopPanelHeight = 40f;
    



    Font ArialFont;


    void buildWar_tower(GameObject prefab, float PosX, float PosY, float PosZ)
    {
        if (Money >= prefab.GetComponent<Tower>().cost)
        {
            Instantiate(prefab, new Vector3(PosX, 1.5f + PosY, PosZ), Quaternion.Euler(-90, 0, 0));
            Money = Money - prefab.GetComponent<Tower>().cost;
            BuildNode.SetActive(false);
            build.plane.SetActive(false);
        }
    }

    void buildMagic_Tower(GameObject prefab, float PosX, float PosY, float PosZ)
    {
        if (Money >= prefab.GetComponent<Tower>().cost)
        {
            Instantiate(prefab, new Vector3(PosX, 0.5f + PosY, PosZ), Quaternion.Euler(0, 0, 0));
            Money = Money - prefab.GetComponent<Tower>().cost;
            BuildNode.SetActive(false);
            build.plane.SetActive(false);
        }
        
    }

    void CreateCanvas(GameObject Node, GameObject canvas, string name)
    {
        Node.name = name + "Pos" ;
        canvas.transform.parent = Node.transform;
        Node.transform.rotation = Quaternion.Euler(angleX, 0, 0);
        canvas.name = name;
        canvas.AddComponent<Canvas>();
        canvas.AddComponent<GraphicRaycaster>();
        canvas.AddComponent<CanvasScaler>();
        Canvas can = canvas.GetComponent<Canvas>();
        canvas.AddComponent<HorizontalLayoutGroup>();

        canvas.GetComponent<HorizontalLayoutGroup>().spacing = 10;

        can.renderMode = RenderMode.WorldSpace;
        can.worldCamera = GetComponent<Camera>();

        canvas.transform.rotation = Quaternion.Euler(angleX, 0, 0);

        Node.SetActive(false);


    }



    void CanvasSetSize(GameObject canvas)
    {
        RectTransform canvasPos = canvas.GetComponent<RectTransform>();
        canvasPos.localScale = new Vector3(0.007f, 0.007f, 0.007f);
        canvasPos.localPosition = new Vector3(0f, 1f, 0f);
        canvasPos.sizeDelta = new Vector2(500f, 150f);

        canvasPos.anchorMax = new Vector2(1f, 1f);
        canvasPos.anchorMin = new Vector2(0f, 0f);
    }








    void CreateButton(GameObject canvas, GameObject button, GameObject text, string ButtText)
    {

        button.transform.parent = canvas.transform;


        button.name = "Butt" + ButtText;
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();

        Button buttonB = button.GetComponent<Button>();





        RectTransform buttonRectT = button.GetComponent<RectTransform>();
        buttonRectT.sizeDelta = new Vector2(300f, 130f);
        buttonRectT.localScale = new Vector3(1f, 1f, 1f);
        buttonRectT.localPosition = new Vector3(0f, 0f, 0f);
        buttonRectT.rotation = Quaternion.Euler(angleX, 0, 0);






        text.name = "Butt" + ButtText + "Text";


        text.transform.parent = button.transform;


        text.AddComponent<RectTransform>();
        text.AddComponent<Text>().text = ButtText;
        text.GetComponent<Text>().font = ArialFont;
        text.GetComponent<Text>().fontSize = 30;
        text.GetComponent<Text>().color = Color.black;
        text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        RectTransform textSize = text.GetComponent<RectTransform>();
        textSize.anchoredPosition3D = new Vector3(0f, 0f, 0f);
        textSize.sizeDelta = new Vector2(0f, 0f);
        textSize.localScale = new Vector3(1f, 1f, 1f);
        textSize.anchorMin = new Vector2(0f, 0f);
        textSize.anchorMax = new Vector2(1f, 1f);
        textSize.rotation = Quaternion.Euler(angleX, 0, 0);





    }

    void CreateText(GameObject text, GameObject parent, string name)
    {
        text.name = name + "Text";


        text.transform.parent = parent.transform;

        text.AddComponent<RectTransform>();
        text.AddComponent<Text>().text = name;
        text.GetComponent<Text>().font = ArialFont;
        text.GetComponent<Text>().fontSize = 20;
        text.GetComponent<Text>().color = Color.black;
        text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        RectTransform textSize = text.GetComponent<RectTransform>();
        textSize.anchoredPosition3D = new Vector3(0f, 0f, 0f);
        textSize.sizeDelta = new Vector2(0f, 0f);
        textSize.localScale = new Vector3(1f, 1f, 1f);
        textSize.anchorMin = new Vector2(0f, 0f);
        textSize.anchorMax = new Vector2(1f, 1f);
    }

    void CreatePanel(GameObject panel, GameObject parent, string name , Sprite sprite)
    {
        panel.transform.parent = parent.transform;

        panel.name = name;
        panel.AddComponent<CanvasRenderer>();
        panel.AddComponent<RectTransform>();
        panel.AddComponent<Image>();

        Image PanelImage = panel.GetComponent<Image>();

        PanelImage.sprite = sprite;

        PanelImage.color = new Color32(255, 255, 255, 255);



        

              

        
    }

   



    private void Start()
    {
        WoodBackground = Resources.Load<Sprite>("Sprites/podlaha") as Sprite;
        SteelBackground = Resources.Load<Sprite>("Sprites/Steel") as Sprite;
        Coin = Resources.Load<Sprite>("Sprites/Coin") as Sprite;
        WoodPanel = Resources.Load<Sprite>("Sprites/Wood") as Sprite;

        GameObject WarTower =  Resources.Load("War_Tower") as GameObject;
        GameObject MagicTower = Resources.Load("Magic_tower") as GameObject;

        //nacte font pro text
        ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        build = gameObject.GetComponent<BuildBuilding>();

        Magic_tower = new GameObject();
        Magic_towerText = new GameObject();

        War_tower = new GameObject();
        War_towerText = new GameObject();

        BuildCan = new GameObject();
        BuildNode = new GameObject();

        WorldCan = new GameObject();
        WorldNode = new GameObject();

        TopPanel = new GameObject();

        TopPanelCoinPlace = new GameObject();

        TopPanelCoin = new GameObject();

        TopPanelCoinCount = new GameObject();

        TopPanelCoinCountCash = new GameObject();





        

      

        CreateCanvas(BuildNode, BuildCan, BuildCanName);
        CanvasSetSize(BuildCan);

        CreateCanvas(WorldNode, WorldCan, WorldCanName);

        WorldCan.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        Destroy(WorldCan.GetComponent<HorizontalLayoutGroup>());
        WorldNode.SetActive(true);

        CreatePanel(TopPanel, WorldCan, TopPanelName, WoodBackground);

        CreateButton(BuildCan, Magic_tower, Magic_towerText, Magic_towerName);
        CreateButton(BuildCan, War_tower, War_towerText, War_towerName);





       

        Button Butt_WarTower = War_tower.GetComponent<Button>();
        Butt_WarTower.onClick.AddListener(() => { buildWar_tower(WarTower,build.PosX,build.PosY, build.PosZ); });


        Button Butt_MagicTower = Magic_tower.GetComponent<Button>();
        Butt_MagicTower.onClick.AddListener(() => { buildMagic_Tower(MagicTower, build.PosX, build.PosY, build.PosZ); });





        //vytvori Eventsystem k fungovani tlacitka
        GameObject listener = new GameObject("EventSystem", typeof(EventSystem));
        listener.AddComponent<StandaloneInputModule>();
        listener.AddComponent<BaseInput>();




        // horni panel 
        RectTransform TopPanelPos = TopPanel.GetComponent<RectTransform>();

        TopPanelPos.sizeDelta = new Vector2(TopPanelWidth, TopPanelHeight);

        Vector3[] TopPanelCorners = new Vector3[4];
        TopPanelPos.GetLocalCorners(TopPanelCorners);

        RectTransform world = WorldCan.GetComponent<RectTransform>();
        Vector3[] worldcorners = new Vector3[4];
        world.GetWorldCorners(worldcorners);


        TopPanelPos.anchorMax = new Vector2(0, 1);
        TopPanelPos.anchorMin = new Vector2(0, 1);

       

        TopPanelPos.position = worldcorners[1] - TopPanelCorners[1];

        //Panel v kterem se nachazi panel s obrazkem penizku a ukazujici pocet
        CreatePanel(TopPanelCoinPlace, TopPanel,TopPanelCoinPlaceName, SteelBackground);

        RectTransform TopPanelCoinPlacePos = TopPanelCoinPlace.GetComponent<RectTransform>();
        
        TopPanelCoinPlacePos.anchorMax = new Vector2(0, 1);
        TopPanelCoinPlacePos.anchorMin = new Vector2(0, 1);

        TopPanelCoinPlacePos.sizeDelta = new Vector2(TopPanelWidth/2,TopPanelHeight);

        TopPanelCoinPlacePos.anchoredPosition = new Vector2(TopPanelCoinPlacePos.sizeDelta.x/2 , -TopPanelCoinPlacePos.sizeDelta.y/2);


        // panel v kterem je obrazek penizku
        CreatePanel(TopPanelCoin, TopPanelCoinPlace, TopPanelCoinName, Coin);

        RectTransform TopPanelCoinPos = TopPanelCoin.GetComponent<RectTransform>();

        TopPanelCoinPos.anchorMax = new Vector2(0, 1);
        TopPanelCoinPos.anchorMin = new Vector2(0, 1);

        TopPanelCoinPos.sizeDelta = new Vector2(TopPanelWidth / 6, TopPanelHeight);

        TopPanelCoinPos.anchoredPosition = new Vector2(TopPanelCoinPos.sizeDelta.x / 2, -TopPanelCoinPos.sizeDelta.y / 2);

        //panel ukazujici pocet penez

        CreatePanel(TopPanelCoinCount, TopPanelCoinPlace, TopPanelCoinCountName, WoodPanel);

        RectTransform TopPanelCoinCountPos = TopPanelCoinCount.GetComponent<RectTransform>();

        TopPanelCoinCountPos.anchorMax = new Vector2(1, 1);
        TopPanelCoinCountPos.anchorMin = new Vector2(1, 1);

        TopPanelCoinCountPos.anchoredPosition = new Vector2( - TopPanelCoinPos.sizeDelta.x, -TopPanelCoinPos.sizeDelta.y / 2);

        TopPanelCoinCountPos.sizeDelta = new Vector2(TopPanelWidth / 2 - TopPanelWidth / 6, TopPanelHeight);



        // text ktery se meni podle poctu penez

        CreateText(TopPanelCoinCountCash, TopPanelCoinCount, TopPanelCoinCountCashText);

        TopPanelCoinCountCash.GetComponent<Text>().color = new Color32(255, 255, 255, 255);










    }

    private void Update()
    {
        TopPanelCoinCountCash.GetComponent<Text>().text = Money.ToString();

        
    }

    

}
