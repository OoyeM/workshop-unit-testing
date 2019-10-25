using NSubstitute;
using System;
using TechTalk.SpecFlow;

namespace Elevator
{
    [Binding]
    [Scope(Feature = "UseElevatorV3")]
    public class UseElevatorV3Steps
    {
        private IElevatorBox _elevatorBox;
        private ElevatorUser _elevatorUser;

        public UseElevatorV3Steps()
        {
            _elevatorBox = Substitute.ForPartsOf<ElevatorBox>();
            _elevatorUser = new ElevatorUser();
        }

        [Given(@"I am on the (.*) floor")]
        public void GivenIAmOnTheFloor(int p0)
        {
            _elevatorUser.CurrentFloor = p0;
        }

        [Given(@"the elevator is on the (.*) floor")]
        public void GivenTheElevatorIsOnTheFloor(int p0)
        {
            _elevatorBox.CurrentFloor = p0;
        }

        [Given(@"no call for underground floor is registered")]
        public void GivenNoCallForUndergroundFloorIsRegistered()
        {
            _elevatorBox.ElevatorState = ElevatorState.Stopped;
        }

        [Given(@"a call for (.*) floor is registered")]
        public void GivenACallForFloorIsRegistered(int p0)
        {
            _elevatorBox.RegisterFloorRequest(p0);
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

        [Then(@"the elevator opens door on (.*) level")]
        public void ThenTheElevatorOpensDoorOnLevel(int p0)
        {
            _elevatorBox.Received().OpenDoors(p0);
        }
    }
}
