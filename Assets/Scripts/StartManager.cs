using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class StartManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;



    private void Start()
    {
        if (SaveData.Instance.highScoreName !="")
        {
            highScoreText.text =SaveData.Instance.highScoreName+ " has the highscore: " + SaveData.Instance.highScore;
        }
        else
        {
            highScoreText.text = "";
        }
    }
    public void StartPress()
    {  
        //Move to Next Scene
        SceneManager.LoadScene(1);
    }
    public void QuitPress()
    {
        Application.Quit();
    }

   

}
