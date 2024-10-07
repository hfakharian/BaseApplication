namespace Domain.DataTransferObjects.Collection
{
    public class CollectionResultStatus
    {
        public CollectionResultStatus() {
            this.Authent = false;
            this.Success = false;
            this.Messages = new List<CollectionResultMessage>();
        }
        public CollectionResultStatus(bool? authent, bool success, List<CollectionResultMessage>? messages)
        {
            this.Authent = authent;
            this.Success = success;
            this.Messages = messages;
        }

        public bool? Authent { get; set; }
        public bool? Success { get; set; }
        public List<CollectionResultMessage>? Messages { get; set; }

    }
}
