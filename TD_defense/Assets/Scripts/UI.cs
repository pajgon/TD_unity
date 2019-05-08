using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
   

   
    private BuildBuilding build;

    private GameObject Magic_tower;
    private GameObject Magic_towerText;
    private string agic_towerName =  "Magic_Tower";

    private GameObject War_tower;
    private GameObject War_towerText;
    private string War_towerName = "War_tower";

    public GameObject BuildNode;
    private GameObject BuildCan;
    private string BuildCanName = "BuidlCan";

    private float angleX = 70;


    Font ArialFont;


    void buildWar_tower(GameObject prefab, float PosX, float PosY, float PosZ)
    {

        Instantiate(prefab, new Vector3(PosX, 1.5f + PosY, PosZ), Quaternion.Euler(-90, 0, 0));
        BuildNode.SetActive(false);
        build.plane.SetActive(false);
    }

    void buildMagic_Tower(GameObject prefab, float PosX, float PosY, float PosZ)
    {

        Instantiate(prefab, new Vector3(PosX, 0.5f + PosY, PosZ), Quaternion.Euler(0, 0, 0));
        BuildNode.SetActive(false);
        build.plane.SetActive(false);
    }

    void CreateCanvas(GameObject Node, GameObject canvas, string name)
    {
        Node.name = name + "Pos" ;
        canvas.transform.parent = Node.transform;
        Node.transform.rotation = Quaternion.Euler(angleX, 0, 0);
        BuildCan.name = name;
        BuildCan.AddComponent<Canvas>();
        BuildCan.AddComponent<GraphicRaycaster>();
        BuildCan.AddComponent<CanvasScaler>();
        Canvas can = BuildCan.GetComponent<Canvas>();
        BuildCan.AddComponent<HorizontalLayoutGroup>();

        BuildCan.GetComponent<HorizontalLayoutGroup>().spacing = 10;

        can.renderMode = RenderMode.WorldSpace;
        can.worldCamera = GetComponent<Camera>();

        BuildCan.transform.rotation = Quaternion.Euler(angleX, 0, 0);

        BuildNode.SetActive(false);


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

   



    private void Start()
    {
        GameObject WarTower = (Resources.Load("War_Tower")) as GameObject;
        GameObject MagicTower = (Resources.Load("Magic_tower")) as GameObject;

        //nacte font pro text

        ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");


       
    build = gameObject.GetComponent<BuildBuilding>();

        Magic_tower = new GameObject();
        Magic_towerText = new GameObject();

        War_tower = new GameObject();
        War_towerText = new GameObject();

        BuildCan = new GameObject();
        BuildNode = new GameObject();
        

      

        CreateCanvas(BuildNode, BuildCan, BuildCanName);
        CanvasSetSize(BuildCan);
        

        CreateButton(BuildCan, Magic_tower, Magic_towerText, agic_towerName);
        CreateButton(BuildCan, War_tower, War_towerText, War_towerName);





       

        Button Butt_WarTower = War_tower.GetComponent<Button>();
        Butt_WarTower.onClick.AddListener(() => { buildWar_tower(WarTower,build.PosX,build.PosY, build.PosZ); });


        Button Butt_MagicTower = Magic_tower.GetComponent<Button>();
        Butt_MagicTower.onClick.AddListener(() => { buildMagic_Tower(MagicTower, build.PosX, build.PosY, build.PosZ); });





        //vytvori Eventsystem k fungovani tlacitka
        GameObject listener = new GameObject("EventSystem", typeof(EventSystem));
        listener.AddComponent<StandaloneInputModule>();
        listener.AddComponent<BaseInput>();


     
    }

    

}
