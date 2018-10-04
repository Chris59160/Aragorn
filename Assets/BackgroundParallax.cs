using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour {

    private Vector3 m_initial_position;
    private Vector3 m_reset_position;

    private Vector3 m_current_position;

    public Vector2 m_direction;
    public float m_speed;

	// Use this for initialization
	void Start () {
        this.m_initial_position = GetComponent<Transform>().position;
        this.m_current_position = GetComponent<Transform>().position;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float spriteWidth = spriteRenderer.bounds.size.x;
        float spriteHeight = spriteRenderer.bounds.size.y;

        if (this.m_direction == Vector2.left) {
            m_reset_position = new Vector3(m_initial_position.x - spriteWidth, m_initial_position.y);
        } else if (this.m_direction == Vector2.right) {
            m_reset_position = new Vector3(m_initial_position.x + spriteWidth, m_initial_position.y);
        } else if (this.m_direction == Vector2.down) {
            m_reset_position = new Vector3(m_initial_position.x, m_initial_position.y - spriteHeight);
        } else if (this.m_direction == Vector2.up) {
            m_reset_position = new Vector3(m_initial_position.x, m_initial_position.y + spriteHeight);
        }
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Update Background Parallax");

        m_current_position.x += Time.deltaTime * this.m_speed * m_direction.x;
        m_current_position.y += Time.deltaTime * this.m_speed * m_direction.y;

        CheckResetPosition();

        Transform transform = GetComponent<Transform>();
        transform.position = m_current_position;
    }

    private void CheckResetPosition() {
        if (this.m_direction == Vector2.left && m_current_position.x < m_reset_position.x)
        {
            m_current_position.x = m_initial_position.x;
            m_current_position.y = m_initial_position.y;
        }
        else if (this.m_direction == Vector2.right && m_current_position.x > m_reset_position.x)
        {
            m_current_position.x = m_initial_position.x;
            m_current_position.y = m_initial_position.y;
        }
        else if (this.m_direction == Vector2.down && m_current_position.y < m_reset_position.y)
        {
            m_current_position.x = m_initial_position.x;
            m_current_position.y = m_initial_position.y;
        }
        else if (this.m_direction == Vector2.up && m_current_position.y > m_reset_position.y)
        {
            m_current_position.x = m_initial_position.x;
            m_current_position.y = m_initial_position.y;
        }
    }
}
