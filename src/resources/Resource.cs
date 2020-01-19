namespace DiggersLife
{
	public class Resource
	{
		public string Name { get; }

		public string Namespace { get; }

		public string FullName => $"{Namespace}:{Name}";

		public Resource(string name, string ns = "diggerslife") => (Namespace, Name) = (ns, name);
	}
}
