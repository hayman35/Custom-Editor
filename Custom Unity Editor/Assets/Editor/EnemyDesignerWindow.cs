using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyDesignerWindow : EditorWindow {

    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D rougeSectionTexture;
    Texture2D warriorSectionTexture;

    color headerSectionColor = new color(13f/255f, 32f/255f, 44f/255f, 1f);

    Rect headerSection;
    Rect mageSection;
    Rect rougeSection;
    Rect warriorSection;

    [MenuItem("Window/Enemy Designer")]
    static void OpenWindow()
    {
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWinodw(typeof(EnemyDesignerWindow));
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

