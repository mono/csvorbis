using System;
using System.Text;
using System.Media;
using System.IO;

namespace OggDecoder
{
	class OggPlayer
	{
		static void Main(string[] args)
		{
			using (var file = new FileStream(args[0], FileMode.Open, FileAccess.Read))
			{
				var player = new SoundPlayer(new OggDecodeStream(file));
				player.PlaySync();
			}
		}
	}
}
