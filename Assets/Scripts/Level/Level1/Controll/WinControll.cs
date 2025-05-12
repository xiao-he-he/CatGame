using level1model;
using UnityEngine;
using UnityEngine.Events;
using View.Select;

public class WinControll : MonoBehaviour
{
    public GameObject winImage;
    [SerializeField] private UnityEvent Lose;
    public MonoBehaviour[] scriptsToDisable;
    public bool isWin = false;
    public bool isLose = false;
    private void Update()
    {
        if (Level1Model.Instance.CatModel >= 20f&& isWin == false)
        {
            win();
            isWin = true;
        }
        if (Level1Model.Instance.Timing <= 0f && isLose == false)
        {
            if (Level1Model.Instance.CatModel < 20f)
            {
                lose();
                isLose = true;
            }
        }
    }
    private void lose()
    {
        EndUI.DefeatUI(Resources.Load<Sprite>("Image/Defeat/Level1/Lose"));
        Level1Model.Instance.Timing = 180f;
        Level1Model.Instance.CatModel = 0;
        
      
    }
    private void win()
    {

        EndUI.WinUI(Resources.Load<Sprite>("Image/Win/Level1S"));
        foreach (var script in scriptsToDisable)
        {
            script.enabled = false;
        }
    }
}
