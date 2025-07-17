using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public RectTransform uiGroup;   // 상점 UI
    public Animator anim;

    public GameObject[] itemObj;    // 아이템
    public int[] itemPrice;         // 아이템 가격
    public Transform[] itemPos;     // 아이템 위치
    public string[] talkData;       // 대사
    public Text talkText;           // 대사 UI

    Player enterPlayer;

    // 상점 들어오면 UI 활성화
    public void Enter(Player player)
    {
        enterPlayer = player;
        uiGroup.anchoredPosition = Vector3.zero;
    }

    // 상점 나가면 UI 비활성화
    public void Exit()
    {
        anim.SetTrigger("doHello");
        uiGroup.anchoredPosition = Vector3.down * 1000;
    }

    // 어떤 아이템인지 index로 받아옴
    public void Buy(int index)
    {
        // 소지금이 부족하다면 대사 출력
        int price = itemPrice[index];
        if(price > enterPlayer.coin)
        {
            StopCoroutine(Talk());
            StartCoroutine(Talk());
            return;
        }

        // 구매 후 적절한 위치에 아이템 생성
        enterPlayer.coin -= price;
        Vector3 ranVec = Vector3.right * Random.Range(-3, 3) + Vector3.forward * Random.Range(-3, 3);
        Instantiate(itemObj[index], itemPos[index].position + ranVec, itemPos[index].rotation);
    }

    // 소지금 부족 대사 출력
    IEnumerator Talk()
    {
        talkText.text = talkData[1];
        yield return new WaitForSeconds(2f);
        talkText.text = talkData[0];
    }
}
