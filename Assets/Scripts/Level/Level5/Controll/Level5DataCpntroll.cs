using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Level5DataCpntroll : MonoBehaviour
{
    // 声明所有需要恢复的 GameObject
    private GameObject roudian2;
    private GameObject roudian5;
    private GameObject roudian3;
    private GameObject roudian6;
    private GameObject roudian4;
    private GameObject roudian7;

    private GameObject sun;
    private GameObject moon;

    private GameObject blood1;
    private GameObject blood2;
    private GameObject blood3;
    private GameObject blood4;

    void Start()
    {
        FindAllObjects();
        LoadLevel5Data();
    }

    void FindAllObjects()
    {
        // 自动查找场景中的对象（名字需与Hierarchy一致）
        roudian2 = GameObject.Find("左2肉垫（按着才能出爪子");
        roudian5 = GameObject.Find("左1爪子");
        roudian3 = GameObject.Find("右1肉垫（按着才能出爪子");
        roudian6 = GameObject.Find("左2爪子");
        roudian4 = GameObject.Find("右2肉垫（按着才能出爪子");
        roudian7 = GameObject.Find("右1爪子");

        sun = GameObject.Find("太阳页面（能看见血丝）");
        moon = GameObject.Find("月亮页面（看不见血丝）");

        blood1 = GameObject.Find("左1血丝");
        blood2 = GameObject.Find("左2血丝");
        blood3 = GameObject.Find("右1血丝");
        blood4 = GameObject.Find("右4血丝");
    }

    void LoadLevel5Data()
    {
        string path = Application.persistentDataPath + "/level5.dat";
        if (!File.Exists(path))
        {
            Debug.LogWarning("未找到保存数据：" + path);
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            object deserialized = formatter.Deserialize(stream);

            // 尝试加载不同阶段的数据（只要有一个类匹配就可以加载）
            if (deserialized is Level5Controll.Level5SaveData d1)
            {
                Debug.Log("加载 Level5 数据 (Controll)");
                RestoreRoudian(roudian2, d1.roudian2PosX, d1.roudian2PosY, d1.roudian2PosZ);
                RestoreRoudian(roudian5, d1.roudian5PosX, d1.roudian5PosY, d1.roudian5PosZ);
                RestoreCommonState(d1.sunActive, d1.moonActive, d1.bloodActives);
            }
            else if (deserialized is Level5Controll2.Level5SaveData d2)
            {
                Debug.Log("加载 Level5 数据 (Controll2)");
                RestoreRoudian(roudian3, d2.roudian3PosX, d2.roudian3PosY, d2.roudian3PosZ);
                RestoreRoudian(roudian6, d2.roudian6PosX, d2.roudian6PosY, d2.roudian6PosZ);
                RestoreCommonState(d2.sunActive, d2.moonActive, d2.bloodActives);
            }
            else if (deserialized is Level5Controll3.Level5SaveData d3)
            {
                Debug.Log("加载 Level5 数据 (Controll3)");
                RestoreRoudian(roudian4, d3.roudian4PosX, d3.roudian4PosY, d3.roudian4PosZ);
                RestoreRoudian(roudian7, d3.roudian7PosX, d3.roudian7PosY, d3.roudian7PosZ);
                RestoreCommonState(d3.sunActive, d3.moonActive, d3.bloodActives);
            }
            else
            {
                Debug.LogError("无法识别的 Level5 数据格式！");
            }
        }
    }

    void RestoreRoudian(GameObject obj, float x, float y, float z)
    {
        if (obj != null)
        {
            obj.transform.position = new Vector3(x, y, z);
        }
    }

    void RestoreCommonState(bool sunActive, bool moonActive, bool[] bloodStates)
    {
        if (sun != null) sun.SetActive(sunActive);
        if (moon != null) moon.SetActive(moonActive);

        if (bloodStates != null && bloodStates.Length == 4)
        {
            if (blood1 != null) blood1.SetActive(bloodStates[0]);
            if (blood2 != null) blood2.SetActive(bloodStates[1]);
            if (blood3 != null) blood3.SetActive(bloodStates[2]);
            if (blood4 != null) blood4.SetActive(bloodStates[3]);
        }
    }
}
