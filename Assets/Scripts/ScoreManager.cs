using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public string Name;
    public string HighScoreName;
    public int HighScore = 0;

    public InputField InputName;

    private void Awake(){
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    [System.Serializable]
    class SaveData{
        public string Name;
        public int Score;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(){
        Name=InputName.text;
    }

    public void LoadMainScene(){
        SceneManager.LoadScene("main");
    }

    public void SaveHighScore(int pScore){
        SaveData data = new SaveData();
        data.Name=Name;
        data.Score=pScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore(){
        string path= Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreName=data.Name;
            HighScore=data.Score;
        }
    }

}
