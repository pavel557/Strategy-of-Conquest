using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTurret : MonoBehaviour
{
    [SerializeField] private GameObject turret;
    [SerializeField] private float offset = 0.5f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private GameObject effectSpawn;
    private Transform parentIcon;
    private RectTransform rectTransformCanvas;

    public Transform ParentIcon { get => parentIcon; set => parentIcon = value; }
    public RectTransform RectTransformCanvas { get => rectTransformCanvas; set => rectTransformCanvas = value; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Instantiate(effectSpawn, transform.position, Quaternion.identity);
        if ((layer.value & (1 << collision.gameObject.layer)) != 0)
        {
            Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.AddForce(new Vector2(100f, 100f));
        }
        else
        {
            Destroy(gameObject);

            Vector3 pos = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
            GameObject Object = Instantiate(turret, pos, Quaternion.identity);
            if ((parentIcon != null) && (rectTransformCanvas != null))
            {
                Object.GetComponent<MapController>().CreateIcon(parentIcon, rectTransformCanvas);
            }
        }
        
    }
}
