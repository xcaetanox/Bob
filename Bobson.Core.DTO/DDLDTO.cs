namespace Bobson.Core.DTO
{
    public class DDLDTO
    {
        public string Id { get; set; }

        public string Desc { get; set; }

        public string Extra { get; set; }

        public DDLDTO(string id, string desc)
        {
            this.Id = id;
            this.Desc = desc;
        }

        public DDLDTO(string id, string desc, string extra)
        {
            this.Id = id;
            this.Desc = desc;
            this.Extra = extra;
        }

    }
}

