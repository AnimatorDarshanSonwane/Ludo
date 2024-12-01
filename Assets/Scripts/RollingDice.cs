using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingDice : MonoBehaviour
{
    [SerializeField] int diceNumber;
    [SerializeField] GameObject diceAnimObject;
    [SerializeField] SpriteRenderer numberedSpriteHolder;
    [SerializeField] Sprite[] numberedSprties;

    bool canDiceRoll= true;
    Coroutine generateRandomNumOnDice;

    private void OnMouseDown()
    {
        generateRandomNumOnDice = StartCoroutine(GenerateRandomNumberOnDice());
    }

    IEnumerator GenerateRandomNumberOnDice()
    {
        yield return new WaitForEndOfFrame();
        if (canDiceRoll)
        {
            canDiceRoll = false;
            numberedSpriteHolder.gameObject.SetActive(false);
            diceAnimObject.SetActive(true);
            yield return new WaitForSeconds(1f);

            diceNumber = Random.Range(0, 6);
            numberedSpriteHolder.sprite = numberedSprties[diceNumber];
            diceNumber++;

            GameManager.Instance.numberOfStepsToMove = diceNumber;
            GameManager.Instance.rolledDice = this;

            numberedSpriteHolder.gameObject.SetActive(true);
            diceAnimObject.SetActive(false);

            yield return new WaitForEndOfFrame();
            canDiceRoll = true;
            if (generateRandomNumOnDice != null)
            {
                StopCoroutine(generateRandomNumOnDice);
            }
        }
    }


}
