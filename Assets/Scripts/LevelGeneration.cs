using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{


    /*public Transform[] oRow;
    public Transform[] sRow;
    public Transform[] tRow;
    public Transform[] fRow;*/


    public GameObject[] rooms;

    /*private int randStartingPos;
    private int randDrop;
    private int rand;
    private int randUp;*/

    public GameObject Player;





    public bool stopGeneration;


    /**
    private void Start()
    {

        randStartingPos = Random.Range(0, oRow.Length);
        transform.position = oRow[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        Player.transform.position = transform.position;

        
        rand = Random.Range(2, 4);

        do
        {
            randDrop = Random.Range(0, oRow.Length);

        } while (randDrop == randStartingPos);
        randUp = randDrop;
        transform.position = oRow[randDrop].position;
        Instantiate(rooms[rand], transform.position, Quaternion.identity);
        transform.position = sRow[randUp].position;
        do
        {
            rand = Random.Range(0, rooms.Length);

        } while (rand == 0 || rand == 2);
        Instantiate(rooms[rand], transform.position, Quaternion.identity);

        do
        {
            randDrop = Random.Range(0, sRow.Length);

        } while (randDrop == randUp);
        randUp = randDrop;
        transform.position = sRow[randDrop].position;

        rand = Random.Range(2, 4);

        Instantiate(rooms[rand], transform.position, Quaternion.identity);
        transform.position = tRow[randUp].position;
        do
        {
            rand = Random.Range(0, rooms.Length);

        } while (rand == 0 || rand == 2);
        Instantiate(rooms[rand], transform.position, Quaternion.identity);

        do
        {
            randDrop = Random.Range(0, tRow.Length);

        } while (randDrop == randUp);
        randUp = randDrop;
        transform.position = tRow[randDrop].position;
        rand = Random.Range(2, 4);
        Instantiate(rooms[rand], transform.position, Quaternion.identity);
        transform.position = fRow[randUp].position;
        do
        {
            rand = Random.Range(0, rooms.Length);

        } while (rand == 0 || rand == 2);
        Instantiate(rooms[rand], transform.position, Quaternion.identity);


        stopGeneration = true;

    }**/
    

    public void Start()
    {
        CreateMaze();
        DrawMaze();
       
    }

    private const int NUM_ROWS = 4;
    private const int NUM_COLS = 4;

    private const float MIN_X = -17;
    private const float MIN_Y = -33;

    private const int ROOM_DIMENSION = 10;

    public int[,] maze = new int[NUM_ROWS, NUM_COLS];

    private void CreateMaze()
    {
        int[] dropsPoints = new int[NUM_ROWS];
        for(int i = 0; i < NUM_ROWS; i++)
        {
            dropsPoints[i] = Random.Range(0, NUM_COLS);
        }

        for(int row = 0; row < NUM_ROWS; row++)
        {
            for(int col = 0;  col < NUM_COLS; col++)
            {
                maze[row, col] = 0;
            }
        }


        maze[NUM_ROWS - 1, dropsPoints[NUM_ROWS - 1]] = 2;

        for (int i = NUM_ROWS - 2; i >= 0; i--)
        {
            if (dropsPoints[i + 1] == dropsPoints[i])
            {
                maze[i, dropsPoints[i]] = 3;
            }
            else
            {
                maze[i, dropsPoints[i]] = 2;
                maze[i, dropsPoints[i + 1]] = 1;
            }
        }

        int spawnCol = Random.Range(0, NUM_COLS);
        while(spawnCol == dropsPoints[NUM_ROWS - 1])
        {
            spawnCol = Random.Range(0, NUM_COLS);
        }

        float xpoint = (MIN_X + (ROOM_DIMENSION/2)) + (ROOM_DIMENSION * spawnCol);
        float ypoint = (MIN_Y + (ROOM_DIMENSION/2)) + (ROOM_DIMENSION * (NUM_ROWS - 1));
        Player.transform.position = new Vector3(xpoint, ypoint, 0);
    }


    public void DrawMaze()
    {
        for(int y = 0; y < NUM_ROWS; y += 1)
        {
            for(int x = 0; x < NUM_COLS; x += 1)
            {
                float xpoint = (MIN_X + (ROOM_DIMENSION / 2)) + (ROOM_DIMENSION * x);
                float ypoint = (MIN_Y + (ROOM_DIMENSION / 2)) + (ROOM_DIMENSION * y);
                Instantiate( rooms[maze[y,x]] , new Vector3(xpoint, ypoint, 0), Quaternion.identity);
            }
        }
    }

}
