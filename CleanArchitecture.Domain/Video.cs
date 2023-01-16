using CleanArchitecture.Domain.Common;
using System.Security.Cryptography.X509Certificates;

namespace CleanArchitecture.Domain
{
    public class Video : BaseDomainModel
    {
        public Video()
        {
            Actores = new HashSet<Actor>();
        }

        public string Nombre { get; set; } = string.Empty;
        public int StreamerId { get; set; }
        public virtual Streamer? Streamer { get; set; }

        public virtual ICollection<Actor> Actores { get; set; }
        public virtual Director Director { get; set; }    
    }
}
