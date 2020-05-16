namespace ShooterSunFlower3D
{
    public sealed class Wall : BaseObjectScene, ISelectObj
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