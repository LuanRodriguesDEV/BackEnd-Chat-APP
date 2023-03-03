
namespace SignalRTest.DTOS
{
    public class UserProfileDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string bannerIMG { get; set; }
        public string profileIMG { get; set; }
        public bool isFollowing { get; set; }
    }


}
