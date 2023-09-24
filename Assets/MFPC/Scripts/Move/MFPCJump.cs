using UnityEngine;

namespace MFPC
{
    /// <summary>
    /// Allows the character to jump
    /// </summary>
    public class MFPCJump : PlayerGroundedState
    {
        private float oldPlayerPositionY;
        private bool playerFall;

        public MFPCJump(Player player, PlayerStateMachine stateMachine, PlayerData playerData, MFPCPlayerRotation playerRotation) : base(
            player, stateMachine, playerData, playerRotation)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
            oldPlayerPositionY = -player.transform.position.y;
            playerFall = false;

            Jump();
        }

        public override void Update()
        {
            base.Update();

            // Checking if we can jump higher
            if (player.transform.position.y == oldPlayerPositionY) player.Movement.MoveVertical(Vector3.zero);
            if (player.CharacterController.isGrounded && playerFall)
                stateMachine.ChangeState(stateMachine.MovementState);
            if (!player.CharacterController.isGrounded) playerFall = true;

            oldPlayerPositionY = player.transform.position.y;
        }

        /// <summary>
        /// Directs the character up (jump)
        /// </summary>
        private void Jump()
        {
            if (player.CharacterController.isGrounded)
            {
                player.Movement.MoveVertical(Vector3.up, playerData.JumpForce);
                player.ChangeMoveCondition(MoveConditions.Jump);
                PlaySound(playerData.JumpSFX);
            }
        }
    }
}