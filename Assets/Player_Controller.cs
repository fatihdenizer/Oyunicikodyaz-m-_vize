using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float hiz = 20f; 
    public float ziplamaKuvveti = 6f;
    public bool isGrounded;
    public int puan = 0;

    private Rigidbody rb;
    private float hareketX;
    private float hareketZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = 3f; 
        rb.angularDamping = 3f;
    }

    void Update()
    {
        hareketX = Input.GetAxis("Horizontal"); 
        hareketZ = Input.GetAxis("Vertical");   

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * ziplamaKuvveti, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        Vector3 hareket = new Vector3(-hareketZ, 0.0f, hareketX);
        rb.AddForce(hareket * hiz);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Bitis"))
        {
            if (puan >= 50)
            {
                Debug.Log("Tebrikler! Oyunu tamamladınız. Sahne yenileniyor...");
            }
            else
            {
                Debug.Log("Puan yetersiz! En az 50 puan toplamalısın. Sahne yenileniyor...");
            }
            
            // Logoyu beklemeden sahneyi anında başa sar
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("YesilNesne"))
        {
            puan += 10;
            Debug.Log("Puan: " + puan);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("KirmiziNesne"))
        {
            puan -= 5;
            Debug.Log("Puan: " + puan);
            Destroy(other.gameObject);
        }
    }
}