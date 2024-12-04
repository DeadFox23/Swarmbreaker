using Newtonsoft.Json;

namespace Swarmbreaker
{
	[JsonObject(MemberSerialization.OptOut)]
	public class DataTransfer
	{
		[JsonProperty]
		public string Timer { get; set;}
	}
}
