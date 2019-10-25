using NSubstitute;
using System;
using TechTalk.SpecFlow;

namespace Elevator
{
    [Binding]
    [Scope(Feature = "UseElevatorV1")]
    public class UseElevatorV1Steps
    {
        private IElevatorBox _elevatorBox;
        private ElevatorUser _elevatorUser;
        [Given(@"the elevator is on the ground floor")]
        public void GivenTheElevatorIsOnTheGroundFloor()
        {
            _elevatorBox = Substitute.ForPartsOf<ElevatorBox>();
            _elevatorBox.CurrentFloor = 0;
        }

        [Given(@"I am on the ground floor")]
        public void GivenIAmOnTheGroundFloor()
        {
            _elevatorUser = new ElevatorUser() { CurrentFloor = 0 };
        }

        [When(@"I call elevator")]
        public void WhenICallElevator()
        {
            _elevatorUser.CallElevator(_elevatorBox);
        }

        [When(@"the elevator operates")]
        public void WhenTheElevatorOperates()
        {
            _elevatorBox.Operate();
        }

        [Then(@"the elevator opens door on ground level")]
        public void ThenTheElevatorOpensDoorOnGroundLevel()
        {
            _elevatorBox.Received().OpenDoors(0);
        }
    }
}
