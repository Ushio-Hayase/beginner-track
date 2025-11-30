using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    
    private GameObject wall;
    private GameObject user;
    public GameObject enemy;

    private float prev_summon_time = 0;

    public Vector2 map_top_left_pos;
    public Vector2 map_bottom_right_pos;
    private Transform transform;
    
    public TextMeshProUGUI scoreTxt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            score = 0;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(enemy);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Scene")
        {
            wall = GameObject.Find("Wall");
            user = GameObject.Find("Player");

            transform = user.GetComponent<Transform>();
            
            var box = wall.GetComponent<EdgeCollider2D>().points;

            map_top_left_pos = transform.TransformPoint(box[2]);
            map_bottom_right_pos = transform.TransformPoint(box[0]);

            scoreTxt = GameObject.Find("IngameScore").GetComponent<TextMeshProUGUI>();
            scoreTxt.text = "Score" + score.ToString();
        }

        if (scene.name == "MainMenu")
        {
            scoreTxt = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
            scoreTxt.text = "Score: " + score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Scene"))
        {
            prev_summon_time += Time.fixedDeltaTime;
            if (prev_summon_time > 1)
            {
                Vector2 new_pos = new Vector2();
                Vector2 user_pos = transform.position;
                do
                {
                    new_pos.x = Random.Range(map_top_left_pos.x, map_bottom_right_pos.x);
                    new_pos.y = Random.Range(map_top_left_pos.y, map_bottom_right_pos.y);
                } while (!((new_pos.x <= user_pos.x - 1 || new_pos.x >= user_pos.x + 1) &&
                           (new_pos.y <= user_pos.y - 1 ||
                            new_pos.y >= user_pos.y + 1)));



                Instantiate(enemy, new_pos, Quaternion.identity);

                prev_summon_time = 0;
            }
        }
    }
    
    public void OnClickStart()
    {
        SceneManager.LoadScene("Scene");
    }
}
