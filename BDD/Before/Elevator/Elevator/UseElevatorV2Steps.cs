using NSubstitute;
using System;
using TechTalk.SpecFlow;

namespace Elevator
{
    [Binding]
    public class UseElevatorV2Steps
    {

        private IElevatorBox _elevatorBox;
        private ElevatorUser _elevatorUser;

        [Scope(Feature = "UseElevatorV2")]
        [Given(@"the elevator is on the ground floor")]
        public void GivenTheElevatorIsOnTheGroundFloor()
        {
            _elevatorBox = Substitute.ForPartsOf<ElevatorBox>();
            _elevatorBox.CurrentFloor = 0;
        }

        [Scope(Feature = "UseElevatorV2")]
        [Given(@"I am on the ground floor")]
        public void GivenIAmOnTheGroundFloor()
        {
            _elevatorUser = new ElevatorUser() { CurrentFloor = 0 };
        }
        [Scope(Feature = "UseElevatorV2")]
        [Given(@"no call for elevator is registered")]
        public void GivenNoCallForElevatorIsRegistered()
        {
            _elevatorBox.ElevatorState = ElevatorState.Stopped;
        }

        [Scope(Feature = "UseElevatorV2")]
        [Given(@"a call for underground floor is registered")]
        public void GivenACallForUndergroundFloorIsRegistered()
        {
            _elevatorBox.RegisterFloorRequest(-1);
        }

        [Scope(Feature = "UseElevatorV2")]
        [Given(@"a call for third floor is registered")]
        public void GivenACallForThirdFloorIsRegistered()
        {
            _elevatorBox.RegisterFloorRequest(3);
        }

        [Scope(Feature = "UseElevatorV2")]
        [When(@"I call elevator")]
        public void WhenICallElevator()
        {
            _elevatorUser.CallElevator(_elevatorBox);
        }

        [Scope(Feature = "UseElevatorV2")]
        [When(@"the elevator operates")]
        public void WhenTheElevatorOperates()
        {
            _elevatorBox.Operate();
        }

       

        [Scope(Feature = "UseElevatorV2")]
        [Then(@"the elevator opens door on underground level")]
        public void ThenTheElevatorOpensDoorOnUndergroundLevel()
        {
            _elevatorBox.Received().OpenDoors(-1);
        }

        [Scope(Feature = "UseElevatorV2")]
        [Then(@"the elevator opens door on ground level")]
        public void ThenTheElevatorOpensDoorOnGroundLevel()
        {
            _elevatorBox.Received().OpenDoors(0);
        }

        [Scope(Feature = "UseElevatorV2")]
        [Then(@"the elevator opens door on third level")]
        public void ThenTheElevatorOpensDoorOnThirdLevel()
        {
            _elevatorBox.Received().OpenDoors(3);
        }
    }
}
