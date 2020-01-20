using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject prefabPlatform;
    public GameObject prefabFloor;
    public GameObject prefabCeiling;
    public GameObject prefabCollectible;
    public GameObject prefabEnemy;
    public GameObject prefabMovingEnemy;
    public GameObject prefabBorder;

    int distanceThreshold = 30;

    //TODO: refactor to c# - generator classes

    /* Level */
    public int xzRange = 10; //level size
    int initialGeneratedFloorY = -50; //floor
    int initialGeneratedCeilingY = 50; //ceiling

    /* Platform */
    int distanceBetweenPlatformYMin = 1;
    int distanceBetweenPlatformYMax = 3;
    int initialGeneratedPlatformY = -3;

    /* Collectible */
    int distanceBetweenCollectibleYMin = 4;
    int distanceBetweenCollectibleYMax = 8;
    int initialGeneratedCollectibleY = -15;

    /* Enemy */
    int distanceBetweenEnemyYMin = 4;
    int distanceBetweenEnemyYMax  = 8;
    int initialGeneratedEnemyY = -15;

    /* MovingEnemy */
    int distanceBetweenMovingEnemyYMin = 10;
    int distanceBetweenMovingEnemyYMax = 20;
    int initialGeneratedMovingEnemyY = -50;

    int randomSeed;
    int mapSize;
    int levelID;


    // Start is called before the first frame update
    void Start()
    {
        var sceneManager = GameObject.Find("SceneManager");
        
        if (sceneManager == null)
        {
            Debug.Log("debugging - running scene alone");
            levelID = 9999;
            randomSeed = 0;
            mapSize = 3000;
        }
        else
        {
            levelID = sceneManager.GetComponent<Scenes>().GetLevelID();
            randomSeed = sceneManager.GetComponent<Scenes>().GetLevelSeed();
            mapSize = sceneManager.GetComponent<Scenes>().GetLevelMapSize();
        }   

        PrintLevelInformation();
        Random.seed = randomSeed;
        GenerateBorderWalls();
        GenerateFloor(0, initialGeneratedFloorY, 0);
        GenerateCeiling(0, initialGeneratedCeilingY,0);             
    }

    void PrintLevelInformation()
    {
        Debug.Log("Level Information");
        Debug.Log("Loaded level's ID: " + levelID);
        Debug.Log("Loaded level's map size: " + mapSize);
        Debug.Log("Loaded level's seed number: " + randomSeed);
    }

    // Update is called once per frame
    void Update()
    {
        GeneratePlatform();
        GenerateEnemy();
        GenerateMovingEnemy();
        GenerateCollectible();        
    }
    
    void GenerateBorderWalls()
    {
        var xzBorderRange = xzRange + 0.5f;

        var borderArray = new List<GameObject>();		
        borderArray.Add(Instantiate(prefabBorder, new Vector3(-xzBorderRange, 0, -xzBorderRange), Quaternion.identity));
        borderArray.Add(Instantiate(prefabBorder, new Vector3(-xzBorderRange, 0, -xzBorderRange), Quaternion.Euler(0,90,0)));
        borderArray.Add(Instantiate(prefabBorder, new Vector3(xzBorderRange, 0, xzBorderRange), Quaternion.Euler(0,180,0)));
        borderArray.Add(Instantiate(prefabBorder, new Vector3(xzBorderRange, 0, -xzBorderRange), Quaternion.Euler(0,270,0)));
        
        foreach (var border in borderArray) {
            var scale = border.transform.localScale;
            scale.x = 8*xzRange;
            border.transform.localScale = scale;
            border.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void GeneratePlatform()
    {
        int platformY = initialGeneratedPlatformY;
        GameObject camera = GameObject.Find("Main Camera");
        while (platformY*-1 < mapSize &&
            camera.transform.position.y < distanceThreshold + platformY)
        {
            var randomX=Random.Range(-xzRange, xzRange);
            var randomY=Random.Range(distanceBetweenPlatformYMin, distanceBetweenPlatformYMax);
            platformY= platformY - randomY;
            var randomZ=Random.Range(-xzRange,xzRange);
            
            Instantiate(prefabPlatform,
                        new Vector3(randomX, platformY, randomZ),
                        Quaternion.identity);
            //Debug.Log("GeneratePlatform.js: Generated platform " + 
            //			"X: " + randomX + " Y: " + platformY +" Z: " +randomZ);
        }
    }

    
    void GenerateCollectible()
    {
        int collectibleY = initialGeneratedCollectibleY;
        GameObject camera = GameObject.Find("Main Camera");
        while (collectibleY*-1 < mapSize &&
                    camera.transform.position.y < distanceThreshold + collectibleY)
            {
                var crandomX=Random.Range(-xzRange, xzRange);
                var crandomY=Random.Range(distanceBetweenCollectibleYMin, distanceBetweenCollectibleYMax);
                collectibleY= collectibleY - crandomY;
                var crandomZ=Random.Range(-xzRange, xzRange);
                
                var crandomAngleX = Random.Range(0, 20);
                var crandomAngleY = Random.Range(0, 60);
                var crandomAngleZ = Random.Range(0, 20);
                
                Instantiate(prefabCollectible,
                            new Vector3(crandomX,
                            collectibleY,
                            crandomZ),
                            Quaternion.Euler(crandomAngleX,
                            crandomAngleY,
                            crandomAngleZ));
                //Debug.Log("GeneratePlatform.js: Generated collectible " + 
                //			"X: " + crandomX + " Y: " + collectibleY +" Z: " + crandomZ);
            }
    }
    
    void GenerateEnemy()
    {
        int enemyY = initialGeneratedEnemyY;
        GameObject camera = GameObject.Find("Main Camera");
        while (enemyY*-1 < mapSize &&
                    camera.transform.position.y < distanceThreshold + enemyY)
            {
                var erandomX=Random.Range(-xzRange, xzRange);
                var erandomY=Random.Range(distanceBetweenEnemyYMin, distanceBetweenEnemyYMax);
                enemyY= enemyY - erandomY;
                var erandomZ=Random.Range(-xzRange, xzRange);
                Instantiate(prefabEnemy,
                            new Vector3(erandomX,
                            enemyY,
                            erandomZ),
                            Quaternion.identity);
                //Debug.Log("GeneratePlatform.js: Generated enemy " + 
                //			"X: " + erandomX + " Y: " + enemyY +" Z: " +erandomZ);
            }
    }

    void GenerateMovingEnemy()
    {
        int movingEnemyY = initialGeneratedMovingEnemyY;
        GameObject camera = GameObject.Find("Main Camera");
        while (movingEnemyY*-1 < mapSize &&
                    camera.transform.position.y < distanceThreshold + movingEnemyY)
            {
                var erandomX=Random.Range(-xzRange, xzRange);
                var erandomY=Random.Range(distanceBetweenMovingEnemyYMin, distanceBetweenMovingEnemyYMax);
                movingEnemyY= movingEnemyY - erandomY;
                var erandomZ=Random.Range(-xzRange, xzRange);
                Instantiate(prefabMovingEnemy,
                            new Vector3(erandomX,
                            movingEnemyY,
                            erandomZ),
                            Quaternion.Euler(0,
                            90,
                            0));
                //Debug.Log("GeneratePlatform.js: Generated enemy " + 
                //			"X: " + erandomX + " Y: " + enemyY +" Z: " +erandomZ);
            }
    }

    void GenerateFloor(int floorX, int floorY, int floorZ)
    {
        Debug.Log("GeneratePlatform.js: Generated floor " + 
                        "X: " + floorX + " Y: " + floorY +" Z: " + floorZ); 			
        GameObject floor = Instantiate(prefabFloor,
                                new Vector3(floorX,floorY,floorZ),
                                Quaternion.identity);
        var scale = floor.transform.localScale;
        scale.x = 2 * xzRange;
        scale.z = 2 * xzRange;
        floor.transform.localScale = scale;
    }

    void GenerateCeiling(int ceilingX, int ceilingY, int ceilingZ)
    {
        Debug.Log("GeneratePlatform.js: Generated ceiling " + 
                "X: " + ceilingX + " Y: " + ceilingY +" Z: " + ceilingZ); 			
        GameObject ceiling = Instantiate(prefabCeiling,
                                new Vector3(ceilingX, ceilingY, ceilingZ),
                                Quaternion.identity);
        var scale = ceiling.transform.localScale;
        scale.x = 2*xzRange;
        scale.z = 2*xzRange;
        ceiling.transform.localScale = scale;
    }
    
}
