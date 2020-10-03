using System;
using UnityEngine;
using UnityEditor;

public class EnemyDesignerWindow : EditorWindow {

    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D rougeSectionTexture;
    Texture2D warriorSectionTexture;

    Color headerSectionColor = new Color(13f/255f, 32f/255f, 44f/255f, 1f);

    Rect headerSection;
    Rect mageSection;
    Rect rougeSection;
    Rect warriorSection;

  
    
        [MenuItem("Custom Unity Editor/Enemy Designer")]
        private static void ShowWindow() {
            var window = GetWindow<EnemyDesignerWindow>();
            window.titleContent = new GUIContent("Enemy Designer");
            window.minSize = new Vector2(600,300);
            window.Show();
        }


    void OnEnable() 
    {
        InitTextures();
    }

    void InitTextures()
    {
        headerSectionTexture = new Texture2D(1,1);
        headerSectionTexture.SetPixel(0,0,headerSectionColor);
        headerSectionTexture.Apply();

        mageSectionTexture = Resources.Load<Texture2D>("Icons/mage");
        rougeSectionTexture = Resources.Load<Texture2D>("Icons/rouge");
        warriorSectionTexture = Resources.Load<Texture2D>("Icons/warrior");
    }


    void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawMageSettings();
        DrawWarriorSettings();
        DrawRougeSettings();
    }

    // defines Rect values and paints textures based on rects  
    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width; 
        headerSection.height = 50;

        mageSection.x = 0;
        mageSection.y = 50;
        mageSection.width = Screen.width / 3f; 
        mageSection.height = Screen.width - 50;

        warriorSection.x = Screen.width / 3f;
        warriorSection.y = 50;
        warriorSection.width = Screen.width / 3f; 
        warriorSection.height = Screen.width - 50;

        rougeSection.x = Screen.width / 3f * 2;
        rougeSection.y = 50;
        rougeSection.width = Screen.width / 3f; 
        rougeSection.height = Screen.width - 50;

        

        GUI.DrawTexture(headerSection,headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(rougeSection, rougeSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
        
     
    }
    void DrawHeader()
    {

    }
    void DrawMageSettings()
    {

    }
    void DrawWarriorSettings()
    {

    }
    void DrawRougeSettings()
    {

    }

    
}

