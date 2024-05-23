using UnityEngine;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
    private string dbName = "URI=file:Player.db";
    public Transform usernameParent; // Parent object to hold the username text elements
    public Transform scoreParent; // Parent object to hold the score text elements
    public TMP_FontAsset fontAsset; // Font asset for TextMeshPro
    public Color textColor = Color.white; // Default text color
    public int fontSize = 36; // Default font size
    public float elementHeight = 50f; // Default height for each text element
    public Color scoreColor = new Color(1, 1, 1, 0.5f); // Color for the score text (transparent)

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu") // Check if the scene loaded is MainMenu
        {
            DisplayLeaderboard();
        }
    }

    void DisplayLeaderboard()
    {
        List<(string username, int score)> leaderboardEntries = GetTop10LeaderboardEntries();

        // Create leaderboard text elements for each entry
        foreach (var entry in leaderboardEntries)
        {
            // Create a new GameObject for the username text element
            GameObject usernameTextObject = new GameObject("UsernameText");
            usernameTextObject.transform.SetParent(usernameParent, false); // Set the parent and position

            // Add RectTransform component and set the height
            RectTransform usernameRectTransform = usernameTextObject.AddComponent<RectTransform>();
            usernameRectTransform.sizeDelta = new Vector2(usernameRectTransform.sizeDelta.x, elementHeight);

            // Add TextMeshProUGUI component for username
            TextMeshProUGUI usernameTextComponent = usernameTextObject.AddComponent<TextMeshProUGUI>();
            usernameTextComponent.text = entry.username; // Set the username text

            // Apply formatting for username
            usernameTextComponent.font = fontAsset; // Set the font asset
            usernameTextComponent.color = textColor; // Set the text color
            usernameTextComponent.fontSize = fontSize; // Set the font size
            usernameTextComponent.alignment = TextAlignmentOptions.Left; // Set the text alignment
            usernameTextComponent.enableWordWrapping = true; // Enable word wrapping

            // Create a new GameObject for the score text element
            GameObject scoreTextObject = new GameObject("ScoreText");
            scoreTextObject.transform.SetParent(scoreParent, false); // Set the parent and position

            // Add RectTransform component and set the height
            RectTransform scoreRectTransform = scoreTextObject.AddComponent<RectTransform>();
            scoreRectTransform.sizeDelta = new Vector2(scoreRectTransform.sizeDelta.x, elementHeight);

            // Add TextMeshProUGUI component for score
            TextMeshProUGUI scoreTextComponent = scoreTextObject.AddComponent<TextMeshProUGUI>();
            scoreTextComponent.text = entry.score.ToString(); // Set the score text

            // Apply formatting for score
            scoreTextComponent.font = fontAsset; // Set the font asset
            scoreTextComponent.color = scoreColor; // Set the text color (transparent)
            scoreTextComponent.fontSize = fontSize; // Set the font size
            scoreTextComponent.alignment = TextAlignmentOptions.Right; // Set the text alignment
            scoreTextComponent.enableWordWrapping = true; // Enable word wrapping
        }
    }

    List<(string username, int score)> GetTop10LeaderboardEntries()
    {
        List<(string username, int score)> leaderboardEntries = new List<(string username, int score)>();

        using (var connection = new SqliteConnection(dbName))
        {
            try
            {
                connection.Open();
                Debug.Log("Connection to the database opened.");

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT username, score FROM playerData ORDER BY score DESC LIMIT 10";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0) && !reader.IsDBNull(1)) // Check that the columns are not empty
                            {
                                string username = reader.GetString(0);
                                int score = reader.GetInt32(1);
                                leaderboardEntries.Add((username, score));
                            }
                        }
                    }
                }

                connection.Close();
                Debug.Log("Connection to the database closed.");
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Database connection error: " + ex.Message);
            }
        }

        return leaderboardEntries;
    }
}
