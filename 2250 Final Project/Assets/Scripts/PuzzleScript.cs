using TMPro;
using UnityEngine;

public class PuzzleScript : MonoBehaviour
{
    [SerializeField] private TMP_Text endPanelTimeText;
    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] private TilesScript[] tiles;
    private int emptySpaceIndex =15;
    private bool _isFinished;
    //public GameObject LightBulb1;
    //public GameObject LightBulb2;
    //public GameObject LightBulb3;
    //public GameObject LightBulb4;
    public GameObject EndCanvas;

    void Start()
    {
        _camera = Camera.main;
        //LightBulb1.SetActive(true);
        //LightBulb2.SetActive(true);
        //LightBulb3.SetActive(true);
        //LightBulb4.SetActive(true);
        EndCanvas.SetActive(false);
        Shuffle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 2.5)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }

        }


        if (!_isFinished)
        {
            int correctTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                    {
                        correctTiles++;
                    }
                }
            }

            if (correctTiles == tiles.Length - 1)
            {
                _isFinished = true;
                //LightBulb1.SetActive(false);
                //LightBulb2.SetActive(false);
                //LightBulb3.SetActive(false);
                //LightBulb4.SetActive(false);
                EndCanvas.SetActive(true);
                Debug.Log("WIN");
                    var a = GetComponent<TimerScript>();
                a.StopTimer();
                endPanelTimeText.text =(a.minutes < 10 ? "0" : "") + a.minutes + ":" + (a.seconds < 10 ? "0" : "") + a.seconds;
            }
        }

    }

    //public void Shuffle()
    //{
    //    //if (emptySpaceIndex != 15)
    //    //{
    //    //    Vector3 tileOn15LastPos = tiles[15].targetPosition;
    //    //    tiles[15].targetPosition = emptySpace.position;
    //    //    emptySpace.position = tileOn15LastPos;
    //    //    tiles[emptySpaceIndex] = tiles[15];
    //    //    tiles[15] = null;
    //    //    emptySpaceIndex = 15;
    //    //}

    //    int inversion;
    //    do
    //    {
    //        for (int i = 0; i < 15; i++)
    //        {
    //            var lastPos = tiles[i].targetPosition;
    //            int randomIndex = Random.Range(0, 15);
    //            tiles[i].targetPosition = tiles[randomIndex].targetPosition;
    //            tiles[randomIndex].targetPosition = lastPos;
    //            var tile = tiles[i];
    //            tiles[i] = tiles[randomIndex];
    //            tiles[randomIndex] = tile;
    //        }
    //        inversion = GetInversions();
    //        Debug.Log("shuffled");
    //    } while (inversion % 2 != 0);
    //}

    public void Shuffle()
    {
        int inversion;
        do
        {
            for (int i = 0; i < 15; i++) // Shuffle only the first 15 tiles
            {
                var lastPos = tiles[i].targetPosition;
                int randomIndex = Random.Range(0, 15);
                // Swap the positions of the tiles
                tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                tiles[randomIndex].targetPosition = lastPos;
                // Swap the tiles in the array
                var tile = tiles[i];
                tiles[i] = tiles[randomIndex];
                tiles[randomIndex] = tile;
            }

            inversion = GetInversions();
            // Optional: print the number of inversions for debugging
            Debug.Log($"Shuffled with inversions: {inversion}");

        } while (inversion % 2 != 0); // Ensure we have an even number of inversions
    }




    public int findIndex(TilesScript ts)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;
    }





    int GetInversions()
    {
        int inversionsSum = 0; // Start the count at 0
        for (int i = 0; i < tiles.Length; i++)
        {
            // Skip the empty space for inversion count.
            if (tiles[i] == null) continue;

            for (int j = i + 1; j < tiles.Length; j++)
            {
                // Skip the empty space for inversion count.
                if (tiles[j] == null) continue;

                // Count the inversion if a larger numbered tile is followed by a smaller numbered tile.
                if (tiles[i].number > tiles[j].number)
                {
                    inversionsSum++;
                }
            }
        }
        return inversionsSum;
    }



}