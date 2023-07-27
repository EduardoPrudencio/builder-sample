namespace Buider
{
    public sealed class OrgChartMember
    {
        private OrgChartMember() { }

        private OrgChartMember(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }

        Lazy<List<OrgChartMember>> _team = new();
        public IReadOnlyList<OrgChartMember> Team => _team.Value;

        public static OrgChartBuilder Create(string id, string name)
            => new OrgChartBuilder(new OrgChartMember(id, name));


        public class OrgChartBuilder
        {
            public OrgChartMember _root;
            public OrgChartBuilder(OrgChartMember root)
            {
                _root = root;
            }

            public OrgChartBuilder AddSubordinate(string id, string name)
            {
                _root._team.Value.Add(new OrgChartMember(id, name);
                return this;
            }

            public OrgChartBuilder AddSubordinate(string id, string name, Action<OrgChartBuilder> builderAction)
            {
                var action = new OrgChartBuilder(new OrgChartMember(id, name));
                builderAction(action);
                _root._team.Value.Add(action.Build());
                return this;
            }

            public OrgChartMember Build()
                => _root;

            public static implicit operator OrgChartMember(OrgChartBuilder input)
                => input._root;
        }
    }
}
