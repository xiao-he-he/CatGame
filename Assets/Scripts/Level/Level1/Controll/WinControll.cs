using level1model;
using UnityEngine;
using UnityEngine.Events;
using View.Select;

public class WinControll : MonoBehaviour
{
    public GameObject winImage;
    [SerializeField] private UnityEvent Lose;
    private void Update()
    {
        if (Level1Model.Instance.CatModel >= 20f)
        {
            win();
        }
        if (Level1Model.Instance.AllTime >= 150f)
        {
            if (Level1Model.Instance.CatModel < 20f)
            {
                lose();
                
            }
        }
    }
    private void lose()
    {
        EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level1/Lose"));
        Level1Model.Instance.AllTime = 0;
        Level1Model.Instance.CatModel = 0;
    }
    private void win()
    {
        
        EndUI.WinUI(Resources.Load<Sprite>("Image/Win/Level1S"));

    }
   
}
