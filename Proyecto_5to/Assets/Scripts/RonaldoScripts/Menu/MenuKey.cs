using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuKey : MonoBehaviour
{
    [SerializeField] GameObject Button;
    public TMP_Text ButtonText;
    public Movement PlayerMov;
    public KeyCode NewKey;
    public State state;


    public float Timer = 0;
    public bool Active = false;

    protected List<KeyCode> m_activeInputs = new List<KeyCode>();

    public enum State
    {
        adelante, atras, izquierda, derecha
    }
    void Start()
    {
        switches();
    }
    void Update()
    {
        if (Active)
        {
            if (Input.anyKeyDown)
            {
                Codes();
                NewKey = m_activeInputs[0];
                switches();
                Button.SetActive(true);
                Active = false;
            }
            Codes();
        }
        else
        ButtonText.text = NewKey.ToString();

    }

    void switches()
    {
        if (Active)
        {
            switch (state)
            {
                case State.adelante:
                    PlayerMov.adelante = NewKey;
                    break;
                case State.atras:
                    PlayerMov.atras = NewKey;
                    break;
                case State.izquierda:
                    PlayerMov.izquierda = NewKey;
                    break;
                case State.derecha:
                    PlayerMov.derecha = NewKey;
                    break;
            }
        }
        else
        {
            switch (state)
            {
                case State.adelante:
                    NewKey = PlayerMov.adelante;
                    break;
                case State.atras:
                    NewKey = PlayerMov.atras;
                    break;
                case State.izquierda:
                    NewKey = PlayerMov.izquierda;
                    break;
                case State.derecha:
                    NewKey = PlayerMov.derecha;
                    break;
            }
        }
    }
    public void ChangeInput()
    {
        Button.SetActive(false);
        Active = true;
    }
    public void Codes()
    {
        List<KeyCode> pressedInput = new List<KeyCode>();

        if (Input.anyKeyDown || Input.anyKey)
        {
            foreach (KeyCode code in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(code))
                {
                    m_activeInputs.Remove(code);
                    m_activeInputs.Add(code);
                    pressedInput.Add(code);

                    //Debug.Log(code + " was pressed");
                }
            }
        }

        List<KeyCode> releasedInput = new List<KeyCode>();

        foreach (KeyCode code in m_activeInputs)
        {
            releasedInput.Add(code);

            if (!pressedInput.Contains(code))
            {
                releasedInput.Remove(code);

                //Debug.Log(code + " was released");
            }
        }
        m_activeInputs = releasedInput;


    }
}

