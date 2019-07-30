using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum PlayerSize { S1 = 0, S2 = 350, S3 = 2500, S4 = 4900, S5 = 6000, S6 = 7600, S7 = 10000, S8 = 12500 }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public const float SCALE_MULTIPLIER = 0.02f;
    private int _internalColorIdx = 0;
    private int GetColorIdx
    {
        get
        {
            if (_internalColorIdx >= availableColors.Length)
                _internalColorIdx = 0;

            return _internalColorIdx++;
        }
    }

    class PlayerData
    {
        public int pts;
        public Color color;
    }

    #region FIELDS
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private float gravityY = -20, startMatchTime;
    [SerializeField]
    private int nPlayersToSpawn, matchDurationSeconds = 30;

    [SerializeField]
    private Color[] availableColors;

    [SerializeField]
    private ObjectDestruction objectDestruction;

    [SerializeField]
    private Player playerPrefab, opponentsPrefab;
    [SerializeField]
    private TextBehaviour txtPrefab;
    #endregion


    public List<Player> playersRanking { get; private set; }
    public Color[] AvailableColors { get { return availableColors; } }

    private Dictionary<Player, PlayerData> players = new Dictionary<Player, PlayerData>();
    private Player userPlayer;
    private Camera gameCamera;
    private bool isGameStarted = false;

    #region EVENTS
    //events
    public System.Action<int> onScoreUpdate;    //new score
    public System.Action<float> onTimerUpdate;  //current time
    public System.Action<int> onMatchEnded; //passed final score
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        Instance = this;

        Physics.gravity = new Vector3(0, gravityY, 0);
        playersRanking = new List<Player>();

        //spawn player
        var p = Instantiate(playerPrefab, spawnPoints[0].position, Quaternion.identity);
        p.SetPlayerColor(Color.white);
        userPlayer = p;
        players.Add(p, new PlayerData());
        playersRanking.Add(p);  //add for ranking (will be sorted)

        //spawn ais
        for (int i = 0; i < nPlayersToSpawn; i++)
        {
            p = Instantiate(opponentsPrefab, spawnPoints[i + 1].position, Quaternion.identity);
            var color = availableColors[GetColorIdx];
            p.SetPlayerColor(color);
            players.Add(p, new PlayerData() { color = color });
            playersRanking.Add(p);  //add for ranking (will be sorted)
        }

        this.objectDestruction.onBuildingEaten += OnBuildingEaten;
    }
    // Start is called before the first frame update
    private void Start()
    {
        gameCamera = Camera.main;
    }
    private void Update()
    {
        if (isGameStarted)
            if (onTimerUpdate != null)
                onTimerUpdate.Invoke(matchDurationSeconds - (Time.time - startMatchTime));
    }
    #endregion

    #region INTERNAL
    void OnBuildingEaten(Building b)
    {
        //scale objs (remove from layer class but access b.owner)
        if (b.Owner == null)
            return;

        b.Owner.OnBuildingEaten(b);

        //add pts 
        int newPts = players[b.Owner].pts += b.GetPts() * 2;
        b.Owner.RefreshLevel(players[b.Owner].pts);

        if (b.Owner == GetUser())
            this.onScoreUpdate.Invoke(newPts);

        Vector3 dirToCamera = (gameCamera.transform.position - b.Owner.transform.position).normalized;
        var txt = Instantiate(txtPrefab, b.Owner.transform.position + dirToCamera * 2f, Quaternion.identity);
        txt.Setup(this.gameCamera, players[b.Owner].color, (b.GetPts() * 2).ToString());
        Destroy(txt.gameObject, 0.7f);

        //do something
        //make new event for reorder list
        //make new event for your points
    }
    IEnumerator MatchCoroutine()
    {
        this.startMatchTime = Time.time;
        yield return new WaitForSeconds(this.matchDurationSeconds);

        EndGame();
    }

    void SetAllPlayerMovements(bool active)
    {
        foreach (var player in players)
        {
            player.Key.SetMovementEnabled(active);
        }
    }
    #endregion

    #region API
    public void StartGame()
    {
        StartCoroutine(MatchCoroutine());
        UIController.Instance.StartGame();
        SetAllPlayerMovements(true);
        isGameStarted = true;

        var playerColor = UIController.Instance.GetUISelectedPlayerColor();
        GetUser().SetPlayerColor(playerColor);
        players[GetUser()].color = playerColor;
    }
    public void EndGame()
    {
        onMatchEnded.Invoke(players[GetUser()].pts);
        UIController.Instance.EndGame();
        SetAllPlayerMovements(false);
        isGameStarted = false;
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.isPlaying = false;
#endif
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public PlayerSize GetUserSize()
    {
        return userPlayer.GetSize();
    }
    public Player GetUser()
    {
        return userPlayer;
    }
    public List<Player> GetPlayerList(Player exclude)
    {
        return (from p in players where p.Key != exclude && p.Key != userPlayer select p.Key).ToList();
    }
    #endregion

    //public Color GetPlayerColor(Player p)
    //{
    //    return players[p].color;
    //}
}
