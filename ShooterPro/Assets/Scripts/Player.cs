using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public int lives = 3;
    
    
    [SerializeField]
    private float speed =5;
    [SerializeField]
    private GameObject laserPrefab,tripleShotPrefab,shieldImage;
    
    [SerializeField] private GameObject rightFire, leftFire;
    
    [SerializeField]
    private float fireRate = 0.5f;

    private float canFire = -1f;

    private float multipleSpeedMove = 2;
    [SerializeField]
    public int score;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool isTripleShotActive=false;

    public bool speedPowerActive = false;

    private bool shieldPowerActive = false;

    private UI_Manager _uıManager;

    [SerializeField] private AudioClip lazerSound;
    private AudioSource _audioSource;
    
    
    void Start()
    {
        rightFire.SetActive(false);
        leftFire.SetActive(false);
        transform.position = new Vector3(0, -2, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _audioSource = GetComponent<AudioSource>();
        if (_spawnManager==null)
        {
            Debug.Log("bitti");
        }

        _uıManager = FindObjectOfType<UI_Manager>();

        if (_audioSource==null)
        {
            Debug.Log("null audio");
        }
        else
        {
            _audioSource.clip = lazerSound; 
        }
    } 
    void Update()
    {
        CalculateMovement();
        LazerManager();
    }

    void CalculateMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (speedPowerActive==false)
        {
            transform.Translate(new Vector3(horizontalInput,verticalInput,0)*speed*Time.deltaTime);
        }
        else if (speedPowerActive==true)
        {
            transform.Translate(new Vector3(horizontalInput,verticalInput,0)*(speed*multipleSpeedMove)*Time.deltaTime);
        }
        
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0),0);
        if (transform.position.x>=11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x<=-11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
    }
    void LazerManager()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time>canFire )
        {
            canFire = Time.time + fireRate;

            if (isTripleShotActive==true)
            {
                Instantiate(tripleShotPrefab,transform.position,Quaternion.identity);
            }
            else
            {
                Instantiate(laserPrefab,transform.position+new Vector3(0,0.8f,0),Quaternion.identity);
            }
            
            _audioSource.Play();
        }
    }

    public void Damage()
    {
        if (shieldPowerActive==true)
        {
            shieldPowerActive = false;
            shieldImage.SetActive(false);
            return;
        }
        
        
        lives--;
        if (lives==2)
        {
            _uıManager.UpdateLives(lives);
            rightFire.SetActive(true);
        }else if (lives==1)
        {
            _uıManager.UpdateLives(lives);
           leftFire.SetActive(true); 
        }else if (lives<1)
        {
            _uıManager.UpdateLives(lives);
            _spawnManager.OnPlayerDead();
            Destroy(this.gameObject);
        }
        
        
    }

    public void TripleShotActive()
    {
        StartCoroutine(TripleShotDownRoutine());
    }

    IEnumerator TripleShotDownRoutine()
    {
        isTripleShotActive = true;
        yield return new WaitForSeconds(5);
        isTripleShotActive = false;
    }

    public void SpeedPowerActive()
    {
        speedPowerActive = true;
        StartCoroutine(SpeedPowerRoutine()); 
    }

    IEnumerator SpeedPowerRoutine()
    {
        yield return new WaitForSeconds(5);
        speedPowerActive = false;
    }

    public void ShieldPowerActive()
    {
        shieldPowerActive = true;
        shieldImage.SetActive(true);
        
    }

    public void AddScore()
    {
        score += 10;
    }
}
