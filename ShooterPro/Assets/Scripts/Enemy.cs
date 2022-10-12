using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private float speedEnemy=4;
    [SerializeField]
    private GameObject enemyLaserPrefab,enemyPrefab;


    private Player _player;
    private Animator _animator;

    private AudioSource _audioSource;
    private bool enemyHave=true;
    
    
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        
        if (_animator==null)
        {
            Debug.Log("anim null");
        }

        StartCoroutine(SpawnEnemyLaserRoutine());

    }

    
    void Update()
    {
        transform.Translate(Vector3.down*speedEnemy*Time.deltaTime);
        if (transform.position.y<=-7f)
        {
            transform.position=new Vector3(Random.Range(-7f, 7f), 6.2f, 0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player!=null)
            {
                player.Damage();  
            }
            _animator.SetTrigger("OnEnemyDeath");
            speedEnemy = 0;
            _audioSource.Play();
            
            GetComponent<Collider2D>().enabled = false;
            Destroy(this.gameObject,2.8f);
            
        }

        if (other.tag=="Laser")
        {

            StopCoroutine(SpawnEnemyLaserRoutine());
            Destroy(other.gameObject);
            if (_player!=null)
            {
                _player.AddScore();
            }
            _animator.SetTrigger("OnEnemyDeath");
            speedEnemy = 0;
            _audioSource.Play();

            

            GetComponent<Collider2D>().enabled = false;
            
            Destroy(this.gameObject,2.8f);
            
            
            
        }
    }
    IEnumerator SpawnEnemyLaserRoutine()
    {
        while (enemyHave==true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f,1.2f));
            Instantiate(enemyLaserPrefab,enemyPrefab.transform.position+new Vector3(-0.1f,-1.5f,0), Quaternion.identity);
            enemyHave = false;
            yield break;
        }
    }
    
    
}
