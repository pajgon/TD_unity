using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    public float Money = 10;
    public float Lives = 10;




    private BuildBuilding build;
    private SellandUpgrade sellAndupgrade;


    private Sprite WoodBackground;
    private Sprite WoodPanel;
    private Sprite SteelBackground;
    private Sprite Coin;
    private Sprite Dirt;
    private Sprite Heart;
    private Sprite TowerWR;
    private Sprite TowerBW;
    private Sprite TowerYR;
    private Sprite SellSprite;
    private Sprite UpgradeSprite;

    private GameObject PlanePlace;

    private GameObject BWMageTowerLv1;
    private GameObject BWMageTowerLv1Text;
    private string BWMageTowerLv1Name = "BWMageTowerLv1";

    private GameObject YRMageTowerLv1;
    private GameObject YRMageTowerLv1Text;
    private string YRMageTowerLv1Name = "YRMageTowerLv1";

    private GameObject WRMageTowerLv1;
    private GameObject WRMageTowerLv1Text;
    private string WRMageTowerLv1Name = "WRMageTowerLv1";

    private GameObject UpgradeButt;
    public GameObject UpgradeText;
    private string UpgradeButtName = "Upgrade";

    private GameObject SellButt;
    private GameObject SellText;
    private string SellButtName = "Sell";

    public GameObject BuildNode;
    public GameObject BuildCan;
    private string BuildCanName = "BuidlCan";

    public GameObject UpgradeNode;
    public GameObject UpgradeCan;
    private string UpgradeCanName = "UpgradeCan";

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

    private GameObject TopPanelLifePlace;
    private string TopPanelLifePlaceName = "TopPanelLifePlace";

    private GameObject TopPanelLife;
    private string TopPanelLifeName = "TopPanelLife";

    private GameObject TopPanelLifePlaceNummber;
    private string TopPanelLifePlaceNummberName = "TopPanelLifePlaceNummber";

    private GameObject TopPanelLifeNummber;
    private string TopPanelLifeNummberText = "Lifes";


    private float angleX = 70;
    private float value;

    private float TopPanelWidth = 300f;
    private float TopPanelHeight = 40f;

    public Button upgrade;

    public Button Upgrade;
    




    Font ArialFont;



    // stavba veze na pozici stavebni parcely
    public void buildTower(GameObject prefab, Vector3 position, GameObject canvas, GameObject destroy, bool clicked)
    {
        if (Money >= prefab.GetComponent<Tower>().cost)
        {

            if (destroy.tag == "Tower")
            {
                PlanePlace = destroy.GetComponent<Tower>().PlanePlace;
                Destroy(destroy);
                prefab.GetComponent<Tower>().PlanePlace = PlanePlace;
            }
            else
            {
                PlanePlace = destroy;
                prefab.GetComponent<Tower>().PlanePlace = PlanePlace;
                destroy.SetActive(false);
            }

            prefab.tag = "Tower";
            Instantiate(prefab, position, Quaternion.identity);
            Debug.Log("objek tam je   " + prefab.GetComponent<Tower>().PlanePlace);


            
            Money = Money - prefab.GetComponent<Tower>().cost;
            canvas.SetActive(false);


        }
        else
        {
            canvas.SetActive(true);
            clicked = true;
        }

    }

    void CreateCanvas(GameObject Node, GameObject canvas, string name)
    {
        Node.name = name + "Pos";
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
        canvasPos.sizeDelta = new Vector2(1500f, 500f);

        canvasPos.anchorMax = new Vector2(1f, 1f);
        canvasPos.anchorMin = new Vector2(0f, 0f);
    }








    void CreateButton(GameObject canvas, GameObject button, GameObject text, string ButtText)
    {

        button.transform.parent = canvas.transform;


        button.name = "Butt" + ButtText;
        button.tag = "Button";
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();

        Button buttonB = button.GetComponent<Button>();





        RectTransform buttonRectT = button.GetComponent<RectTransform>();
        buttonRectT.sizeDelta = new Vector2(500f, 500f);
        buttonRectT.localScale = new Vector3(1f, 1f, 1f);
        buttonRectT.localPosition = new Vector3(0f, 0f, 0f);
        buttonRectT.rotation = Quaternion.Euler(angleX, 0, 0);





        /*
                text.name = "Butt" + ButtText + "Text";
                text.transform.parent = button.transform;
                text.AddComponent<RectTransform>();
                text.AddComponent<Text>().text = ButtText;
                text.GetComponent<Text>().font = ArialFont;
                text.GetComponent<Text>().fontSize = 30;
                text.GetComponent<Text>().color = Color.yellow;
                text.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
                RectTransform textSize = text.GetComponent<RectTransform>();
                textSize.anchoredPosition3D = new Vector3(0f, 0f, 0f);
                textSize.sizeDelta = new Vector2(500f, 500f);
                textSize.localScale = new Vector3(1f, 1f, 1f);
                textSize.anchorMin = new Vector2(0.5f, 0.5f);
                textSize.anchorMax = new Vector2(0.5f, 0.5f);
                textSize.rotation = Quaternion.Euler(angleX, 0, 0);
            */


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

    void CreatePanel(GameObject panel, GameObject parent, string name, Sprite sprite)
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
        Dirt = Resources.Load<Sprite>("Sprites/Dirt") as Sprite;
        Heart = Resources.Load<Sprite>("Sprites/heart") as Sprite;
        TowerWR = Resources.Load<Sprite>("Sprites/OrangeLv1_erb") as Sprite;
        TowerBW = Resources.Load<Sprite>("Sprites/BlueLv1_erb") as Sprite;
        TowerYR = Resources.Load<Sprite>("Sprites/RedLv1_erb") as Sprite;
          SellSprite = Resources.Load<Sprite>("Sprites/SellButton2") as Sprite;
        UpgradeSprite = Resources.Load<Sprite>("Sprites/UpgradeButton2") as Sprite;



        GameObject YRMageTowerLv1Model = Resources.Load("Towers/TowersYR/YRVezLv1Mage") as GameObject;
        GameObject BWMageTowerLv1Model = Resources.Load("Towers/TowersBW/BWMageTowerLv1") as GameObject;
        GameObject WRMageTowerLv1Model = Resources.Load("Towers/TowersWR/WRMageTowerLv1") as GameObject;

        //nacte font pro text
        ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        build = gameObject.GetComponent<BuildBuilding>();
        sellAndupgrade = gameObject.GetComponent<SellandUpgrade>();


        BWMageTowerLv1 = new GameObject();
        BWMageTowerLv1Text = new GameObject();

        YRMageTowerLv1 = new GameObject();
        YRMageTowerLv1Text = new GameObject();

        WRMageTowerLv1 = new GameObject();
        WRMageTowerLv1Text = new GameObject();

        BuildCan = new GameObject();
        BuildNode = new GameObject();

        UpgradeCan = new GameObject();
        UpgradeNode = new GameObject();

        UpgradeButt = new GameObject();
        UpgradeText = new GameObject();

        SellButt = new GameObject();
        SellText = new GameObject();

        WorldCan = new GameObject();
        WorldNode = new GameObject();

        TopPanel = new GameObject();

        TopPanelCoinPlace = new GameObject();

        TopPanelCoin = new GameObject();

        TopPanelCoinCount = new GameObject();

        TopPanelCoinCountCash = new GameObject();

        TopPanelLifePlace = new GameObject();

        TopPanelLife = new GameObject();

        TopPanelLifePlaceNummber = new GameObject();

        TopPanelLifeNummber = new GameObject();











        // vytvori novy kanvas na vlozeni dvou tlacitek lze s nim pohybovat

        CreateCanvas(BuildNode, BuildCan, BuildCanName);
        CanvasSetSize(BuildCan);


        // vlozi do kanvasu dve tlacitka predem nastavena v metode
        CreateButton(BuildCan, BWMageTowerLv1, BWMageTowerLv1Text, BWMageTowerLv1Name);
        CreateButton(BuildCan, YRMageTowerLv1, YRMageTowerLv1Text, YRMageTowerLv1Name);
        CreateButton(BuildCan, WRMageTowerLv1, WRMageTowerLv1Text, WRMageTowerLv1Name);



        //opet vytvori novy kanvas stejneho typu
        CreateCanvas(UpgradeNode, UpgradeCan, UpgradeCanName);
        CanvasSetSize(UpgradeCan);


        // prida znovu dve tlacitka 
        CreateButton(UpgradeCan, UpgradeButt, UpgradeText, UpgradeButtName);
        CreateButton(UpgradeCan, SellButt, SellText, SellButtName);


        CreateCanvas(WorldNode, WorldCan, WorldCanName);

        WorldCan.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        Destroy(WorldCan.GetComponent<HorizontalLayoutGroup>());
        WorldNode.SetActive(true);
        CanvasScaler WorldCanScaler = WorldCan.GetComponent<CanvasScaler>();
        WorldCanScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        WorldCanScaler.referenceResolution = new Vector2(1920, 1080);


        CreatePanel(TopPanel, WorldCan, TopPanelName, WoodBackground);





        //3 tlacitka pokazde postavi 1. level dane veze

        Button ButtWRMageTowerLv1 = WRMageTowerLv1.GetComponent<Button>();
        ButtWRMageTowerLv1.GetComponent<Image>().sprite = TowerWR;
        ButtWRMageTowerLv1.onClick.AddListener(() => { buildTower(WRMageTowerLv1Model, build.PlanePosition, BuildNode, build.plane, build.PlaneCanvasclicked); });

        Button ButtYRMageTowerLv1 = YRMageTowerLv1.GetComponent<Button>();
        ButtYRMageTowerLv1.GetComponent<Image>().sprite = TowerYR;
        ButtYRMageTowerLv1.onClick.AddListener(() => { buildTower(YRMageTowerLv1Model, build.PlanePosition, BuildNode, build.plane, build.PlaneCanvasclicked); });


        Button BWMageTowerLv1_Model = BWMageTowerLv1.GetComponent<Button>();
        BWMageTowerLv1_Model.GetComponent<Image>().sprite = TowerBW;
        BWMageTowerLv1_Model.onClick.AddListener(() => { buildTower(BWMageTowerLv1Model, build.PlanePosition, BuildNode, build.plane, build.PlaneCanvasclicked); });

        //tlacitko po kterem se spusti akci upgrade veze
        Button Upgrade = UpgradeButt.GetComponent<Button>();
        Upgrade.GetComponent<Image>().sprite = UpgradeSprite;
        Upgrade.onClick.AddListener(() => { sellAndupgrade.Upgrade(); });


        //tlacitko po kterem se spusti akci prodani veze
        Button Sell = SellButt.GetComponent<Button>();
        Sell.GetComponent<Image>().sprite = SellSprite;
        Sell.onClick.AddListener(() => { sellAndupgrade.Sell(); });






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
        CreatePanel(TopPanelCoinPlace, TopPanel, TopPanelCoinPlaceName, SteelBackground);

        RectTransform TopPanelCoinPlacePos = TopPanelCoinPlace.GetComponent<RectTransform>();

        TopPanelCoinPlacePos.anchorMax = new Vector2(0, 1);
        TopPanelCoinPlacePos.anchorMin = new Vector2(0, 1);

        TopPanelCoinPlacePos.sizeDelta = new Vector2(TopPanelWidth / 2, TopPanelHeight);

        TopPanelCoinPlacePos.anchoredPosition = new Vector2(TopPanelCoinPlacePos.sizeDelta.x / 2, -TopPanelCoinPlacePos.sizeDelta.y / 2);


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

        TopPanelCoinCountPos.anchoredPosition = new Vector2(-TopPanelCoinPos.sizeDelta.x, -TopPanelCoinPos.sizeDelta.y / 2);

        TopPanelCoinCountPos.sizeDelta = new Vector2(TopPanelWidth / 2 - TopPanelWidth / 6, TopPanelHeight);



        // text ktery se meni podle poctu penez

        CreateText(TopPanelCoinCountCash, TopPanelCoinCount, TopPanelCoinCountCashText);

        TopPanelCoinCountCash.GetComponent<Text>().color = new Color32(255, 255, 255, 255);



        //Panel v kterem se nachazi panel s obrazkem zivotu a poctem zivotu
        CreatePanel(TopPanelLifePlace, TopPanel, TopPanelLifePlaceName, Dirt);

        RectTransform TopPanelLifePlacePos = TopPanelLifePlace.GetComponent<RectTransform>();

        TopPanelLifePlacePos.anchorMax = new Vector2(1, 1);
        TopPanelLifePlacePos.anchorMin = new Vector2(1, 1);

        TopPanelLifePlacePos.sizeDelta = new Vector2(TopPanelWidth / 2, TopPanelHeight);

        TopPanelLifePlacePos.anchoredPosition = new Vector2(-TopPanelLifePlacePos.sizeDelta.x / 2, -TopPanelLifePlacePos.sizeDelta.y / 2);




        // panel v kterem je obrazek srdicka
        CreatePanel(TopPanelLife, TopPanelLifePlace, TopPanelLifeName, Heart);

        RectTransform TopPanelLifePos = TopPanelLife.GetComponent<RectTransform>();

        TopPanelLifePos.anchorMax = new Vector2(0, 1);
        TopPanelLifePos.anchorMin = new Vector2(0, 1);

        TopPanelLifePos.sizeDelta = new Vector2(TopPanelWidth / 6, TopPanelHeight);

        TopPanelLifePos.anchoredPosition = new Vector2(TopPanelLifePos.sizeDelta.x / 2, -TopPanelLifePos.sizeDelta.y / 2);


        //panel ukazujici pocet zivotu

        CreatePanel(TopPanelLifePlaceNummber, TopPanelLifePlace, TopPanelLifePlaceNummberName, WoodPanel);

        RectTransform TopPanelLifePlaceNummberPos = TopPanelLifePlaceNummber.GetComponent<RectTransform>();

        TopPanelLifePlaceNummberPos.anchorMax = new Vector2(1, 1);
        TopPanelLifePlaceNummberPos.anchorMin = new Vector2(1, 1);

        TopPanelLifePlaceNummberPos.anchoredPosition = new Vector2(-TopPanelLifePlaceNummberPos.sizeDelta.x / 2, -TopPanelLifePlaceNummberPos.sizeDelta.y / 5);

        TopPanelLifePlaceNummberPos.sizeDelta = new Vector2(TopPanelWidth / 2 - TopPanelWidth / 6, TopPanelHeight);

        // text ktery se meni podle poctu zivotu

        CreateText(TopPanelLifeNummber, TopPanelLifePlaceNummber, TopPanelLifeNummberText);

        TopPanelLifeNummber.GetComponent<Text>().color = new Color32(255, 255, 255, 255);





    }

    public void DestroyNewGameObjects()
    {
        GameObject[] GameObjects = (FindObjectsOfType<GameObject>() as GameObject[]);

        foreach (GameObject EmptyObject in GameObjects)
        {
            if (EmptyObject.name == "New Game Object")
            {
                Destroy(EmptyObject);
            }
        }
    }

    private void Update()
    {
        TopPanelCoinCountCash.GetComponent<Text>().text = Money.ToString();
        TopPanelLifeNummber.GetComponent<Text>().text = Lives.ToString();


        DestroyNewGameObjects();


    }



}
