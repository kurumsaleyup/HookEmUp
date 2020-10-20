using UnityEngine;

public class hookScript : MonoBehaviour
{
    private LineRenderer lr;
    public bool throwHook;
    private bool moveHook = false;
    private float hookSpeed = 5f;
    private Vector3[] positions;

    public GameObject Player;
     // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        positions = new Vector3[2];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveHook = true;
            throwHook = true;
        }
        if (moveHook)
        {
            if (throwHook)
            {
                //ilk pozisyon karaktere sabit eğer car hareket ederse ilk pozisyonu güncelle
                gameObject.transform.Translate(Player.transform.forward * Time.deltaTime * hookSpeed);//hook cube movement
                positions[0] = Player.transform.position;//player positions will be setted in game
                Vector3 movez = new Vector3(Player.transform.position.x, Player.transform.position.y, gameObject.transform.position.z * Time.deltaTime * hookSpeed);
                positions[1] = movez;
                lr.positionCount = positions.Length;
                lr.SetPositions(positions);
                lr.loop = true; //render line between two points by continiously looping
            }
            else
            {
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime * hookSpeed);
                positions[0] = gameObject.transform.position; //player positions will be setted in game
                Vector3 movez = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z * Time.deltaTime * hookSpeed);
                positions[1] = movez;
                lr.positionCount = positions.Length;
                lr.SetPositions(positions);
                lr.loop = true;
                //hookableobject.transform.position = Vector3.MoveTowards(hookableobject.transform.position, gameObject.transform.position, hookSpeed * Time.deltaTime);
            }
        }

    }
}
