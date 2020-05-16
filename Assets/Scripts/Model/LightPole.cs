namespace ShooterSunFlower3D
{
    public sealed class LightPole : BaseObjectScene, ISelectObj
    {
        public string GetMessage()
        {
            return Name;
        }

        public float GetHp()
        {
            return 0;
        }
    }
}