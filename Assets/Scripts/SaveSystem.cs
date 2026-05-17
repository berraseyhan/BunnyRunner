using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{
    private string savePath;
    private List<int> highScores = new List<int>();
    private const int maxScores = 5;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/high_scores.json";
    }

    public void SaveScore(int score)
    {
        try
        {
            LoadScores();
            highScores.Add(score);
            highScores.Sort((a, b) => b.CompareTo(a));

            if (highScores.Count > maxScores)
                highScores.RemoveAt(highScores.Count - 1);

            string json = JsonUtility.ToJson(new ScoreData(highScores));
            File.WriteAllText(savePath, json);
            Debug.Log("Skor kaydedildi!");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Kayit hatasi: " + e.Message);
        }
    }

    public List<int> LoadScores()
    {
        try
        {
            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath);
                ScoreData data = JsonUtility.FromJson<ScoreData>(json);
                highScores = data.highScores;
                return highScores;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Yukleme hatasi: " + e.Message);
        }

        return new List<int>();
    }

    public void DeleteScores()
    {
        try
        {
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
                highScores.Clear();
                Debug.Log("Skorlar silindi!");
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Silme hatasi: " + e.Message);
        }
    }
}

[System.Serializable]
public class ScoreData
{
    public List<int> highScores;

    public ScoreData(List<int> scores)
    {
        this.highScores = scores;
    }
}
