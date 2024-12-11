using System.Numerics;

namespace Swarmbreaker.Cs_Files {
    public class EntityEnemy : IEntity {

        public int y { get; set; }
        public int x { get; set; }
        public float speed { get; set; }
        public float statBaseHP { get; set; }
        public float statBaseAttack { get; set; }
        public float statBonusAttack { get; set; }
        public float statBonusArmor { get; set; }
        public int xpDrop { get; }
        public int id { get; set; }
        public Boolean isBoss { get; }
        public int enemyID { get; set; }

        public EntityEnemy(int y, int x, float speed, float statBaseHP, float statBaseAttack, float statBonusAttack, float statBonusArmor, int xpDrop, Boolean isBoss, int enemyID) {
            this.y = y;
            this.x = x;
            this.speed = speed;
            this.statBaseHP = statBaseHP;
            this.statBaseAttack = statBaseAttack;
            this.statBonusAttack = statBonusAttack;
            this.statBonusArmor = statBonusArmor;
            this.xpDrop = xpDrop;

            this.isBoss = isBoss;
            this.enemyID = enemyID;
        }

        public void move(List<EntityPlayerCharacter> players) {
            if ( players == null || players.Count == 0 )
                return; // No players to move toward

            // Find the closest player
            EntityPlayerCharacter? closestPlayer = null;
            float closestDistance = float.MaxValue;
            Vector2 currentPosition = new Vector2(x, y);

            foreach ( var player in players ) {
                Vector2 playerPosition = new Vector2(player.x, player.y);
                float distance = Vector2.Distance(currentPosition, playerPosition);

                if ( distance < closestDistance ) {
                    closestDistance = distance;
                    closestPlayer = player;
                }
            }

            // If no valid player was found, return
            if ( closestPlayer == null )
                return;

            // Move toward the closest player
            Vector2 targetPosition = new Vector2(closestPlayer.x, closestPlayer.y);
            Vector2 direction = targetPosition - currentPosition;

            // Normalize the direction vector
            if ( direction.Length() > 0 ) {
                direction = Vector2.Normalize(direction);
            }

            // Scale by speed and update position
            direction *= speed;
            this.x += ( int ) direction.X;
            this.y += ( int ) direction.Y;
            this.attack(closestPlayer);
        }
        public bool death() {
            return ( this.statBaseHP <= 0 );
        }
        public EntityPlayerCharacter attack(EntityPlayerCharacter target) {
            //check if target has iframes
            if ( DateTime.Now - target.lastTime_iFrame >= TimeSpan.FromSeconds(2) ) {
                //falls target in nähe von self
                if ( target.x >= this.x - 10 && target.x <= this.x + 10 && target.y >= this.y - 10 && target.y <= this.y + 10 ) {
                    //damage multiplied by attack modifier
                    int damage = ( int ) Math.Ceiling(( this.statBaseAttack * this.statBonusAttack ) - target.statBonusArmor);
                    target.statBaseHP = target.statBaseHP - ( damage > 0 ? damage : 0 );
                    //activate target iframes
                    target.lastTime_iFrame = DateTime.Now;
                }
            }
            return target;
        }

    }
}