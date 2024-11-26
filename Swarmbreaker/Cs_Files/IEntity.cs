using System.Numerics;

namespace Swarmbreaker.Cs_Files
{
    public interface IEntity
    {
        int y { get; set; }
        int x { get; set; }
        float statBaseHP { get; set; }
        float statBaseAttack { get; set; }
        float statBonusAttack { get; set; }
        float statBonusArmor { get; set; }

        public void death();

    }
}