var prefabPlatform:Transform;
var prefabFloor:Transform;
var prefabCeiling:Transform;
var prefabCollectible:Transform;
var prefabEnemy:Transform;
var prefabMovingEnemy:Transform;
var prefabBorder:Transform;

var distanceThreshold : int = 30;

//TODO: refactor to c# - generator classes

/* Level */
static var xzRange : int = 10; //level size
var initialGeneratedFloorY : int = -50; //floor
var initialGeneratedCeilingY : int = 50; //ceiling

/* Platform */
var distanceBetweenPlatformYMin : int = 1;
var distanceBetweenPlatformYMax : int = 3;
var initialGeneratedPlatformY : int = -3;

/* Collectible */
var distanceBetweenCollectibleYMin : int = 4;
var distanceBetweenCollectibleYMax : int = 8;
var initialGeneratedCollectibleY : int = -15;

/* Enemy */
var distanceBetweenEnemyYMin : int = 4;
var distanceBetweenEnemyYMax : int = 8;
var initialGeneratedEnemyY : int = -15;

/* MovingEnemy */
var distanceBetweenMovingEnemyYMin : int = 10;
var distanceBetweenMovingEnemyYMax : int = 20;
var initialGeneratedMovingEnemyY : int = -50;

private var randomSeed : int;
private var mapSize : int;
private var levelID : int;

function Awake() {
	var sceneManager = GameObject.Find("SceneManager");
	if (sceneManager == null) //debugging - running scene alone
	{
		levelID = 9999;
		randomSeed = 0;
		mapSize = 3000;
	}
	else
	{
		levelID = sceneManager.GetComponent(Scenes).GetLevelID();
		randomSeed = sceneManager.GetComponent(Scenes).GetLevelSeed();
		mapSize = sceneManager.GetComponent(Scenes).GetLevelMapSize();

	}
}

function PrintLevelInformation()
{
	Debug.Log("Level Information");
	Debug.Log("Loaded level's ID: " + levelID);
	Debug.Log("Loaded level's map size: " + mapSize);
	Debug.Log("Loaded level's seed number: " + randomSeed);
}

function Start()
{
	PrintLevelInformation();
	Random.seed = randomSeed;
	GenerateBorderWalls();
	GenerateFloor(0, initialGeneratedFloorY, 0);
	GenerateCeiling(0, initialGeneratedCeilingY,0);
}

function Update() 
{
	GeneratePlatform();
	GenerateEnemy();
	GenerateMovingEnemy();
	GenerateCollectible();
}

function GenerateBorderWalls()
{
	var xzBorderRange = xzRange+0.5;

	var borderArray = new Array();		
	borderArray.Add(Instantiate(prefabBorder, Vector3(-xzBorderRange, 0, -xzBorderRange), Quaternion.identity));
	borderArray.Add(Instantiate(prefabBorder, Vector3(-xzBorderRange, 0, -xzBorderRange), Quaternion.Euler(0,90,0)));
	borderArray.Add(Instantiate(prefabBorder, Vector3(xzBorderRange, 0, xzBorderRange), Quaternion.Euler(0,180,0)));
	borderArray.Add(Instantiate(prefabBorder, Vector3(xzBorderRange, 0, -xzBorderRange), Quaternion.Euler(0,270,0)));
	
	for (var border : Transform in borderArray) {
		border.gameObject.transform.localScale.x = 8*xzRange;
		border.gameObject.GetComponent.<Renderer>().material.color = Color.white;
	}
}

private var platformY = initialGeneratedPlatformY;
function GeneratePlatform()
{
	var camera:GameObject = GameObject.Find("Main Camera");
	while (platformY*-1 < mapSize &&
		   camera.transform.position.y < distanceThreshold + platformY)
	{
		var randomX=Random.Range(-xzRange, xzRange);
		var randomY=Random.Range(distanceBetweenPlatformYMin, distanceBetweenPlatformYMax);
		platformY= platformY - randomY;
		var randomZ=Random.Range(-xzRange,xzRange);
		
		Instantiate(prefabPlatform,
					Vector3(randomX, platformY, randomZ),
					Quaternion.identity);
		//Debug.Log("GeneratePlatform.js: Generated platform " + 
		//			"X: " + randomX + " Y: " + platformY +" Z: " +randomZ);
	}
}

private var collectibleY = initialGeneratedCollectibleY;
function GenerateCollectible()
{
	var camera:GameObject = GameObject.Find("Main Camera");
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
						Vector3(crandomX,
						collectibleY,
						crandomZ),
						Quaternion.Euler(crandomAngleX,
						crandomAngleY,
						crandomAngleZ));
			//Debug.Log("GeneratePlatform.js: Generated collectible " + 
			//			"X: " + crandomX + " Y: " + collectibleY +" Z: " + crandomZ);
		}
}


private var enemyY = initialGeneratedEnemyY;
function GenerateEnemy()
{
	var camera:GameObject = GameObject.Find("Main Camera");
	while (enemyY*-1 < mapSize &&
				 camera.transform.position.y < distanceThreshold + enemyY)
		{
			var erandomX=Random.Range(-xzRange, xzRange);
			var erandomY=Random.Range(distanceBetweenEnemyYMin, distanceBetweenEnemyYMax);
			enemyY= enemyY - erandomY;
			var erandomZ=Random.Range(-xzRange, xzRange);
			Instantiate(prefabEnemy,
						Vector3(erandomX,
						enemyY,
						erandomZ),
						Quaternion.identity);
			//Debug.Log("GeneratePlatform.js: Generated enemy " + 
			//			"X: " + erandomX + " Y: " + enemyY +" Z: " +erandomZ);
		}
}

private var movingEnemyY = initialGeneratedMovingEnemyY;
function GenerateMovingEnemy()
{
	var camera:GameObject = GameObject.Find("Main Camera");
	while (movingEnemyY*-1 < mapSize &&
				 camera.transform.position.y < distanceThreshold + movingEnemyY)
		{
			var erandomX=Random.Range(-xzRange, xzRange);
			var erandomY=Random.Range(distanceBetweenMovingEnemyYMin, distanceBetweenMovingEnemyYMax);
			movingEnemyY= movingEnemyY - erandomY;
			var erandomZ=Random.Range(-xzRange, xzRange);
			Instantiate(prefabMovingEnemy,
						Vector3(erandomX,
						movingEnemyY,
						erandomZ),
						Quaternion.Euler(0,
						90,
						0));
			//Debug.Log("GeneratePlatform.js: Generated enemy " + 
			//			"X: " + erandomX + " Y: " + enemyY +" Z: " +erandomZ);
		}
}

function GenerateFloor(floorX, floorY, floorZ)
{
	Debug.Log("GeneratePlatform.js: Generated floor " + 
					"X: " + floorX + " Y: " + floorY +" Z: " + floorZ); 			
	var floor : Transform = Instantiate(prefabFloor,
							Vector3(floorX,floorY,floorZ),
							Quaternion.identity);
	floor.gameObject.transform.localScale.x = 2*xzRange;
	floor.gameObject.transform.localScale.z = 2*xzRange;
}

function GenerateCeiling(ceilingX, ceilingY, ceilingZ)
{
	Debug.Log("GeneratePlatform.js: Generated ceiling " + 
			  "X: " + ceilingX + " Y: " + ceilingY +" Z: " + ceilingZ); 			
	var ceiling : Transform = Instantiate(prefabCeiling,
							  Vector3(ceilingX, ceilingY, ceilingZ),
							  Quaternion.identity);
	ceiling.gameObject.transform.localScale.x = 2*xzRange;
	ceiling.gameObject.transform.localScale.z = 2*xzRange;
}
