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

    static MageData mageData;
    static WarriorData warriorData;
    static RougeData rougeData;

    public static MageData MageInfo { get { return mageData; } }
    public static WarriorData WarriorInfo { get { return warriorData; } }
    public static RougeData RouugeInfo { get { return rougeData; } }


    
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
        InitData();
    }

    public static void InitData()
    {
       mageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
       warriorData = (WarriorData)ScriptableObject.CreateInstance(typeof(WarriorData));
       rougeData = (RougeData)ScriptableObject.CreateInstance(typeof(RougeData));
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
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Enemy Designer");


        GUILayout.EndArea();
    }
    void DrawMageSettings()
    {
        GUILayout.BeginArea(mageSection);

        GUILayout.Label("Mage Section");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage");
        mageData.dmgType = (Types.MageDmgType)EditorGUILayout.EnumPopup(mageData.dmgType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon");
        mageData.wpnType = (Types.MageWpnType)EditorGUILayout.EnumPopup(mageData.wpnType);
        EditorGUILayout.EndHorizontal();

        if(GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWinow(GeneralSettings.SettingsType.MAGE);
        }


        GUILayout.EndArea();
    }
    void DrawWarriorSettings()
    {
        GUILayout.BeginArea(warriorSection);

        GUILayout.Label("Warrior Area");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Class");
        warriorData.classType = (Types.WarriorClassType)EditorGUILayout.EnumPopup(warriorData.classType);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        GUILayout.Label("Weapon");
        warriorData.wpnType = (Types.WarriorWpnType)EditorGUILayout.EnumPopup(warriorData.wpnType);
        EditorGUILayout.EndHorizontal();


        if(GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWinow(GeneralSettings.SettingsType.WARRIOR);
        }


        GUILayout.EndArea();
    }
    void DrawRougeSettings()
    {
        GUILayout.BeginArea(rougeSection);

        GUILayout.Label("Rouge Area");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Strategy");
        rougeData.strategyType = (Types.RougeStrategyType)EditorGUILayout.EnumPopup(rougeData.strategyType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon");
        rougeData.wpnType = (Types.RougeWpnType)EditorGUILayout.EnumPopup(rougeData.wpnType);
        EditorGUILayout.EndHorizontal();


        if(GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWinow(GeneralSettings.SettingsType.ROUGE);
        }



        GUILayout.EndArea();
    }

    
}

public class GeneralSettings : EditorWindow {

    public enum SettingsType
    {
        MAGE,
        WARRIOR,
        ROUGE
    }
    static SettingsType dataSetting;
    static GeneralSettings window;

    public static void OpenWinow(SettingsType settings)
    {
        dataSetting = settings;
        window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(250, 100);
        window.Show();
    }

    void OnGUI() {
        switch (dataSetting)
        {
            case SettingsType.MAGE:
                DrawSetting((CharacterData)EnemyDesignerWindow.MageInfo);
                break;
            case SettingsType.ROUGE:
                DrawSetting((CharacterData)EnemyDesignerWindow.RouugeInfo);
                break;
            case SettingsType.WARRIOR:
                DrawSetting((CharacterData)EnemyDesignerWindow.WarriorInfo);
                break; 
        }
    }
    
    void DrawSetting(CharacterData charData)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefab");
        charData.prefab = (GameObject)EditorGUILayout.ObjectField(charData.prefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Energy");
        charData.maxEnergy = EditorGUILayout.FloatField(charData.maxEnergy);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Health");
        charData.maxHealth = EditorGUILayout.FloatField(charData.maxHealth);
        EditorGUILayout.EndHorizontal();

        
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Power");
        charData.power = EditorGUILayout.Slider(charData.power,0, 100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("% Crit Chance");
        charData.critChance = EditorGUILayout.Slider(charData.critChance,0, charData.power);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name");
        charData.name = EditorGUILayout.TextField(charData.name);
        EditorGUILayout.EndHorizontal();

        if(charData.prefab == null)
        {
            EditorGUILayout.HelpBox("This enemy needs a [Prefab] before it can be created", MessageType.Warning);
        }
        else if (GUILayout.Button("Finish and Save", GUILayout.Height(30)))
        {
            SaveCharacterData();
            window.Close();
        }

        else if(charData.name == null)
        {
            EditorGUILayout.HelpBox("This enemy needs a [name] before it can be created", MessageType.Warning);
        }

        
    }

    void SaveCharacterData()
    {
        string prefabPath, 
        newPrefabPath = "Assets/Prefabs/Character/", 
        dataPath = "Assets/Resources/CharacterData/Data";

        switch(dataSetting)
        {
            case SettingsType.MAGE:
                // create .asset file 
                dataPath += "/mage/" + EnemyDesignerWindow.MageInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.MageInfo, dataPath);

                newPrefabPath += "/mage/" + EnemyDesignerWindow.MageInfo.name + ".prefab";

                // get prefab path
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.MageInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath,newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject magePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath,typeof(GameObject));
                if(!magePrefab.GetComponent<Mage>())
                {
                    magePrefab.AddComponent(typeof(Mage));
                    magePrefab.GetComponent<Mage>().mageData = EnemyDesignerWindow.MageInfo;
                }
                break;

            case SettingsType.WARRIOR:
                // create .asset file 
                dataPath += "/warrior/" + EnemyDesignerWindow.WarriorInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.WarriorInfo, dataPath);

                newPrefabPath += "/warrior/" + EnemyDesignerWindow.WarriorInfo.name + ".prefab";

                // get prefab path
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.WarriorInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath,newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject warriorPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath,typeof(GameObject));
                if(!warriorPrefab.GetComponent<Warrior>())
                {
                    warriorPrefab.AddComponent(typeof(Warrior));
                    warriorPrefab.GetComponent<Warrior>().WarriorData = EnemyDesignerWindow.WarriorInfo;
                }
                break;

            case SettingsType.ROUGE:
                // create .asset file 
                dataPath += "/rouge/" + EnemyDesignerWindow.RouugeInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.RouugeInfo, dataPath);

                newPrefabPath += "/rouge/" + EnemyDesignerWindow.RouugeInfo.name + ".prefab";

                // get prefab path
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.RouugeInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath,newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject rougePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath,typeof(GameObject));
                if(!rougePrefab.GetComponent<Rouge>())
                {
                    rougePrefab.AddComponent(typeof(Rouge));
                    rougePrefab.GetComponent<Rouge>().rougeData = EnemyDesignerWindow.RouugeInfo;
                }
                break;
        }
    }
}

