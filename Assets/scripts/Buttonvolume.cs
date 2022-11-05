using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttonvolume : MonoBehaviour {
		public Sprite pic1;
		public Sprite pic2;
	static bool take;

		private Image im;
		void Start()
		{
		take = false;
			im = GetComponent <Image>();
			im.sprite = pic1;
		}
	public void Swap()
		{
			if (im.sprite == pic1 && !take)
			{
				im.sprite = pic2;
			AudioListener.volume = 0;
			take = true;
				return;
			}
			if (im.sprite == pic2 && take)
			{
				im.sprite = pic1;
			AudioListener.volume = 1;
			take = false;
				return;
			}
		}
	}
