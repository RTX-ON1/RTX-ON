using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomGenerator : MonoBehaviour
{

    public enum Direction { up, down, left, right };
    public Direction direction;
    public Text timeText;
    private float gameTime = GlobalControl.Instance.SecondsForExam();

    [Header("房间信息")]
    public GameObject roomPrefab;
    public int roomNumber;
    public Color startColor, endColor;
    private GameObject endRoom;

    [Header("位置控制")]
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;
    public LayerMask roomLayer;
    public int maxStep;

    public List<Room> rooms = new List<Room>();

    List<GameObject> farRooms = new List<GameObject>();
    List<GameObject> lessFarRooms = new List<GameObject>();
    List<GameObject> oneWayRooms = new List<GameObject>();

    public WallType wallType;

    public GameObject gameOverPanel;
    public GameObject Map;
    public Text finalScoreText;
    public int score;
    public bool gameOver;
    public GameObject TutorialPanel;

    private int M_time;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("BGM").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BGMVolume");
        for (int i = 0; i < roomNumber; i++)
        {
            rooms.Add(Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>());

            ChangePointPos();

        }

        rooms[0].GetComponent<SpriteRenderer>().color = startColor;

        endRoom = rooms[0].gameObject;
        foreach (var room in rooms)
        {
            //if (room.transform.position.sqrMagnitude > endRoom.transform.position.sqrMagnitude)
            //{
            //    endRoom = room.gameObject;
            //}
            SetupRoom(room, room.transform.position);
        }

        FindEndRoom();

        endRoom.GetComponent<SpriteRenderer>().color = endColor;
        M_time = 0;

        if (!PlayerPrefs.HasKey("ExaminationTutorial"))
        {
            PlayerPrefs.SetInt("ExaminationTutorial", 1);
            TutorialPanel.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            gameTime = 0;
            //显示我们的失败面板
            gameOverPanel.SetActive(true);
            score = GlobalControl.Instance.ToExamScore(GlobalControl.Instance.ExamScore);
            finalScoreText.text = score.ToString();
            gameOver = true;
            GameObject.Find("Player").GetComponent<PlayerController>().speed = 0;
        }
        timeText.text = gameTime.ToString("0");
        if (Input.GetKey(KeyCode.M))
        {
            if(M_time > 30)
            {
                Debug.Log("m");
                M_time = 0;
                if(Map.activeSelf)
                    Map.SetActive(false);
                else Map.SetActive(true);
            }
            
        }
        M_time++;
        if (Input.anyKeyDown)
        {
            TutorialPanel.SetActive(false);
        }
    }

    public void ChangePointPos()
    {

        do
        {
            direction = (Direction)Random.Range(0, 4);

            switch (direction)
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, yOffset, 0);
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0, -yOffset, 0);
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-xOffset, 0, 0);
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(xOffset, 0, 0);
                    break;
            }
        } while (Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomLayer));

        
    }

    public void SetupRoom(Room newRoom, Vector3 roomPosition)
    {
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), 0.2f, roomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), 0.2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.2f, roomLayer);

        newRoom.UpdateRoom(xOffset, yOffset);

        switch (newRoom.doorNumber)
        {
            case 1:
                if (newRoom.roomUp)
                    Instantiate(wallType.wallU, roomPosition, Quaternion.identity);
                if (newRoom.roomDown)
                    Instantiate(wallType.wallD, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft)
                    Instantiate(wallType.wallL, roomPosition, Quaternion.identity);
                if (newRoom.roomRight)
                    Instantiate(wallType.wallR, roomPosition, Quaternion.identity);
                break;
            case 2:
                if (newRoom.roomUp && newRoom.roomDown)
                    Instantiate(wallType.wallUD, roomPosition, Quaternion.identity);
                if (newRoom.roomUp && newRoom.roomLeft)
                    Instantiate(wallType.wallUL, roomPosition, Quaternion.identity);
                if (newRoom.roomUp && newRoom.roomRight)
                    Instantiate(wallType.wallUR, roomPosition, Quaternion.identity);
                if (newRoom.roomDown && newRoom.roomLeft)
                    Instantiate(wallType.wallDL, roomPosition, Quaternion.identity);
                if (newRoom.roomDown && newRoom.roomRight)
                    Instantiate(wallType.wallDR, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft && newRoom.roomRight)
                    Instantiate(wallType.wallLR, roomPosition, Quaternion.identity);
                break;
            case 3:
                if (newRoom.roomUp && newRoom.roomLeft && newRoom.roomRight)
                    Instantiate(wallType.wallULR, roomPosition, Quaternion.identity);
                if (newRoom.roomUp && newRoom.roomDown && newRoom.roomLeft)
                    Instantiate(wallType.wallUDL, roomPosition, Quaternion.identity);
                if (newRoom.roomUp && newRoom.roomDown && newRoom.roomRight)
                    Instantiate(wallType.wallUDR, roomPosition, Quaternion.identity);
                if (newRoom.roomDown && newRoom.roomLeft && newRoom.roomRight)
                    Instantiate(wallType.wallDLR, roomPosition, Quaternion.identity);
                break;
            case 4:
                if (newRoom.roomUp && newRoom.roomLeft && newRoom.roomRight && newRoom.roomDown)
                    Instantiate(wallType.wallUDLR, roomPosition, Quaternion.identity);
                break;
        }
    }

    public void FindEndRoom()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].stepToStart > maxStep)
                maxStep = rooms[i].stepToStart;
        }

        foreach (var room in rooms)
        {
            if (room.stepToStart == maxStep)
                farRooms.Add(room.gameObject);
            if (room.stepToStart == maxStep - 1)
                lessFarRooms.Add(room.gameObject);
        }

        for (int i = 0; i < farRooms.Count; i++)
        {
            if (farRooms[i].GetComponent<Room>().doorNumber == 1)
                oneWayRooms.Add(farRooms[i]);
        }
        for (int i = 0; i < lessFarRooms.Count; i++)
        {
            if (lessFarRooms[i].GetComponent<Room>().doorNumber == 1)
                oneWayRooms.Add(lessFarRooms[i]);
        }

        if(oneWayRooms.Count != 0)
        {
            endRoom = oneWayRooms[Random.Range(0, oneWayRooms.Count)];
        }
        else
        {
            endRoom = farRooms[Random.Range(0, farRooms.Count)];
        }
    }

    public void BackToMain()
    {
        GlobalControl.Instance.FinalScore[GlobalControl.Instance.stage - 1] = 100 * score/(score + 20);
        SceneManager.LoadScene("Main Stage");
    }

    

}

[System.Serializable]
public class WallType
{
    public GameObject wallL, wallR, wallU, wallD, wallUD, wallUL, wallUR, wallLR, wallDL, wallDR, wallUDL, wallUDR, wallULR, wallDLR, wallUDLR;

}
