using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace Swarmbreaker.Cs_Files
{
    public class EntityEnemy : IEntity
    {

        public int y { get; set; } = 0;
        public int x { get; set; } = 0;
        public float speed { get; set; } = 0;
        public float statBaseHP { get; set; } = 0;
        public float statBaseAttack { get; set; } = 0;
        public float statBonusAttack { get; set; } = 0;
        public float statBonusArmor { get; set; } = 0;
        public int xpDrop { get; } = 0;
        public Boolean isBoss { get; } = false;

        public void move(List<EntityPlayerCharacter> players) {
            if (players == null || players.Count == 0)
                return; // No players to move toward

            // Find the closest player
            EntityPlayerCharacter? closestPlayer = null;
            float closestDistance = float.MaxValue;
            Vector2 currentPosition = new Vector2(x, y);

            foreach (var player in players)
            {
                Vector2 playerPosition = new Vector2(player.x, player.y);
                float distance = Vector2.Distance(currentPosition, playerPosition);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPlayer = player;
                }
            }

            // If no valid player was found, return
            if (closestPlayer == null)
                return;

            // Move toward the closest player
            Vector2 targetPosition = new Vector2(closestPlayer.x, closestPlayer.y);
            Vector2 direction = targetPosition - currentPosition;

            // Normalize the direction vector
            if (direction.Length() > 0)
            {
                direction = Vector2.Normalize(direction);
            }

            // Scale by speed and update position
            direction *= speed;
            this.x += (int)direction.X;
            this.y += (int)direction.Y;
            this.attack(closestPlayer);
        }
        public bool death() {
            return(this.statBaseHP <= 0);
        }
        public EntityPlayerCharacter attack(EntityPlayerCharacter target) {
            //falls target in nähe von self
            if (target.x >= this.x-10 && target.x<=this.x+10 && target.y >= this.y - 10 && target.y <= this.y + 10) {
                //damage multiplied by attack modifier
                int damage = (int) Math.Ceiling((this.statBaseAttack * this.statBonusAttack) - target.statBonusArmor);
                target.statBaseHP = target.statBaseHP - (damage > 0 ? damage : 0);

            }
            return target;
        }

    }
}