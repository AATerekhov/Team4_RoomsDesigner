using RoomsDesigner.Domain.Entity.Base;

namespace RoomsDesigner.Domain.Entity
{
    public class Participant : Entity<Guid>
    {
        public string UserMail { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public Guid UserId { get; private set; }
        public Case Room { get;}     

        public Participant(Guid id, string userMail, Case room, string name , Guid userId) : base(id)
        {
            Room = room;
            UserMail = userMail;
            Name = name;
            UserId = userId;
        }

        public Participant(string userMail, Case room, string name, Guid userId) : this(Guid.NewGuid(), userMail, room, name, userId) 
        {
        
        }

        protected Participant() : base(Guid.NewGuid())
        {
            Room = new Case(Guid.Empty,string.Empty,Guid.Empty);
        }
        public void Update(Guid userId, string userMail, string name) 
        {
            UserId = userId;
            Name = name;
            UserMail = userMail;
        }
    }
}
