using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Controll : MonoBehaviour
{

    public GameObject roudian2;
   
    
    public GameObject roudian5;
   
    
   
    public string script;
    public GameObject UIimage;
    public GameObject sun;
    public GameObject moon;
    public GameObject blood1;
    public GameObject blood2;   
    public GameObject blood3;   
    public GameObject blood4;   
    
  public void judge1()
    {
        UIimage.SetActive(false);
        if (roudian5.transform.position.x <= Level5Model.Instance.xLimitMax1&& roudian5.transform.position.x >= Level5Model.Instance.xLimitMin1)
  
        {
            MonoBehaviour targetScript = (MonoBehaviour)roudian2.GetComponent(script);
            targetScript.enabled = true;
            sun.SetActive(false);   
            moon.SetActive(true);
            blood1.SetActive(false);
            blood2.SetActive(false);    
            blood3.SetActive(false);    
            blood4.SetActive(false);
            SaveLevel5Data();
        }
        else
        {
            SceneManager.LoadScene(6);
        }

       
    }
    private void SaveLevel5Data()
    {
        Level5SaveData data = new Level5SaveData
        {
            roudian2PosX = roudian2.transform.position.x,
            roudian2PosY = roudian2.transform.position.y,
            roudian2PosZ = roudian2.transform.position.z,

            roudian5PosX = roudian5.transform.position.x,
            roudian5PosY = roudian5.transform.position.y,
            roudian5PosZ = roudian5.transform.position.z,

            moonActive = moon.activeSelf,
            sunActive = sun.activeSelf,
            bloodActives = new bool[]
            {
            blood1.activeSelf,
            blood2.activeSelf,
            blood3.activeSelf,
            blood4.activeSelf
            }
        };

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level5.dat";
        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }

        Debug.Log("Level5 数据已保存！");
    }

    [System.Serializable]
    public class Level5SaveData
    {
        public float roudian2PosX;
        public float roudian2PosY;
        public float roudian2PosZ;

        public float roudian5PosX;
        public float roudian5PosY;
        public float roudian5PosZ;

        public bool moonActive;
        public bool sunActive;
        public bool[] bloodActives;
    }
}


