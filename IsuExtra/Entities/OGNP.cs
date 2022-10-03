using System.Collections.Generic;

namespace IsuExtra.Entities
{
    public class OGNP
    {
        private string _name;
        private char _faculty;
        private List<Flow> _flows;
        public OGNP(string name, char faculty)
        {
            _name = name;
            _flows = new List<Flow>();
            _faculty = faculty;
        }

        public string Name => _name;
        public char Faculty => _faculty;
        public List<Flow> Flows => _flows;
        public void AddFLowToOgnp(Flow flow)
        {
            _flows.Add(flow);
        }
    }
}