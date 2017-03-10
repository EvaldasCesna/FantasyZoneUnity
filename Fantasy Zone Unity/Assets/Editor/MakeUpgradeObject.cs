using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeUpgradeObject
{
    [MenuItem("Assets/Create/Upgrade Object")]

    public static void Create()
    {
        UpGradeObject asset = ScriptableObject.CreateInstance<UpGradeObject>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/UpGrades/newUpgrade.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

    }

    [MenuItem("Assets/Create/Weapon Object")]


    public static void CreateWeapon()
    {
        WeponUpGrade asset = ScriptableObject.CreateInstance<WeponUpGrade>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/UpGrades/newWeapon.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

    }

    [MenuItem("Assets/Create/Bomb Object")]

    public static void CreateBomb()
    {
        BombUpgrade asset = ScriptableObject.CreateInstance<BombUpgrade>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/UpGrades/newBomb.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

    }

    [MenuItem("Assets/Create/Coin")]

    public static void CreateCoin()
    {
        Coin asset = ScriptableObject.CreateInstance<Coin>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/UpGrades/coinType.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

    }
}
