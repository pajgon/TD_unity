using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    private BuildingManager buildManager;


    private GameObject precanvas;
    private GameObject text;
    private GameObject button;
    private GameObject ButtonText;
    
    
    

    private void Start()
    {
        buildManager = GetComponent<BuildingManager>();
    precanvas = new GameObject();
    text = new GameObject();
    button = new GameObject();
    ButtonText = new GameObject();



        //nacte font pro text
        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");


        //vytvori Eventsystem k fungovani tlacitka
        GameObject listener = new GameObject("EventSystem", typeof(EventSystem));
        listener.AddComponent<StandaloneInputModule>();
        listener.AddComponent<BaseInput>();

      
        




        //vygeneruje canvas do ktereho se dava UI
        precanvas.name = "canvas";
        precanvas.AddComponent<Canvas>();
        precanvas.AddComponent<GraphicRaycaster>();
        precanvas.AddComponent<CanvasScaler>();
        Canvas canvas = precanvas.GetComponent<Canvas>();
        
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        //   canvas.worldCamera = GetComponent<Camera>();

        //nastaveni tlacitka
        button.name = "button";
        button.transform.parent = precanvas.transform;
        button.AddComponent<RectTransform>();
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        button.GetComponent<Button>().targetGraphic = button.GetComponent<Image>();
        button.GetComponent<Button>().onClick.AddListener(() => buildManager.Name());






        // text v tlacitku
        ButtonText.name = "TextButt";
        ButtonText.transform.parent = button.transform;
        ButtonText.AddComponent<RectTransform>();
        ButtonText.AddComponent<Text>().text = "VĚŽ";
        ButtonText.GetComponent<Text>().font = ArialFont;
        ButtonText.GetComponent<Text>().color = Color.black;
        ButtonText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        RectTransform TextButtSize = ButtonText.GetComponent<RectTransform>();
        TextButtSize.anchoredPosition3D = new Vector3(0f, 0f, 0f);
        TextButtSize.sizeDelta = new Vector2(0f, 0f);
        TextButtSize.anchorMin = new Vector2(0f, 0f);
        TextButtSize.anchorMax = new Vector2(1f, 1f);

        /*  var color =  button.GetComponent<Button>().colors;
          color.normalColor = Color.blue;
          button.GetComponent<Button>().colors = color;
          */







        //nastaveni textu
        text.name = "text";
        text.transform.parent = precanvas.transform;
        text.AddComponent<RectTransform>();
        text.AddComponent<Text>();


    

        // nacte velikost objektu
        RectTransform CanvasSize = precanvas.GetComponent<RectTransform>();
        RectTransform TextSize = text.GetComponent<RectTransform>();
        RectTransform ButtonSize = button.GetComponent<RectTransform>();


       





        ButtonSize.anchoredPosition3D = new Vector3(0f, 0f, 0f);
        ButtonSize.sizeDelta = new Vector2(0f, 0f);
        ButtonSize.anchorMin = new Vector2(0f, 0f);
        ButtonSize.anchorMax = new Vector2(0.1f, 0.1f);




        //nastaveni velikosti rohu
        TextSize.anchoredPosition3D = new Vector3(0f, 0f, 0f);
        TextSize.sizeDelta = new Vector2(0f, 0f);
        TextSize.anchorMin = new Vector2(0.5f, 0.5f);
        TextSize.anchorMax = new Vector2(1f, 1f);

        

        // nastaveni fontu
        Text textComponent = text.GetComponent<Text>();
        

        textComponent.font = ArialFont;
       
        // nastaveni textu
        textComponent.text = "Hello World";


    }

}
