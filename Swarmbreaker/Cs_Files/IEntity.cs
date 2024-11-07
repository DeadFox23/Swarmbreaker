namespace Swarmbreaker.Cs_Files
{
    public interface IEntity{
    int Id {get;set;}
    int y {get;set;}
    int x {get;set;}
    double statBaseHP {get;set;}
    double statBaseAttack {get;set;}
    double statBonusAttack {get;set;}
    double statBonusArmor {get;set;}

    public void move();
    public void death();
    public void attack();

}
}