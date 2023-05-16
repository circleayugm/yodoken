using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yodoken : MonoBehaviour
{
    [SerializeField]
    Button BTN_START;
    [SerializeField]
    Text MSG_START;
    [SerializeField]
    Button BTN_NOSTTER;
    [SerializeField]
    Image SPR_JANKEN_CPU;
    [SerializeField]
    Text MSG_SCORE;
    [SerializeField]
    Sprite[] JANKEN_HAND;

    enum MODE
    {
        DEMO=0,
        PLAY,
        OVER
	}
    enum PLAY
    {
        WAIT=0,
        JANKEN,
        PON,
        RESULT
	}

    MODE mode = MODE.DEMO;
    PLAY play = PLAY.WAIT;
    int score = 0;
    int count = 0;
    int my_hand = -1;
    int my_hand_last = -1;
    int yodo_hand = 0;
    int yodo_hand_last = -1;
    int cnt_wait_max = 10;
    int cnt_wait = 0;
    bool sw_start = false;
    bool sw_isover = false;
    bool sw_isaiko = false;
    string msg_nostter = "";

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        BTN_NOSTTER.gameObject.SetActive(false);
        BTN_START.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch(mode)
        {
            case MODE.DEMO:
                if ((count>>4)%2 == 0)
                {
                    MSG_START.enabled = true;
                    MSG_START.text = "勝負ボタンで開始！";
				}
                else
                {
                    MSG_START.enabled = false;
				}
                if (sw_start == true)
                {
                    count = -1;
                    mode = MODE.PLAY;
                    score = 0;
                    cnt_wait = 0;
                    cnt_wait_max = 10;
                    yodo_hand_last = -1;
                    sw_isover = false;
                    sw_isaiko = false;
                    BTN_START.gameObject.SetActive(false);
                    BTN_NOSTTER.gameObject.SetActive(false);
                    MSG_START.enabled = false;
                    sw_start = false;
                    MSG_SCORE.text = "いざ、尋常に！";
                }
                break;
            case MODE.PLAY:
                switch (count)
                {
                    case 0:
                        break;
                    case 1:
                        switch (play)
                        {
                            case PLAY.WAIT:
                                MSG_START.enabled = true;
                                if (sw_isaiko==true)
                                {
                                    MSG_START.text = "あい・こで……";
                                }
                                else
                                {
                                    MSG_START.text = "じゃん・けん……";
                                }
                                break;
                            case PLAY.JANKEN:
                                if ((count>>4)%2==0)
                                {
                                    MSG_START.enabled = true;
                                    MSG_START.text = "<color=#ff0000>ボタンを押して勝て！</color>";
                                }
                                else
                                {
                                    MSG_START.enabled = false;
                                }
                                break;
                            case PLAY.PON:
                                if (sw_isaiko == true)
                                {
                                    MSG_START.text = "しょ！";
                                }
                                else
                                {
                                    MSG_START.text = "ぽん！";
                                }
                                break;
                            case PLAY.RESULT:
                                switch (my_hand)
                                {
                                    case 0:
                                        {
                                            switch (yodo_hand)
                                            {
                                                case 0:
                                                    MSG_START.text = "あいこ！";
                                                    sw_isaiko = true;
                                                    break;
                                                case 1:
                                                    sw_isaiko = false;
                                                    score++;
                                                    cnt_wait = 0;
                                                    if (my_hand == my_hand_last)
                                                    {
                                                        if (--cnt_wait_max == 0)
                                                        {
                                                            cnt_wait_max++;
                                                        }
                                                    }
                                                    MSG_START.text = "勝ち！";
                                                    if (score==1)
                                                    {
                                                        MSG_SCORE.text = "初めて勝った！";
													}
                                                    else
                                                    {
                                                        MSG_SCORE.text = score.ToString() + "連勝中！";
													}
                                                    break;
                                                case 2:
                                                    sw_isaiko = false;
                                                    MSG_START.text = "負け！";
                                                    sw_isover = true;
                                                    break;
                                            }
                                        }
                                        break;
                                    case 1:
                                        {
                                            switch (yodo_hand)
                                            {
                                                case 1:
                                                    MSG_START.text = "あいこ！";
                                                    sw_isaiko = true;
                                                    break;
                                                case 2:
                                                    sw_isaiko = false;
                                                    score++;
                                                    cnt_wait = 0;
                                                    if (my_hand == my_hand_last)
                                                    {
                                                        if (--cnt_wait_max == 0)
                                                        {
                                                            cnt_wait_max++;
                                                        }
                                                    }
                                                    MSG_START.text = "勝ち！";
                                                    if (score == 1)
                                                    {
                                                        MSG_SCORE.text = "初めて勝った！";
                                                    }
                                                    else
                                                    {
                                                        MSG_SCORE.text = score.ToString() + "連勝中！";
                                                    }
                                                    break;
                                                case 0:
                                                    sw_isaiko = false;
                                                    MSG_START.text = "負け！";
                                                    sw_isover = true;
                                                    break;
                                            }
                                        }
                                        break;
                                    case 2:
                                        {
                                            switch (yodo_hand)
                                            {
                                                case 2:
                                                    MSG_START.text = "あいこ！";
                                                    sw_isaiko = true;
                                                    break;
                                                case 0:
                                                    sw_isaiko = false;
                                                    score++;
                                                    cnt_wait = 0;
                                                    if (my_hand == my_hand_last)
                                                    {
                                                        if (--cnt_wait_max == 0)
                                                        {
                                                            cnt_wait_max++;
                                                        }
                                                    }
                                                    MSG_START.text = "勝ち！";
                                                    if (score == 1)
                                                    {
                                                        MSG_SCORE.text = "初めて勝った！";
                                                    }
                                                    else
                                                    {
                                                        MSG_SCORE.text = score.ToString() + "連勝中！";
                                                    }
                                                    break;
                                                case 1:
                                                    sw_isaiko = false;
                                                    MSG_START.text = "負け！";
                                                    sw_isover = true;
                                                    break;
                                            }
                                        }
                                        break;
                                }
                                break;
                        }
                        break;
                    case 60:
                        Debug.Log("isover=" + sw_isover);
                        switch(play)
                        {
                            case PLAY.WAIT:
                                play = PLAY.JANKEN;
                                count = 0;
                                break;
                            case PLAY.PON:
                                play = PLAY.RESULT;
                                count = 0;
                                break;
                            case PLAY.RESULT:
                                if (sw_isover == true)
                                {
                                    count = -1;
                                    mode = MODE.OVER;
                                    play = PLAY.WAIT;
                                }
                                else
                                {
                                    play = PLAY.WAIT;
                                    count = 0;
                                }
                                break;
						}
                        break;
                }
                if (play == PLAY.JANKEN)
                {
                    if (++cnt_wait == cnt_wait_max)
                    {
                        yodo_hand = UnityEngine.Random.Range(0, 99) % 3;
                        SPR_JANKEN_CPU.sprite = JANKEN_HAND[yodo_hand];
                        cnt_wait = 0;
                    }
                }

                break;
            case MODE.OVER:
                switch(count)
                {
                    case 0:
                        switch(score)
                        {
                            case 0:
                                MSG_SCORE.text = "今回は勝てなかった！";
                                msg_nostter = "" + DateTime.Now.ToLongDateString() + "に遊んだ！ https://howto-nostr.info/yodoken/";
                                break;
                            case 1:
                                MSG_SCORE.text = "今回は1勝！";
                                msg_nostter = "" + DateTime.Now.ToLongDateString() + "に1勝！ https://howto-nostr.info/yodoken/";
                                break;
                            default:
                                MSG_SCORE.text = "今回は" + score + "連勝！";
                                msg_nostter = "" + DateTime.Now.ToLongDateString() + "に" + score + "連勝！ https://howto-nostr.info/yodoken/";
                                break;
						}
                        break;
                    case 60:
                        BTN_START.gameObject.SetActive(true);
                        BTN_NOSTTER.gameObject.SetActive(true);
                        mode = MODE.DEMO;
                        count = -1;
                        break;
				}
                break;
		}
        count++;    
    }



    public void PressStartButton()
    {
        sw_start = true;
	}

    public void PressNostterButton()
    {
        if (msg_nostter!="")
        {
            Application.OpenURL("https://nostter.vercel.app/post?content=" + msg_nostter);
        }
    }

    public void PressJankenGooButton()
    {
        if (mode != MODE.PLAY) return;
        if (play != PLAY.JANKEN) return;
        my_hand_last = my_hand;
        my_hand = 0;
        play = PLAY.PON;
        count = 0;
    }

    public void PressJankenChokiButton()
    {
        if (mode != MODE.PLAY) return;
        if (play != PLAY.JANKEN) return;
        my_hand_last = my_hand;
        my_hand = 1;
        play = PLAY.PON;
        count = 0;
    }

    public void PressJankenPaaButton()
    {
        if (mode != MODE.PLAY) return;
        if (play != PLAY.JANKEN) return;
        my_hand_last = my_hand;
        my_hand = 2;
        play = PLAY.PON;
        count = 0;
    }
}
